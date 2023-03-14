using System.ComponentModel.DataAnnotations;

namespace ShopBuy7.Models
{
    public class City
    {
        [Key]
        public int CityId { get; set; }
        public int FkCountryId { get; set; }

        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

    }
}