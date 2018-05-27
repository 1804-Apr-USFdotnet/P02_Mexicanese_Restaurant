using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace ServiceLayer.Models
{
    public class CustomerInformation
    {
        [Required]
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