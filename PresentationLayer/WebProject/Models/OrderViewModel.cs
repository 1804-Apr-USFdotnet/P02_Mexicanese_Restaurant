using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebProject.Models
{
    public class OrderViewModel
    {
        public Order order { get; set; }
        public PaymentMethod payment { get; set; }
        public Address address { get; set; }

        public decimal total => getTotal();

        private decimal getTotal()
        {
            decimal order_total = 0;
            foreach (var x in order.OrderItems)
            {
                order_total += x.MenuItem.itemPrice;
            }

            return order_total;
        }
    }
}