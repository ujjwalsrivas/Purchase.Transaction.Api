using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Purchase.Transaction.Api.Models;
using Purchase.Transaction.Api.Repositories.Interfaces;

namespace Purchase.Transaction.Api.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly AppDbContext _context;

        public TransactionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<TransactionModel> CreatePurchaseAsync(TransactionModel transactionModel)
        {
            _context.TransactionModels.Add(transactionModel);
            await _context.SaveChangesAsync();
            return transactionModel;
        }

        public async Task<List<TransactionModel>> GetAllPurchaseAsync()
        {
            return await _context.TransactionModels
                                 .AsNoTracking()
                                 .ToListAsync();
        }

        public async Task<TransactionModel?> GetPurchaseAsync(Guid id)
        {
            return await _context.TransactionModels
                                 .AsNoTracking()
                                 .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
