using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopBuy7.Models
{
    public partial class Delivery
    {
        [Key]
        public int DeliveryId { get; set; }
        public int FkCustomerId { get; set; }
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        public double Amount { get; set; }
        public string Message { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        public DateTime DateAdded { get; set; } = Global.SetDateTime();
        public bool IsDeleted { get; set; } = false;

        [NotMapped]
        public Customer Customer { get; set; } = new();

    }
}
