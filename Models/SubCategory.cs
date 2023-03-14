using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopBuy7.Models
{
    public class SubCategory
    {
        
        [Key]
        [Display(Name = "SubCategory Id")]
        public int SubCategoryId { get; set; }
        public int FkCategoryId { get; set; }
        public int FkSubCategoryId { get; set; }
        public bool IsDeleted { get; set; }

        [MaxLength(50)]
        [Display(Name = "Name")]
        public string Name { get; set; } = string.Empty;

        [NotMapped]
        public string SubCatName { get; set; } = string.Empty;
    }
}
