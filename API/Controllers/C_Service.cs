using API._Services.Interfaces;
using API.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class C_Service : APIController
    {
        private readonly I_Service _services;
        public C_Service(I_Service services)
        {
            _services = services;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetData([FromQuery] PaginationParam pagination, [FromQuery] ServiceParam param)
        {
            var result = await _services.Getdata(pagination, param);
            return Ok(result);
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] ServiceData model)
        {
            var result = await _services.Create(model);
            return Ok(result);
        }
    }
}