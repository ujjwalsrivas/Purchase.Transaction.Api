using System;

namespace Purchase.Transaction.Api.Models;

public class RetrievedPurchaseModel
{
    public Guid Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public DateTime TransactionDate { get; set; }
    public double PurchaseAmount { get; set; }
    public double ExchangeRate { get; set; }
    public double ConvertedAmount { get; set; }
    public string Country { get; set; } = string.Empty;

}

