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
            var firstResponse = await _fiscalClient.GetConvertedCurrency(
                pageNumber: 1,
                pageSize: 1000
            );

            var tasks = Enumerable.Range(2, firstResponse.Meta.TotalPages - 1)
                .Select(page => _fiscalClient.GetConvertedCurrency(pageNumber: page, pageSize: 1000))
                .ToList();
            var responses = await Task.WhenAll(tasks);
            var allFiscalData = new FiscalCurrencyModel
            {
                Data = firstResponse.Data.Concat(responses.SelectMany(r => r.Data)).ToList(),
                Meta = firstResponse.Meta
            };

            var purchaseInfo = await _transactionRepository.GetPurchaseAsync(id);

            if (allFiscalData == null || purchaseInfo == null) return null;

            return ConvertCurrencyAndMap(allFiscalData, purchaseInfo, country);
        }

        private static RetrievedPurchaseModel ConvertCurrencyAndMap(FiscalCurrencyModel fiscalCurrencyModel, TransactionModel transactionModel, string country)
        {
            var requiredCurrencyModels = fiscalCurrencyModel.Data.FindAll(x => x.Country == country);
            if (requiredCurrencyModels.Count == 0)
            {
                return new RetrievedPurchaseModel();
            }
            var expectedCurrencyRate = requiredCurrencyModels.FirstOrDefault(x => x.EffectiveDate <= transactionModel.TransactionDate)?.ExchangeRate;

            RetrievedPurchaseModel retrievedPurchaseModel = new()
            {
                Id = transactionModel.Id,
                Description = transactionModel.Description,
                TransactionDate = transactionModel.TransactionDate,
                PurchaseAmount = transactionModel.PurchaseAmount,
                ExchangeRate = double.Parse(expectedCurrencyRate),
                ConvertedAmount = transactionModel.PurchaseAmount * double.Parse(expectedCurrencyRate),
                Country = country
            };

            return retrievedPurchaseModel;
        }
    }
}

