using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopBuy7.Models
{
    public class Brand
    {
        [Key]
        public int BrandId { get; set; }

        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        public string Logo { get; set; } = string.Empty;
        public bool IsDeleted { get; set; }

        [NotMapped]
        public IFormFile MyImage { get; set;}

    }
}