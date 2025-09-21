using Microsoft.EntityFrameworkCore;
using Purchase.Transaction.Api.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<TransactionModel> TransactionModels { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<TransactionModel>()
            .Property(t => t.Id)
            .ValueGeneratedOnAdd(); 
    }
}
