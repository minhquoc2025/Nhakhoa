using API._Repositories;

namespace API._Services.Services
{
    /// <summary>
    /// Base Common Class Services - Lớp Dịch vụ dùng chung
    /// </summary>
    public class BaseServices
    {
        protected readonly IRepositoryAccessor _repositoryAccessor;

        public BaseServices(IRepositoryAccessor repositoryAccessor)
        {
            _repositoryAccessor = repositoryAccessor;
        }
    }
}