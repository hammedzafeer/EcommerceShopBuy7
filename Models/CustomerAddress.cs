using System.ComponentModel.DataAnnotations;

namespace ShopBuy7.Models
{
    public class CustomerAddress
    {
        [Key]
        public int AddressId { get; set; }
        public int FkCustomerId { get; set; }
        public string Address { get; set; } = string.Empty;
        public string LandMark { get; set; } = string.Empty;
    }
}
