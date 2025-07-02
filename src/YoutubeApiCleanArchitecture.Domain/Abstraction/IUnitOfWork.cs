using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeApiCleanArchitecture.Domain.Abstraction
{
    public interface IUnitOfWork
    {
        Task<string> CommitAsync(CancellationToken cancellationToken = default, bool checkForConcurrency = false);
        IGenericRepository<Tentity> Repository<Tentity>() where Tentity : BaseEntity;
    }
}
