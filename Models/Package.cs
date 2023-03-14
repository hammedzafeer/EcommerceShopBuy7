using System.ComponentModel.DataAnnotations;

namespace ShopBuy7.Models
{
    public class Package
    {
        public int PackageId { get; set; }
        
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        
        [MaxLength(5)]
        public string ShortName { get; set; } = string.Empty;

        public double Price { get; set; } //in Rupees
        public double PackageExtraProfit { get; set; } // in percentage
        public int PackageDuration { get; set; } = 0; // in Days

    }
}