using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Purchase.Transaction.Api.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace Purchase.Transaction.Api.Controllers
{
    [Route("api/")]
    [ApiController]
    public class CurrencyConverterController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public CurrencyConverterController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet]
        [Route("v1/currencyConverter/{id}/country/{country}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetConvertedCurrency(Guid id, string country)
        {
            var result = await _transactionService.GetConvertedCurrencyAsync(id, country);

            if (result == null || result.Description == "")
                return BadRequest("Purchase cannot be converted to target currency.");

            return Ok(result);
        }
    }
}
