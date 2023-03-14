using System.ComponentModel.DataAnnotations;

namespace ShopBuy7.Models
{
    public class TransactionHistory
    {
        [Key]
        public int TransactionHistoryId { get; set; }
        [Display(Name = "From")]
        public int FromFkCustomerId { get; set; } 
        [Display(Name = "To")]
        public int ToFkCustomerId { get; set; }
        
        [MaxLength(20)]
        [Display(Name = "Transaction Type")]
        public string TransactionType { get; set; } = string.Empty; // Rank Bouns, Direct Sale, Indirect Sale, member to member transfer, Product purchase, Skipped Bouns
        public double EWallet { get; set; }
        public double SWallet { get; set; }
        public DateTime DateAdded { get; set; } = Global.SetDateTime();
    }
}