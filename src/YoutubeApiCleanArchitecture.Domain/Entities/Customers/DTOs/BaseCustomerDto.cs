using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeApiCleanArchitecture.Domain.Entities.Customers.ValueObject;
using YoutubeApiCleanArchitecture.Domain.Entities.Shared;

namespace YoutubeApiCleanArchitecture.Domain.Entities.Customers.DTOs
{
    public class BaseCustomerDto
    {
        public string Title { get; set; } = null!;
        public string FirstLineAddress { get; set; } = null!;
        public string? SecondLineAddress { get; set; } = null!;
        public string Postcode { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Country { get; set; } = null!;
    }

    public class CreateCustomerDto : BaseCustomerDto;
    public class UpdateCustomerDto : BaseCustomerDto
    {
        public Guid CustomerId { get; set; }
    }
}
