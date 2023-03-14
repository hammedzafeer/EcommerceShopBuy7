using System.ComponentModel.DataAnnotations;

namespace ShopBuy7.Models
{
    public class AuthenticationLog
    {
        [Key]
        public int LogId { get; set; }

        [Display(Name = "User Id")]
        public int FkUserId { get; set; }

        [Display(Name = "Date Time")]
        public DateTime DateTime { get; set; } = Global.SetDateTime();
        
        [Display(Name = "Status")]
        public bool Status { get; set; } // 0 for log out and 1 for log in
        
        [Display(Name = "User Type")]
        public char UserType { get; set; } // c for customer, e for employee etc
    }
}
