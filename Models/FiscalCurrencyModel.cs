using System;
using Refit;
using System.Text.Json.Serialization;

namespace Purchase.Transaction.Api.Models;

public class FiscalCurrencyModel
{
    public List<Data> Data { get; set; }
}

public class Data
{
    [AliasAs("record_date")]
    [JsonPropertyName("record_date")]
    public DateTime RecordDate { get; set; }

    [AliasAs("country")]
    [JsonPropertyName("country")]
    public string Country { get; set; } = string.Empty;

    [AliasAs("currency")]
    [JsonPropertyName("currency")]
    public string Currency { get; set; } = string.Empty;

    [AliasAs("exchange_rate")]
    [JsonPropertyName("exchange_rate")]
    public string ExchangeRate { get; set; } = string.Empty;

    [AliasAs("effective_date")]
    [JsonPropertyName("effective_date")]
    public DateTime EffectiveDate { get; set; }
}
