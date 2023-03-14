using System.ComponentModel.DataAnnotations;

namespace ShopBuy7.Models
{
    public class Coupon
    {
        [Key]
        [Display(Name = "Coupon Id")]
        public int CouponId { get; set; }
        
        [Display(Name = "FkProduct Id")]
        public int FkProductId { get; set; }

        [Display(Name = "Coupon Name")]
        [MaxLength(50)]
        public string CouponName { get; set; } = string.Empty;

        [Display(Name = "Coupon Code")]
        [MaxLength(20)]
        public string CouponCode { get; set; } = string.Empty;

        [Display(Name = "Status")]
        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; } = false;

        [Display(Name = "Discount Type")] //0 for Fixed and 1 for percentage
        public bool DiscountType { get; set; } = false;

        [Display(Name = "Discount Value")]
        public double DiscountValue { get; set; } = double.MinValue;

        [Display(Name = "Date Added")]
        public DateTime DateAdded { get; set; } = Global.SetDateTime();

        [Display(Name = "Starting Date")]
        public DateTime StartingDate { get; set; } = Global.SetDateTime();

        [Display(Name = "Ending Date")]
        public DateTime EndingDate { get; set; } = Global.SetDateTime().AddDays(5);
    }
}
