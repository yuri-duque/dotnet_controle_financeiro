using System;
using System.Linq;
using Controller.Utils;
using Domain.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Models;

namespace Controller.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : BaseController
    {
        private readonly UsuarioService _usuarioService;

        public UserController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]

        [HttpPost("login")]
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
        
        [AllowAnonymous]
        public ActionResult Login(UserLoginDTO userDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState.Values.SelectMany(x => x.Errors));

                var response = _usuarioService.Login(userDTO);                               

                return SetResponse(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Save(UserRegisterDTO user)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState.Values.Select(x => x.Errors.Select(x => x.ErrorMessage)));

                var response = _usuarioService.Save(user);

                return SetResponse(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}