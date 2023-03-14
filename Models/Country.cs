using System.ComponentModel.DataAnnotations;

namespace ShopBuy7.Models
{
    public class Country
    {
        public Country()
        {
            Name = "";
        }
        [Key]
        public int CountryId { get; set; }

        [MaxLength(20)]
        public string Name { get; set; }

        //public ICollection<Shop> Shops { get; set; } = new List<Shop>();

    }
}