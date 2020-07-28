using Microsoft.AspNetCore.Mvc;
using service.Utils;

namespace controller.Utils
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected ActionResult SetResponse(dynamic response)
        {
            if (response.Error)
                return BadRequest(response);

            return Ok(response);
        }
    }
}