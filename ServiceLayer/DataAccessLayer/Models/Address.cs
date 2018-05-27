namespace DataAccessLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Address
    {
        public int id { get; set; }

        [Required]
        [StringLength(255)]
        public string email { get; set; }

        [Column("address")]
        [Required]
        [StringLength(255)]
        public string address1 { get; set; }

        [Required]
        [StringLength(255)]
        public string city { get; set; }

        [Required]
        [StringLength(100)]
        public string state { get; set; }

        [Required]
        [StringLength(20)]
        public string zipcode { get; set; }
    }
}
