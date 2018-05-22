using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace DataAccessLayer
{
    public class PaymentMethodRepository : IPaymentMethodRepository
    {
        private readonly MexicaneseModel _repoContext;
        public PaymentMethodRepository(MexicaneseModel context)
        {
            _repoContext = context;
        }

        public PaymentMethod GetByID(int ID)
        {
            return _repoContext.PaymentMethods.Find(ID);
        }

        public void AddPaymentMethod(PaymentMethod PM)
        {
            _repoContext.PaymentMethods.Add(PM);
            _repoContext.SaveChanges();
        }

        public void DeletePaymentMethod(PaymentMethod PM)
        {
            var delete = _repoContext.PaymentMethods.Find(PM.id);
            _repoContext.PaymentMethods.Remove(delete);
            _repoContext.SaveChanges();
        }

        public IEnumerable<PaymentMethod> GetAllPaymentMethodes()
        {
            return _repoContext.PaymentMethods;
        }

        public void ModifyPaymentMethod(PaymentMethod PM)
        {
            var modify = _repoContext.PaymentMethods.Find(PM.id);
            _repoContext.Entry(modify).CurrentValues.SetValues(PM);
            _repoContext.SaveChanges();
        }

        public void SavePaymentMethodes()
        {
            _repoContext.SaveChanges();
        }
    }
}