using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopBuy7.Models
{
    public class Customer
    {
        [Key]
        [Display(Name = "Customer id")]
        public int CustomerId { get; set; }

        [Display(Name = "FkCity id")]
        public int FkCityId { get; set; }

        [MaxLength(50)]
        [Display(Name = "First name")]
        public string FName { get; set; } = string.Empty;

        [MaxLength(50)]
        [Display(Name = "Last name")]
        public string LName { get; set; } = string.Empty;

        [MaxLength(20)]
        [Display(Name = "Primary contact")]
        public string PrimaryContact { get; set; } = string.Empty;
        public DateTime DOB { get; set; }

        [MaxLength(20)]
        [Display(Name = "Secondary contact")]
        public string SecondaryContact { get; set; } = string.Empty;

        [MaxLength(50)]
        [Display(Name = "Email")]
        public string Email { get; set; } = string.Empty;

        [Display(Name = "Profile picture")]
        public string ImgUrl { get; set; } = "NotFound.png";
        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; } = true;
        public bool IsMember { get; set; } = false;

        [Display(Name = "Date Added")]
        public DateTime DateAdded { get; set; } = Global.SetDateTime();

        [NotMapped]
        public IFormFile MyImage { get; set; }
    }
}
