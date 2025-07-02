using System.Threading.Tasks;
using YoutubeApiCleanArchitecture.Domain.Abstraction;
using YoutubeApiCleanArchitecture.Domain.Entities.Customers;
using YoutubeApiCleanArchitecture.Domain.Entities.InvoiceItems;
using YoutubeApiCleanArchitecture.Domain.Entities.Invoices.DTOs;
using YoutubeApiCleanArchitecture.Domain.Entities.Invoices.Events;
using YoutubeApiCleanArchitecture.Domain.Entities.Invoices.ValueObjects;
using YoutubeApiCleanArchitecture.Domain.Entities.Shared;

namespace YoutubeApiCleanArchitecture.Domain.Entities.Invoices
{
    public sealed class Invoice : BaseEntity
    {
        private Invoice() { }

        private Invoice(
            Guid invoiceId,
            PoNumber poNumber,
            Guid customerId,
            ICollection<InvoiceItem> purchasedProducts,
            Money totalBalance)
        {
            PoNumber = poNumber;
            CustomerId = customerId;
            PurchasedProducts = purchasedProducts;
            TotalBalance = totalBalance;
        }

        public PoNumber PoNumber { get; set; } = null!;
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;
        public ICollection<InvoiceItem> PurchasedProducts { get; set; } = null!;
        public Money TotalBalance { get; set; } = null!;

        public static async Task<Invoice> Create(CreateInvoiceDto request, IUnitOfWork unitOfWork)
        {
            if (request.PurchasedProducts is null || request.PurchasedProducts.Count == 0)
                throw new InvalidOperationException("empty invoice not created");

            var invoiceId = Guid.NewGuid();
            ICollection<InvoiceItem> purchasedProducts = [];

            foreach (var purchasedProduct in request.PurchasedProducts)
            {
                var product = await unitOfWork
                    .Repository<Product.Product>()
                    .GetByIdAsync(purchasedProduct.ProductId) ??
                    throw new ArgumentNullException($"Product with id {purchasedProduct.ProductId}  not found");

                var invoiceItem = new InvoiceItem(
                    Guid.NewGuid(),
                    new Money(product.UnitPrice.Value),
                    new InvoiceItems.ValueObjects.Quantity(purchasedProduct.Quantity),
                    invoiceId);

                purchasedProducts.Add(invoiceItem);
            }
            var totalBalance = purchasedProducts.Sum(x => x.TotalPrice.Value);

            var invoice = new Invoice(
                invoiceId,
                new PoNumber(request.PoNumber),
                request.CustomerId,
                purchasedProducts,
                new Money(totalBalance));

            invoice.RaiseDomainEvent(new InvoiceCreatedDomainEvent(invoiceId));

            return invoice;
        }
        public void Update(UpdateInvoiceDto request)
        {
            PoNumber = new PoNumber(request.PoNumber);
        }

    }
}
