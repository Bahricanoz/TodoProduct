using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Todo.Interface;
using Todo.Interface.Repository;

namespace Todo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CurrencyController : ControllerBase
    {
        private readonly ICurrencyService _currencyService;
        public CurrencyController(ICurrencyService currencyService)
        {
            _currencyService = currencyService;
        }
        [HttpGet]
        public IActionResult GetCurrency()
        {
            var data = new { name = "USD", value = 8.5 };
            var dataSerialized = JsonConvert.SerializeObject(data);
            return Ok(dataSerialized);
        }

        [HttpGet("tcmb")]
        public async Task<IActionResult> GetTCMBCurreny(){
            var currency = await _currencyService.GetCurrency();
            return Ok(currency);        
        }
    }
}