using YoutubeApiCleanArchitecture.Domain.Abstraction;
using YoutubeApiCleanArchitecture.Domain.Entities.Customers.DTOs;
using YoutubeApiCleanArchitecture.Domain.Entities.Customers.Events;
using YoutubeApiCleanArchitecture.Domain.Entities.Customers.ValueObject;
using YoutubeApiCleanArchitecture.Domain.Entities.Invoices;
using YoutubeApiCleanArchitecture.Domain.Entities.Shared;

namespace YoutubeApiCleanArchitecture.Domain.Entities.Customers
{
    public sealed class Customer : BaseEntity
    {
        public Customer(Title title, Address adress, Money balance)
        {
            Title = title;
            Adress = adress;
            Balance = balance;
        }

        private Customer() { }
        public Title Title { get; private set; } = null!;
        public Address Adress { get; private set; } = null!;
        public Money Balance { get; private set; } = null!;
        public ICollection<Invoice> Invoices { get; private set; } = null!; 

        public static Customer Create(CreateCustomerDto request)
        {
            var customer = new Customer(
                new Title(request.Title),
                new Address(request.FirstLineAddress,
                request.SecondLineAddress,
                request.Postcode,
                request.City,
                request.Country),
                new Money(0));
            customer.RaiseDomainEvent(new CustomerCreatedDomainEvent(customer.Id));
            return customer;
        }

        public void Update(UpdateCustomerDto request)
        {
            Title = new Title(request.Title);
            Adress = new Address(request.FirstLineAddress,
                request.SecondLineAddress,
                request.Postcode,
                request.City,
                request.Country);
        }
    }
}
