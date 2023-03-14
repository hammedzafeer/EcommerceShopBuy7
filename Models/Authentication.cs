using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopBuy7.Models
{
    public class Authentication
    {
        [Key]
        public int AuthenticationId { get; set; }

        [MaxLength(50)]
        public string UserName { get; set; } = string.Empty;

        [MaxLength(256)]
        public string Password { get; set; } = string.Empty; 

        public int FkUserId { get; set; }

        public char UserType { get; set; } = char.MinValue; // c for customer, e for employee,
               
        [NotMapped]
        public Customer Customer { get; set; } = new Customer();
        
        
        [NotMapped]
        public Employee Employee { get; set; } = new Employee();


    }
}
