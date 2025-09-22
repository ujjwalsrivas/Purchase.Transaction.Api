using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Purchase.Transaction.Api.Models;
using Purchase.Transaction.Api.Services.Interfaces;

namespace Purchase.Transaction.Api.Controllers
{
    [Route("api/")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService transactionService;
        public TransactionController(ITransactionService _transactionService)
        {
            this.transactionService = _transactionService;
        }

        [HttpPost]
        [Route("v1/purchaseTransactions")]
        public IActionResult CreateTransaction([FromBody] TransactionModel transactionModel)
        {
            transactionService.CreatePurchaseAsync(transactionModel);
            return Ok(transactionModel.Id);
        }

        [HttpGet]
        [Route("v1/purchaseTransactions")]
        [ProducesResponseType(typeof(List<TransactionModel>), StatusCodes.Status200OK)]
        public IActionResult GetAllTransaction()
        {
            var temp = transactionService.GetAllPurchaseAsync();
            return Ok(temp);
        }
        
        [HttpGet]
        [Route("v1/purchaseTransactions/{id}")]
        [ProducesResponseType(typeof(TransactionModel), StatusCodes.Status200OK)]
        public IActionResult GetTransaction(Guid id)
        {
            var temp = transactionService.GetPurchaseAsync(id);
            return Ok(temp);
        }
    }
}
