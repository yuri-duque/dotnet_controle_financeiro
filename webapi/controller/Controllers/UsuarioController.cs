using System;
using System.Linq;
using Domain.DTO;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service;
using Service.Models;

namespace controller.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;

        public UsuarioController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            try
            {
                var usuario = _usuarioService.GetAll();

                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public ActionResult Login(UsuarioLoginDTO userDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState.Values.SelectMany(x => x.Errors));

                var usuario = _usuarioService.Login(userDTO);

                if (usuario == null)
                    return NotFound("Usuário não encontrado!");

                var token = TokenService.GenerateToken(usuario);

                return Ok(new { usuario, token });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Save(UsuarioCadastroDTO user)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState.Values.SelectMany(x => x.Errors));

                bool disponivel = _usuarioService.CheckUsername(user.UserName);
                if (!disponivel)
                    return BadRequest("Username indisponivel");

                _usuarioService.Save(user);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}