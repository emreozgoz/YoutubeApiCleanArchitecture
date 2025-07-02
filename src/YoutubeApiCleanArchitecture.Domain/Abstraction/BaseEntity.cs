using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeApiCleanArchitecture.Domain.Abstraction
{
    public abstract class BaseEntity
    {
        private readonly List<IDomainEvent> _domainEvents = [];
        protected BaseEntity() { }
        protected BaseEntity(Guid id) => Id = id;
        //init dedik çünkü bu ID propertysine sadece nesne oluşturulurken değer atanabilir.
        //set yapsaydık istediğimiz zaman değiştirebilirdik
        public Guid Id { get; init; }
        public byte[] RowVersion { get; set; } = null!;

        public IReadOnlyList<IDomainEvent> GetDomainEvents() => _domainEvents.ToList();
        public void ClearDomainEvents() => _domainEvents.Clear();
        protected void RaiseDomainEvent(IDomainEvent domainEvent) => _domainEvents.Add(domainEvent);
    }
}
