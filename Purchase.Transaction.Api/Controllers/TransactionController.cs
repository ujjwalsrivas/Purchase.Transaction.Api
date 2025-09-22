using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Purchase.Transaction.Api.Models;
using Purchase.Transaction.Api.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Purchase.Transaction.Api.Controllers
{
    [Route("api/")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpPost]
        [Route("v1/purchaseTransactions")]
        public async Task<IActionResult> CreateTransaction([FromBody] TransactionModel transactionModel)
        {
            var createdTransaction = await _transactionService.CreatePurchaseAsync(transactionModel);
            return Ok(createdTransaction.Id);
        }

        [HttpGet]
        [Route("v1/purchaseTransactions")]
        [ProducesResponseType(typeof(List<TransactionModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllTransaction()
        {
            var transactions = await _transactionService.GetAllPurchaseAsync();
            return Ok(transactions);
        }

        [HttpGet]
        [Route("v1/purchaseTransactions/{id}")]
        [ProducesResponseType(typeof(TransactionModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetTransaction(Guid id)
        {
            var transaction = await _transactionService.GetPurchaseAsync(id);
            if (transaction == null) return NotFound();
            return Ok(transaction);
        }
    }
}
