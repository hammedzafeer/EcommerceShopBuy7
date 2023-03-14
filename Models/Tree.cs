using System.ComponentModel.DataAnnotations;

namespace ShopBuy7.Models
{
    public class Tree
    {
        public int TreeId { get; set; }
        public int FkCustomerId { get; set; }
        public int RefferedByCId { get; set; } // who reffered this customer
        public int TreeHeadCId { get; set; } // this customer's three head id,
        public int PackageId { get; set; }
        public DateTime DateAdded { get; set; } = Global.SetDateTime();
        public bool IsVerified { get; set; } = false;
        public DateTime VerificationDate { get; set; } = Global.SetDateTime();
        [MaxLength(20)]
        public string CNIC { get; set; } = string.Empty;
        public string CNICFront { get; set; } = string.Empty;
        public string CNICBack { get; set; } = string.Empty;
    }
}
