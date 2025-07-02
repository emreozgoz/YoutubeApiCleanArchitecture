﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace YoutubeApiCleanArchitecture.Domain.Abstraction
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        IQueryable<TEntity> GetAll();
        Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<TEntity> CreateAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task CreateRangeAsync(IEnumerable<TEntity> entityCollection, CancellationToken cancellationToken = default);
        TEntity Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entityCollection);
        void Delete(TEntity entity);
        void DeleteRange(IEnumerable<TEntity> entityCollection);
    }
}
