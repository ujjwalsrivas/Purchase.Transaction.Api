using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Purchase.Transaction.Api.Controllers;
using Purchase.Transaction.Api.Models;
using Purchase.Transaction.Api.Services.Interfaces;
using Xunit;

namespace Purchase.Transaction.Api.Tests.Controllers
{
    public class TransactionControllerTests
    {
        private readonly Mock<ITransactionService> mockService;
        private readonly TransactionController controller;

        public TransactionControllerTests()
        {
            mockService = new Mock<ITransactionService>();
            controller = new TransactionController(mockService.Object);
        }

        [Fact]
        public async Task GetTransactionTest_TransactionPresent()
        {
            // Arrange
            var id = Guid.NewGuid();
            var transaction = new TransactionModel()
            {
                Id = id,
                Description = "Test Purchase",
                PurchaseAmount = 20,
                TransactionDate = new DateTime()
            };

            mockService.Setup(s => s.GetPurchaseAsync(id)).ReturnsAsync(transaction);

            // Act
            var result = await controller.GetTransaction(id);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedTransaction = Assert.IsType<TransactionModel>(okResult.Value);
            Assert.Equal(id, returnedTransaction.Id);
        }

        [Fact]
        public async Task GetTransactionTest_TransactionNotFound()
        {
            // Arrange
            var id = Guid.NewGuid();
            mockService.Setup(s => s.GetPurchaseAsync(id)).ReturnsAsync((TransactionModel?)null);

            // Act
            var result = await controller.GetTransaction(id);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
