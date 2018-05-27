using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WebProject.Models
{
    public class OrderItem
    {        
        public int itemID { get; set; }

       
        public int orderID { get; set; }

        public int quantity { get; set; }

        public virtual MenuItem MenuItem { get; set; }

        public virtual Order Order { get; set; }
    }
}
