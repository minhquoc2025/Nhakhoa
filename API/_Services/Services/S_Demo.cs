using AgileObjects.AgileMapper;
using API._Repositories;
using API._Services.Interfaces;
using API.DTOs;
using API.Models;

namespace API._Services.Services
{
    /// 
    public class S_Demo : BaseServices, I_Demo
    {
        public S_Demo(IRepositoryAccessor repositoryAccessor) : base(repositoryAccessor)
        {
        }

        public async Task<OperationResult> Create(DemoDto dto)
        {
            // .. Xử lý dữ liệu

            // Mapper with Agile Mapper
            var model = Mapper.Map(dto).ToANew<Demo>(x => x.MapEntityKeys());

            // Save Change
            _repositoryAccessor.Demo.Add(model);
            await _repositoryAccessor.Save();

            return new OperationResult(true, "Create Successfully");
        }

        public Task<OperationResult> Delete(int id)
        {
            // .. Xử lý dữ liệu
            throw new NotImplementedException();
        }

        public Task<PaginationUtility<DemoDto>> GetDataPagination(PaginationParam pagination, DemoFilter filter)
        {
            // .. Xử lý dữ liệu
            throw new NotImplementedException();
        }

        public Task<KeyValuePair<int, string>> GetDropdown()
        {
            // .. Xử lý dữ liệu
            throw new NotImplementedException();
        }

        public Task<OperationResult> Update(DemoDto dto)
        {
            // .. Xử lý dữ liệu
            throw new NotImplementedException();
        }
    }
}