using System.ComponentModel.DataAnnotations;

namespace ShopBuy7.Models
{
    public class Employee
    {
        [Key]
        public int EmpId { get; set; }
        public int FkDepartmentId { get; set; }

        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(20)]
        public string Contact { get; set; } = string.Empty;

        [MaxLength(20)]
        public string Email { get; set; } = string.Empty;

        public bool IsActive { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DOB { get; set; }

        [Display(Name = "Profile picture")]
        public string ImgUrl { get; set; } = "NotFound.png";

    }
}