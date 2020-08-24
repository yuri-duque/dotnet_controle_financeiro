using Controller.Utils;
using Microsoft.AspNetCore.Mvc;
using Service.Models;

namespace Controller.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncomeController : BaseController
    {
        private readonly IncomeService _incomeService;

        public IncomeController(IncomeService incomeService)
        {
            _incomeService = incomeService;
        }
    }
}