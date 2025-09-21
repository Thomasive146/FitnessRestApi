using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FitnessRestApi.Controllers
{
    [Route("test")]
    [ApiController]
    public class TestController : ControllerBase
    {

        [Authorize(Roles = "Admin")]
        [HttpGet("test")]
        public ActionResult<string> GetAdminStats()
        {
            return Ok("Only admins can see this");
        }
    }
}
