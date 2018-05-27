using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace DataAccessLayer
{
    public class CustomerInformationRepository : ICustomerInformationRepository
    {
        private readonly MexicaneseModel _repoContext;
        public CustomerInformationRepository(MexicaneseModel context)
        {
            _repoContext = context;
        }

        public CustomerInformation GetByEmail(String email)
        {
            return _repoContext.CustomerInformations.Find(email);
        }

        public void AddCustomerInformation(CustomerInformation CustInfo)
        {
            _repoContext.CustomerInformations.Add(CustInfo);
            _repoContext.SaveChanges();
        }

        public void DeleteCustomerInformation(CustomerInformation CustInfo)
        {
            var delete = _repoContext.CustomerInformations.Find(CustInfo.Email);
            _repoContext.CustomerInformations.Remove(delete);
            _repoContext.SaveChanges();
        }

        public IEnumerable<CustomerInformation> GetAllCustomerInformations()
        {
            return _repoContext.CustomerInformations;
        }

        public void ModifyCustomerInformation(CustomerInformation CustInfo)
        {
            var modify = _repoContext.CustomerInformations.Find(CustInfo.Email);
            _repoContext.Entry(modify).CurrentValues.SetValues(CustInfo);
            _repoContext.SaveChanges();
        }

        public void SaveCustomerInformations()
        {
            _repoContext.SaveChanges();
        }
    }
}