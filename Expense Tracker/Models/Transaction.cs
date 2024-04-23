using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Expense_Tracker.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Amount should be greater than 0.")]
        public int Amount { get; set; }

        [Column(TypeName = "nvarchar(75)")]
        public string? Note { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;

        public Category? category { get; set; }

        [Range(1, int.MaxValue,ErrorMessage ="Please select a category.")]
        public int CategoryId { get; set; }

        [NotMapped]
        public string? CategoryTitleWithIcon 
        {
            get
            {
                return category == null ? " " : category.Icon + " " +category.Title;
            }
        
        }

        [NotMapped]
        public string? FormattedAmount
        {
            get
            {
                return ((category == null || category.Type=="Expense")? "- " :"+ ")+Amount.ToString("₹0");
            }

        }

    }
}
