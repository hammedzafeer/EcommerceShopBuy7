using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopBuy7.Models
{
    public class Product
    {
        [Key]
        [Display(Name = "Product Id")]
        public int ProductId { get; set; }

        [Display(Name = "FkCategory Id")]
        public int FkCategoryId { get; set; }

        [Display(Name = "FkSubCategory Id")]
        public int FkSubCategoryId { get; set; }

        [Display(Name = "FkCustomer Id")]
        public int FkCustomerId { get; set; }

        [Display(Name = "FkBrand Id")]
        public int FkBrandId { get; set; }

        [Display(Name = "Made in")]
        [MaxLength(50)]
        public string MadeIn { get; set; } = string.Empty;

        [Display(Name = "Warranty")]
        [MaxLength(50)]
        public string Warranty { get; set; } = string.Empty;

        [MaxLength(256)]
        [Display(Name = "Product Name")]
        public string Name { get; set; } = string.Empty;

        [MaxLength(50)]
        [Display(Name = "Short Name")]
        public string ShortName { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;


        [Display(Name = "Other Detail")]
        public string OtherDetail { get; set; } = string.Empty;

        public bool IsFeatured { get; set; } = false;
        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; } = false;

        [Display(Name = "Date Added")]
        public DateTime DateAdded { get; set; } = Global.SetDateTime();

        [MaxLength(256)]
        public string Note { get; set; } = string.Empty;

        [MaxLength(20)]
        public string PriceUnit { get; set; } = string.Empty;

        [Display(Name = "Quantity Available")]
        public int AvailableQuantity { get; set; } = 0;

        [Display(Name = "Marked Price")]
        public double MarkedPrice { get; set; } = 0;

        [Display(Name = "Selling Price")]
        public double SalePrice { get; set; } = 0;
        public double ProfitPoints { get; set; } = 0;
        public double Weight { get; set; } = 0; //in kg

        [Display(Name = "Product box height")]
        public double Height { get; set; } = 0; //in inch

        [Display(Name = "Product box width")]
        public double Width { get; set; } = 0; //in inch
        public double Tax { get; set; } = 0;
        public string Tags { get; set; } = "";
        public string ImgUrl { get; set; } = "NotFound.png";

        [NotMapped]
        public IFormFile MyImage { get; set; }
        [NotMapped]
        public string CatName { get; set; } = string.Empty;

    }

}
