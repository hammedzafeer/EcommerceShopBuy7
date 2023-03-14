using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopBuy7.Models
{
    public class Category
    {
        
        [Key]
        [Display(Name = "Category Id")]
        public int CategoryId { get; set; }

        [MaxLength(50)]
        [Display(Name = "Name")]
        public string Name { get; set; } = string.Empty;

        public string ImgUrl { get; set; } = "NotFound.png";
        public bool IsDeleted { get; set; }

        [NotMapped]
        public IFormFile? MyImage { get;set; }
    }
}
