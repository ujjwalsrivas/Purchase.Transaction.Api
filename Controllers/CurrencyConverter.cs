using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Purchase.Transaction.Api.Services.Interfaces;

namespace Purchase.Transaction.Api.Controllers
{
    [Route("api/")]
    [ApiController]
    public class CurrencyConverter(ITransactionService transactionService) : ControllerBase
    {
        private readonly ITransactionService transactionService = transactionService;

        [HttpGet]
        [Route("v1/currencyConverter/{id}/country/{country}")]
        public IActionResult GetConvertedCurrency(Guid id, string country) {
            return Ok(transactionService.GetConvertedCurrency(id, country));
        }
    }
}
