using System.ComponentModel.DataAnnotations;

namespace ShopBuy7.Models
{
    public class ImageModel
    {
        [Key]
        [Display(Name = "Image Id")]
        public int ImageId { get; set; }

        [Display(Name = "FkProduct Id")]
        public int FkProductId { get; set; }      

        public string ImgUrl { get; set; } = string.Empty;
    }
}
