using Microsoft.AspNetCore.Mvc;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

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

        public string GetToken()
        {
            var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault();

            if (string.IsNullOrEmpty(token))
                return null;

            token = token.Replace("Bearer", "").Trim();

            return token;
        }

        public long? GetIdUser()
        {
            try
            {
                var token = GetToken();

                if (string.IsNullOrEmpty(token))
                    return null;

                var handler = new JwtSecurityTokenHandler();
                var jwtToken = handler.ReadToken(token) as JwtSecurityToken;
                var idUser = jwtToken.Claims.First(claim => claim.Type == "nameid").Value;

                return Convert.ToInt64(idUser);
            }
            catch
            {
                return null;
            }
        }
    }
}