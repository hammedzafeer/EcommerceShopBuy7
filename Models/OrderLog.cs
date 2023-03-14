using System.ComponentModel.DataAnnotations;

namespace ShopBuy7.Models
{
    public class OrderLog
    {
        [Key]
        public int LogId { get; set; }
        public int OrderId { get; set; }

        [Display(Name = "Date Time")]
        public DateTime DateTime { get; set; } = Global.SetDateTime();

        [Display(Name = "Message")]
        public string Message { get; set; } = "";
    }
}
