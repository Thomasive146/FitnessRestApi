using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FitnessRestApi.Controllers
{
    [Route("azure")]
    [ApiController]
    public class AzureTestController : ControllerBase
    {
        [HttpGet("test")]
        public ActionResult<string> Get()
        {
            return Ok("Azure test endpoint is working!");
        }
    }
}
