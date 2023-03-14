using System.ComponentModel.DataAnnotations;

namespace ShopBuy7.Models
{
    public class OrderDetail
    {
        [Key]
        public int OrderDetailId { get; set; }
        
        public int FkOrderId { get; set; }
        public int FkProductId { get; set; }
        public int Quantity { get; set; }
        public string Note { get; set; } = string.Empty;
    }
}