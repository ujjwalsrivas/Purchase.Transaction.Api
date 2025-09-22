using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Purchase.Transaction.Api.Clients;
using Purchase.Transaction.Api.Repositories;
using Purchase.Transaction.Api.Repositories.Interfaces;
using Purchase.Transaction.Api.Services;
using Purchase.Transaction.Api.Services.Interfaces;
using Refit;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(); 
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Purchase Transaction API",
        Version = "v1",
        Description = "API for managing purchase transactions"
    });
    c.EnableAnnotations(); 
});

builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
builder.Services.AddScoped<ITransactionService, TransactionService>();

builder.Services.AddRefitClient<IFiscalClient>()
    .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://api.fiscaldata.treasury.gov"));

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("PurchaseTransactionDb"));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Purchase Transaction API v1");
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
