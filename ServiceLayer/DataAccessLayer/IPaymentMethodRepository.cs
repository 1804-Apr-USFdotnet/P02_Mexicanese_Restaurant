using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace DataAccessLayer
{
    public interface IPaymentMethodRepository
    {
        PaymentMethod GetByID(int ID);
        IEnumerable<PaymentMethod> GetAllPaymentMethodes();
        IEnumerable<PaymentMethod> SearchByEmail(String email);
        void AddPaymentMethod(PaymentMethod PM);
        void ModifyPaymentMethod(PaymentMethod PM);
        void DeletePaymentMethod(PaymentMethod PM);
        void SavePaymentMethodes();
    }
}