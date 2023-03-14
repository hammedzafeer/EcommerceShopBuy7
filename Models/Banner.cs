using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopBuy7.Models
{
    public class Banner
    {
        [Key]
        [DisplayName("Banner Id")]
        public int BannerId { get; set; }
        public int FkCustomerId { get; set; }

        [DisplayName("Mobile ImgUrl")]
        public string MobileImgUrl { get; set; } = string.Empty;

        [DisplayName("Web ImgUrl")]
        public string WebImgUrl { get; set; } = string.Empty ;

        [DisplayName("Landing Link")]
        public string LandingLink { get; set; } = string.Empty ;
        
        [DisplayName("Status")]
        public bool IsActive { get; set; }
        
        [DisplayName("Banner Type")]
        public char BannerType { get; set; } = char.MinValue;
        
        [DisplayName("Date Added")]
        public DateTime DateAdded { get; set; }

        [NotMapped]
        public IFormFile? WebImage { get; set; }

        [NotMapped]
        public IFormFile? MobileImage { get; set; }
    }
}
