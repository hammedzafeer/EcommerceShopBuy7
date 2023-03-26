using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopBuy7.Models
{
    public class Rank
    {
        [Key]
        public int RankId { get; set; }
        [MaxLength(50)]
        [Display(Name ="Rank Name")]
        public string Name { get; set; } = string.Empty;
        [Display(Name ="Gift Name")]
        public string Gift { get; set; } = string.Empty;        
        [Display(Name ="Gift Amount")]
        public double GiftPrice { get; set; } = 0;        
        [Display(Name ="Gift Image")]
        public string GiftImgUrl { get; set; } = string.Empty;        
        [Display(Name ="Rank Image")]
        public string ImgUrl { get; set; } = string.Empty;
        [Display(Name ="Check if rank is permanent")]
        public bool Type { get; set; } = true; // 1 for permanat ranks and 0 for weekly or monthly ranks 
        public bool IsActive { get; set; } = true;
        [Display(Name = "Starting Date")]
        public DateTime StartDate { get; set; } = Global.SetDateTime(); // Starting date for this rank
        public DateTime DateAdded { get; set; } = Global.SetDateTime(); 
        [Display(Name ="Time duration in days")]
        public int TimeDuration { get; set; } = 0; // max no of days for this rank
        [Display(Name = "Direct Referels Condition")]
        public int Condition1DirectReferels { get; set; } = 0;
        [Display(Name = "Indirect Referels Condition")]
        public int Condition2IndirectReferels { get; set; } = 0;
        [Display(Name = "PV Condition")]
        public double Condition3PV { get; set; } = 0;


        [NotMapped]
        public IFormFile MyImage { get; set; }
        [NotMapped]
        public IFormFile GiftImage { get; set; }
    }
}