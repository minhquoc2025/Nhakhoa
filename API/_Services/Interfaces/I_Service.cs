using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;

namespace API._Services.Interfaces
{
    [DependencyInjection(ServiceLifetime.Scoped)]
    public interface I_Service
    {
        Task<OperationResult> Create (ServiceData model);
        Task<PaginationUtility<ServiceData>> Getdata (PaginationParam pagination, ServiceParam param);
    }
}