using System.ComponentModel.DataAnnotations;

namespace ShopBuy7.Models
{
    public class Review
    {
        [Key]
        [Display(Name = "Review Id")]
        public int ReviewId { get; set; }
        public int FkProductId { get;set; }

        [Display(Name = "Name")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Email")]
        public string Email { get; set; } = string.Empty;

        [Display(Name = "Comment")]
        public string Comment { get; set; } = string.Empty;

        [Display(Name = "Date Time")]
        public DateTime DateAdded { get; set; } = DateTime.Now;

        [Display(Name = "Stars")]
        public int Stars { get; set; } = 0;

    }
}
