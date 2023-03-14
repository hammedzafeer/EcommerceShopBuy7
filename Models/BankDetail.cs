using System.ComponentModel.DataAnnotations;

namespace ShopBuy7.Models
{
    public class BankDetail
    {
        [Key]
        [Display(Name = "Bank Detail Id")]
        public int BankDetailId { get; set; }

        [Display(Name = "User Id")]
        public int UserId { get; set; }
        
        [Display(Name = "User Type")]
        public char UserType { get; set; } // c for customer and e for employee

        [MaxLength(256)]
        [Display(Name = "Bank Name")]
        public string BankName { get; set; } = string.Empty;

        [MaxLength(50)]
        [Display(Name = "Acount Number")]
        public string AccountNo  { get; set; } = string.Empty;

        [MaxLength(50)]
        [Display(Name = "Account Title")]
        public string AccountTitle { get; set; } = string.Empty;

        [MaxLength(50)]
        [Display(Name = "IBAN")]
        public string IBAN { get; set; } = string.Empty;
        
        [MaxLength(256)]
        [Display(Name = "Instructions")]
        public string Instructions { get; set; } = string.Empty;

        public bool IsDeleted { get; set; }
    }
}
