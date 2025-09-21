using System;
using Purchase.Transaction.Api.Models;

namespace Purchase.Transaction.Api.Services.Interfaces;

public interface ITransactionService
{
    public Task<TransactionModel> CreatePurchase(TransactionModel transactionModel);
    public Task<TransactionModel> GetPurchase(Guid id);
    public Task<List<TransactionModel>> GetAllPurchase();
    public Task<RetrievedPurchaseModel> GetConvertedCurrency(Guid id, string country);
}
