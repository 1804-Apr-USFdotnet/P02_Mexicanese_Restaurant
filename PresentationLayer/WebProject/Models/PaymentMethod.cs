using System;

namespace WebProject.Models
{
    public class PaymentMethod
    {
        public int id { get; set; }

        public string email { get; set; }

        public string cardNumber { get; set; }

        public string securityCode { get; set; }

        public DateTime expDate { get; set; }

        public string toString()
        {
            return string.Format("CardNumber:" +cardNumber + " " + "CRV:" + securityCode + " " + expDate.ToString());
        }
    }

}