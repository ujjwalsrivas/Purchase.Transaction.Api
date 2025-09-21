using System;
using Purchase.Transaction.Api.Models;
using Refit;

namespace Purchase.Transaction.Api.Clients;

public interface IFiscalClient
{
    [Get("/services/api/fiscal_service/v1/accounting/od/rates_of_exchange")]
    public Task<FiscalCurrencyModel> GetConvertedCurrency();
}
