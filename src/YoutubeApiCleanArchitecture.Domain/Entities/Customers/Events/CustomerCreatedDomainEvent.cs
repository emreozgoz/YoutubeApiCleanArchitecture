using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeApiCleanArchitecture.Domain.Abstraction;

namespace YoutubeApiCleanArchitecture.Domain.Entities.Customers.Events
{
    public record CustomerCreatedDomainEvent(Guid customerId) : IDomainEvent;
}
