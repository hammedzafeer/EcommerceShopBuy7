using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopBuy7.Models
{
    public class RankAchievement
    {
        [Key]
        public int AchievementId { get; set; }
        public int FkCustomerId { get; set; }
        public int FkRankId { get; set; }
        public DateTime DateAdded { get; set; } = Global.SetDateTime();
        public string Message { get; set; } = string.Empty;

        
    }
}