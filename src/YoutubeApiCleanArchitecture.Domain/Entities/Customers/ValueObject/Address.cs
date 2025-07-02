using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeApiCleanArchitecture.Domain.Entities.Customers.ValueObject
{
    public record Address(string FirstLineAddress, string? SecondLineAddress, string Postcode, string City, string Country);
}
