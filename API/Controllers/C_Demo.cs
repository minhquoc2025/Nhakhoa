using API._Services.Interfaces;
using API.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    public class C_Demo : APIController
    {
        private readonly I_Demo _services;
        public C_Demo(I_Demo services)
        {
            _services = services;
        }

        [HttpGet("GetDataPagination")]
        public async Task<IActionResult> GetDataPagination([FromQuery] PaginationParam pagination, [FromQuery] DemoFilter filter)
        {
            var result = await _services.GetDataPagination(pagination, filter);
            return Ok(result);
        }

        [HttpGet("GetDropdown")]
        public async Task<IActionResult> GetDropdown()
        {
            var result = await _services.GetDropdown();
            return Ok(result);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] DemoDto dto)
        {
            var result = await _services.Create(dto);
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] DemoDto dto)
        {
            var result = await _services.Update(dto);
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _services.Delete(id);
            return Ok(result);
        }
    }
}