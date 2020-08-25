using Controller.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Models;
using System;

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
    }
}