using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Purchase.Transaction.Api.Models;

namespace Purchase.Transaction.Api.Repositories.Interfaces
{
    public interface ITransactionRepository
    {
        Task<TransactionModel> CreatePurchaseAsync(TransactionModel transactionModel);
        Task<TransactionModel?> GetPurchaseAsync(Guid id);
        Task<List<TransactionModel>> GetAllPurchaseAsync();
    }
}
