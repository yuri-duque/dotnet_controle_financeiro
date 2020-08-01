using Microsoft.AspNetCore.Mvc;

namespace Controller.Utils
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected ActionResult SetResponse(dynamic response)
        {
            if (response.Error)
                return BadRequest(response);

            if (response.Data == null)
                return Ok();

            return Ok(response.Data);
        }
    }
}