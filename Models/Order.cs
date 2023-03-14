using System.ComponentModel.DataAnnotations;

namespace ShopBuy7.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        
        public int FkCustomerId { get; set; }
        public int FkCouponId { get; set; }
        public int FkDelievryId { get; set; }

        public double ProductsCharges { get; set; } 
        public double Discount { get; set; } 
        public double Tax { get; set; } 
        public double DeliveryCharges { get; set; }
        
        public bool IsGenerated { get; set; }


        [Display(Name = "Date Added")]
        public DateTime DateAdded { get; set; }

        public char PaymentHolder { get; set; } = 'c'; // c for customer, r for rider,f for forward to business,  o for business owner(restaurant),s for sent to rider, e for employee, d for done( completed setelment)
        public char PaymentType { get; set; } = 'c'; // c for cash, o for online
        public char OrderStatus { get; set; } = 'w'; //  w for waiting, c for cancel, a for accepted, p for waiting for pick up ,o for on the way(handed over to rider),r for reached, d for delivered, ;

        [Display(Name = "Any Note")]
        public string AnyNote { get; set; } = string.Empty;                       
    }
}