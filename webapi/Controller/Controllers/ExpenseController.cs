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
    public class ExpenseController : BaseController
    {
        private readonly ExpenseService _expenseService;

        public ExpenseController(ExpenseService expenseService)
        {
            _expenseService = expenseService;
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

                var response = _expenseService.GetAll(Convert.ToInt64(idUser), idWallet);

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

                var response = _expenseService.GetById(Convert.ToInt64(idUser), id);

                return SetResponse(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
    }
}