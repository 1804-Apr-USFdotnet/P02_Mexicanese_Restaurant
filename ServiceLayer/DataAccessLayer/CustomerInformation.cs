namespace DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CustomerInformation")]
    public partial class CustomerInformation
    {
        [Key]
        [StringLength(255)]
        public string Email { get; set; }

        [StringLength(100)]
        public string firstName { get; set; }

        [StringLength(100)]
        public string lastName { get; set; }

        [StringLength(100)]
        public string phone { get; set; }

        public virtual User User { get; set; }
    }
}
