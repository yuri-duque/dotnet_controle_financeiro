using Controller.Utils;
using Domain.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Models;
using System;
using System.Linq;

namespace Controller.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class IncomeController : BaseController
    {
        private readonly IncomeService _incomeService;

        public IncomeController(IncomeService incomeService)
        {
            _incomeService = incomeService;
        }

        [HttpGet("{idWallet}")]
        public ActionResult GetAllByWallet(long idWallet)
        {
            try
            {
                //Pegando o id do usuario pelo token
                long? idUser = GetIdUser();

                if (idUser is null)
                    return NotFound("Usuário não encontrado!");

                var response = _incomeService.GetAll(Convert.ToInt64(idUser), idWallet);

                return SetResponse(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult GetById(long id)
        {
            try
            {
                //Pegando o id do usuario pelo token
                long? idUser = GetIdUser();

                if (idUser is null)
                    return NotFound("Usuário não encontrado!");

                var response = _incomeService.GetById(Convert.ToInt64(idUser), id);

                return SetResponse(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Save(IncomeFormDTO incomeDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState.Values.Select(x => x.Errors.Select(x => x.ErrorMessage)));

                //Pegando o id do usuario pelo token
                long? idUser = GetIdUser();

                if (idUser is null)
                    return NotFound("Usuário não encontrado!");

                var response = _incomeService.Save(Convert.ToUInt16(idUser), incomeDTO);

                return SetResponse(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}