using System;
using Purchase.Transaction.Api.Models;

namespace Purchase.Transaction.Api.Repositories.Interfaces;

public interface ITransactionRepository
{
    public Task<TransactionModel> CreatePurchase(TransactionModel transactionModel);
    public Task<TransactionModel> GetPurchase(Guid id);
    public Task<List<TransactionModel>> GetAllPurchase();
    
}
