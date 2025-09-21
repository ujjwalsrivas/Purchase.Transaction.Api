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



/*
The retrieved purchase should include the identifier, the description, the transaction date, the original US dollar purchase
amount, the exchange rate used, and the converted amount based upon the specified currency’s exchange rate for the
date of the purchase.

*/