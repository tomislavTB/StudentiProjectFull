using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace PubQuiz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppController : ControllerBase
    {
        protected IActionResult ApiOk()
        {
            return ApiOk(HttpStatusCode.OK, null);
        }

        protected IActionResult ApiOk(object data)
        {
            return ApiOk(HttpStatusCode.OK, data);
        }

        protected IActionResult ApiOk(HttpStatusCode code, object data)
        {
            return Ok(PubQuiz.ApiResponse.ApiResponse.Ok(code, data));
        }
    }
}
