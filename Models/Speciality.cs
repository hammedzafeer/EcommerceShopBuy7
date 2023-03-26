using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopBuy7.Models
{
    public partial class Speciality
    {
        [Key]
        public int Id { get; set; }
        public int FkProductId { get; set; }
        [MaxLength(50)]
        public string Name { get; set; } = null!;
    }
}
