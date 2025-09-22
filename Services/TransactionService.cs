using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Purchase.Transaction.Api.Clients;
using Purchase.Transaction.Api.Models;
using Purchase.Transaction.Api.Repositories.Interfaces;
using Purchase.Transaction.Api.Services.Interfaces;

namespace Purchase.Transaction.Api.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IFiscalClient _fiscalClient;

        public TransactionService(ITransactionRepository transactionRepository, IFiscalClient fiscalClient)
        {
            _transactionRepository = transactionRepository;
            _fiscalClient = fiscalClient;
        }

        public async Task<TransactionModel> CreatePurchaseAsync(TransactionModel transactionModel)
        {
            return await _transactionRepository.CreatePurchaseAsync(transactionModel);
        }

        public async Task<TransactionModel?> GetPurchaseAsync(Guid id)
        {
            return await _transactionRepository.GetPurchaseAsync(id);
        }

        public async Task<List<TransactionModel>> GetAllPurchaseAsync()
        {
            return await _transactionRepository.GetAllPurchaseAsync();
        }

        public async Task<RetrievedPurchaseModel?> GetConvertedCurrencyAsync(Guid id, string country)
        {
            var fiscalResponse = await _fiscalClient.GetConvertedCurrency();
            var purchaseInfo = await _transactionRepository.GetPurchaseAsync(id);

            if (purchaseInfo == null) return null;

            return null;
        }
    }
}
