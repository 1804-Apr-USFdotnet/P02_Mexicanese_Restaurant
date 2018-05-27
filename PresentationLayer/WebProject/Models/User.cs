﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebProject.Models
{
    public class User
    {
        [Required]
        [StringLength(255)]
        public string Email { get; set; }

        [Required]
        [StringLength(255)]
        public string Pwd { get; set; }


        public int AccessLevel { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Address> Addresses { get; set; }

        public virtual CustomerInformation CustomerInformation { get; set; }

    }
}