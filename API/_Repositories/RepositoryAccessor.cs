using API.Data;
using API.Models;
using Microsoft.EntityFrameworkCore.Storage;

namespace API._Repositories
{
    public class FunctionRepository
    {
        public readonly DBContext _dbContext;
        public FunctionRepository(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _dbContext.Database.BeginTransactionAsync();
        }

        public async Task<bool> Save()
        {
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }

    public partial class RepositoryAccessor : FunctionRepository, IRepositoryAccessor
    {
        // 1. Tạo Repository với Model
        public IRepository<Service> Service { get; set; }
        public RepositoryAccessor(DBContext dbContext) : base(dbContext)
        {
            // 2. Khởi tạo với Repo
            Service = new Repository<Service, DBContext>(_dbContext);
        }
    }
}