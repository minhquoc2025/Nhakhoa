using API.DTOs;

namespace API._Services.Interfaces
{
    [DependencyInjection(ServiceLifetime.Scoped)]
    public interface I_Demo
    {
        Task<KeyValuePair<int, string>> GetDropdown();
        Task<PaginationUtility<DemoDto>> GetDataPagination(PaginationParam pagination, DemoFilter filter);
        Task<OperationResult> Create(DemoDto dto);
        Task<OperationResult> Update(DemoDto dto);
        Task<OperationResult> Delete(int id);
    }
}