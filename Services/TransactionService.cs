using System;
using Purchase.Transaction.Api.Clients;
using Purchase.Transaction.Api.Models;
using Purchase.Transaction.Api.Repositories.Interfaces;
using Purchase.Transaction.Api.Services.Interfaces; 

namespace Purchase.Transaction.Api.Services;

public class TransactionService(ITransactionRepository transactionRepository, IFiscalClient fiscalClient) : ITransactionService
{
    private readonly ITransactionRepository _transactionRepository = transactionRepository;
    private readonly IFiscalClient _fiscalClient = fiscalClient;

    public async Task<TransactionModel> CreatePurchase(TransactionModel transactionModel)
    {
        return await _transactionRepository.CreatePurchase(transactionModel);
    }


    public async Task<TransactionModel> GetPurchase(Guid id)
    {
        return await _transactionRepository.GetPurchase(id);
    }

    public async Task<List<TransactionModel>> GetAllPurchase()
    {
        return await _transactionRepository.GetAllPurchase();
    }

    public async Task<RetrievedPurchaseModel> GetConvertedCurrency(Guid id, string country)
    {
        var fiscalResponse = await _fiscalClient.GetConvertedCurrency();
        var purchaseInfo = await _transactionRepository.GetPurchase(id);

        return null;
    }

    
}
