using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace Purchase.Transaction.Api.Models;

public class TransactionModel
{
    [Key]
    [SwaggerSchema(ReadOnly = true)]
    public Guid Id { get; set; }

    [Required]
    [StringLength(50, ErrorMessage = "Description must not exceed 50 characters")]
    public string Description { get; set; } = string.Empty;

    [Required(ErrorMessage = "Transaction date is required.")]
    public DateTime TransactionDate { get; set; }
    
    [Required(ErrorMessage = "Purchanse Amount is required.")]
    public double PurchaseAmount { get; set; }

}
