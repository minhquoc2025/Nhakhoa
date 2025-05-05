using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    // [Authorize]
    public class APIController : ControllerBase
    {
        // protected string UserName => (HttpContext.User.Identity as ClaimsIdentity).FindFirst(ClaimTypes.NameIdentifier).Value;

        protected DateTime CurrentTime;

        // protected List<string> roleList => (HttpContext.User.Identity as ClaimsIdentity).FindAll(ClaimTypes.Role).Select(x => x.Value).ToList();
    }
}