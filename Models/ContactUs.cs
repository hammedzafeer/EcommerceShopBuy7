using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopBuy7.Models
{
    public class ContactUs
    {
       
        [Key]
        public int ContactFormId { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public DateTime DateAdded { get; set; } = Global.SetDateTime();

        [NotMapped]
        public string? Date { get; set; }
    }
}
