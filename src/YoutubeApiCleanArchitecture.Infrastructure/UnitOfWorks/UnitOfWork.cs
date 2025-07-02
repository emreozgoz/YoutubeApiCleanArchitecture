using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeApiCleanArchitecture.Domain.Abstraction;
using YoutubeApiCleanArchitecture.Infrastructure.Repositories;

namespace YoutubeApiCleanArchitecture.Infrastructure.UnitOfWorks
{
    public class UnitOfWork(AppDbContext context) : IUnitOfWork
    {
        private readonly AppDbContext _context = context;
        public async Task<string> CommitAsync(CancellationToken cancellationToken = default, bool checkForConcurrency = false)
        {
            try
            {
                await _context.SaveChangesAsync(cancellationToken);
            }
            catch (DbUpdateConcurrencyException ex) when (checkForConcurrency)
            {
                return "A concurrency conflict";
            }
            return string.Empty;
        }

        public IGenericRepository<Tentity> Repository<Tentity>() where Tentity : BaseEntity =>
            new GenericRepository<Tentity>(_context);
    }
}
