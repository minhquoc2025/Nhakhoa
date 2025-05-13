using AgileObjects.AgileMapper;
using API._Repositories;
using API._Services.Interfaces;
using API.DTOs;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API._Services.Services
{
    public class S_Service_Dental : BaseServices, I_Service
    {
        public S_Service_Dental(IRepositoryAccessor repositoryAccessor) : base(repositoryAccessor)
        {
        }
        public async Task<OperationResult> Create(ServiceData model)
        {
            var data = new Service
            {
                service_id = model.Service_id,
                service_name = model.Service_name,
                service_describe = model.Service_describe
            };
            _repositoryAccessor.Service.Add(data);
            try
            {
                await _repositoryAccessor.Save();
                return new OperationResult(true, "Create Success");
            }
            catch (Exception ex)
            {
                var fullError = $"{ex.Message} -- INNER: {ex.InnerException?.Message}";
                return new OperationResult(false, fullError);
            }
        }
        public async Task<PaginationUtility<ServiceData>> Getdata(PaginationParam pagination, ServiceParam param)
        {
            var data = await _repositoryAccessor.Service.FindAll().Project().To<ServiceData>().ToListAsync();
            return PaginationUtility<ServiceData>.Create(data, pagination.PageNumber, pagination.PageSize);
        }
        public async Task<OperationResult> Delete(int service_id)
        {
            var item = _repositoryAccessor.Service.FirstOrDefault(x=>x.service_id == service_id);
            if (item == null)
            {
                return new OperationResult(false, "Item not found");
            }
            _repositoryAccessor.Service.Remove(item);
            await _repositoryAccessor.Save();
            return new OperationResult(true, "Delete Success");
        }
        public async Task<OperationResult> Update(ServiceData model)
        {
            var item = _repositoryAccessor.Service.FirstOrDefault(x => x.service_id == model.Service_id);
            if (item == null)
            {
                return new OperationResult(false, "Item not found");
            }
            item.service_name = model.Service_name;
            item.service_describe = model.Service_describe;
            _repositoryAccessor.Service.Update(item);
            await _repositoryAccessor.Save();
            return new OperationResult(true, "Update Success");
        }
    }
}