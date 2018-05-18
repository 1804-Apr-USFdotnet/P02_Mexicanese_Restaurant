namespace DataAccessLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PaymentMethod
    {
        [Key]
        [Column(Order = 0)]
        public int id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(255)]
        public string email { get; set; }

        [Required]
        [StringLength(100)]
        public string cardNumber { get; set; }

        [Required]
        [StringLength(10)]
        public string securityCode { get; set; }

        [Column(TypeName = "date")]
        public DateTime expDate { get; set; }
    }
}
