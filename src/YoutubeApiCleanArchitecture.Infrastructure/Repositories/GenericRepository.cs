﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeApiCleanArchitecture.Domain.Abstraction;

namespace YoutubeApiCleanArchitecture.Infrastructure.Repositories
{
    public class GenericRepository<TEntity>(AppDbContext context) : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly AppDbContext _context = context;
        public async Task<TEntity> CreateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            await _context.Set<TEntity>().AddAsync(entity, cancellationToken);
            return entity;
        }

        public async Task CreateRangeAsync(IEnumerable<TEntity> entityCollection, CancellationToken cancellationToken = default) =>
            await _context
            .Set<TEntity>().AddRangeAsync(entityCollection, cancellationToken);

        public void Delete(TEntity entity) =>
            _context.Set<TEntity>().Remove(entity);

        public void DeleteRange(IEnumerable<TEntity> entityCollection) =>
            _context.Set<TEntity>().RemoveRange(entityCollection);

        public IQueryable<TEntity> GetAll() =>
            _context.Set<TEntity>().AsNoTracking().AsQueryable();

        public async Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default) =>
            await _context.Set<TEntity>().FindAsync([id, cancellationToken], cancellationToken);

        public TEntity Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            return entity;
        }

        public void UpdateRange(IEnumerable<TEntity> entityCollection) =>
            _context.Set<TEntity>().UpdateRange(entityCollection);
    }
}
