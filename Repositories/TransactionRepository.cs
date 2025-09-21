using System;
using Purchase.Transaction.Api.Models;
using Purchase.Transaction.Api.Repositories.Interfaces;
using System.Linq;
using Purchase.Transaction.Api.Clients;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Purchase.Transaction.Api.Repositories;

public class TransactionRepository(AppDbContext _context) : ITransactionRepository
{
    private readonly AppDbContext context = _context;

    public Task<TransactionModel> CreatePurchase(TransactionModel transactionModel)
    {
        this.context.TransactionModels.Add(transactionModel);
        context.SaveChanges();
        return Task.FromResult(transactionModel);
    }

    public Task<List<TransactionModel>> GetAllPurchase()
    {
        var res = context.TransactionModels.ToList();
        return Task.FromResult(res);
    }

    public Task<TransactionModel?> GetPurchase(Guid id)
    {
        return context.TransactionModels.FirstOrDefaultAsync(x => x.Id == id);
    }
}
