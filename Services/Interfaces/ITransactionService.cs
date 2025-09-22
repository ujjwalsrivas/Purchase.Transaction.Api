using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Purchase.Transaction.Api.Models;

namespace Purchase.Transaction.Api.Services.Interfaces
{
    public interface ITransactionService
    {
        Task<TransactionModel> CreatePurchaseAsync(TransactionModel transactionModel);
        Task<TransactionModel?> GetPurchaseAsync(Guid id);
        Task<List<TransactionModel>> GetAllPurchaseAsync();
        Task<RetrievedPurchaseModel?> GetConvertedCurrencyAsync(Guid id, string country);
    }
}
