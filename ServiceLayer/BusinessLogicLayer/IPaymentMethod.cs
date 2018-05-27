using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace BusinessLogicLayer
{
    public interface IPaymentMethod
    {
        List<PaymentMethod> AllPM();
        List<PaymentMethod> SearchByEmail(string email);
        PaymentMethod GetPaymentMethodByID(int ID);
        void AddPM(PaymentMethod PM);
        void UpdatePM(PaymentMethod PM);
        void DeletePM(PaymentMethod PM);
    }
}