using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopBuy7.Models
{
    public class Deal
    {
        [Key]
        public int DealId { get; set; }
        public int FkProductId { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public DateTime ExpiryDateTime { get; set; } = Global.SetDateTime();
        public DateTime DateAdded { get; set; } = Global.SetDateTime();

        [NotMapped]
        public Product Product { get; set; } = new();
        [NotMapped]
        public List<ImageModel> Images { get; set; } = new();
        
        [NotMapped]
        public TimeSpan RemainingTime { get; set; } = new();
        [NotMapped]
        public int Sold { get; set; }

    }
}