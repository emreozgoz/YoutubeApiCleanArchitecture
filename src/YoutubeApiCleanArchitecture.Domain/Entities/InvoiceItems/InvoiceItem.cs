using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using YoutubeApiCleanArchitecture.Domain.Abstraction;
using YoutubeApiCleanArchitecture.Domain.Entities.InvoiceItems.ValueObjects;
using YoutubeApiCleanArchitecture.Domain.Entities.Invoices;
using YoutubeApiCleanArchitecture.Domain.Entities.Shared;

namespace YoutubeApiCleanArchitecture.Domain.Entities.InvoiceItems
{
    public sealed class InvoiceItem : BaseEntity
    {
        private InvoiceItem() { }

        internal InvoiceItem(Guid id, Money sellPrice, Quantity quantity, Guid invoiceId) : base(id)
        {
            SellPrice = sellPrice;
            Quantity = quantity;
            TotalPrice = new Money(sellPrice.Value * quantity.Value);
            InvoiceId = invoiceId;
        }
        public Money SellPrice { get; set; } = null!;
        public Quantity Quantity { get; set; } = null!;
        public Money TotalPrice { get; set; } = null!;
        public Guid InvoiceId { get; set; }
        public Invoice Invoice { get; set; } = null!;
    }
}
