using System.ComponentModel.DataAnnotations;

namespace ShopBuy7.Models
{
    public class EmailSubscriber
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Email { get; set; } = string.Empty;
        public bool IsSubscribed { get; set; } = false;
        public DateTime DateAdded { get; set; } = Global.SetDateTime();

    }
}