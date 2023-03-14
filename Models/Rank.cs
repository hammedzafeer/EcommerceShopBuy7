using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopBuy7.Models
{
    public class Rank
    {
        [Key]
        public int RankId { get; set; }
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        public string Gift { get; set; } = string.Empty;        
        public double GiftPrice { get; set; } = 0;        
        public string GiftImgUrl { get; set; } = string.Empty;        
        public string ImgUrl { get; set; } = string.Empty;        
        public bool Type { get; set; } = true; // 1 for permanat ranks and 0 for weekly or monthly ranks 
        public bool IsActive { get; set; } = true;
        public DateTime StartDate { get; set; } = DateTime.Now; // Starting date for this rank
        [Display(Name ="Time duration in days")]
        public int TimeDuration { get; set; } = 0; // max no of days for this rank
        public int Condition1DirectReferels { get; set; } = 0;
        public int Condition2IndirectReferels { get; set; } = 0;
        public double Condition3PV { get; set; } = 0;


        [NotMapped]
        public IFormFile? MyImage { get; set; }
        [NotMapped]
        public IFormFile? GiftImage { get; set; }
    }
}