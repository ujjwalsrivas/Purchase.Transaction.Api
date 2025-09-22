using System;
using Purchase.Transaction.Api.Models;
using Refit;

namespace Purchase.Transaction.Api.Clients;

public interface IFiscalClient
{
    [Get("/services/api/fiscal_service/v1/accounting/od/rates_of_exchange?sort=-record_date&format=json")]
    public Task<FiscalCurrencyModel> GetConvertedCurrency(
        [AliasAs("page[number]")] int pageNumber,
        [AliasAs("page[size]")] int pageSize);
}
