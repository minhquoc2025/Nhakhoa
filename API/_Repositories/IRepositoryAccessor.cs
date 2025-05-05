using API.Models;
using Microsoft.EntityFrameworkCore.Storage;

namespace API._Repositories
{
    public interface IFunctionRepository
    {
        Task<IDbContextTransaction> BeginTransactionAsync();
        Task<bool> Save();
    }

    [DependencyInjection(ServiceLifetime.Scoped)]
    public interface IRepositoryAccessor : IFunctionRepository
    {
        // 1. Init Repository
        IRepository<Service> Service { get; }
    }
}