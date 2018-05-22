using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace DataAccessLayer
{
    public interface ICustomerInformationRepository
    {
        CustomerInformation GetByEmail(String email);
        IEnumerable<CustomerInformation> GetAllCustomerInformations();
        void AddCustomerInformation(CustomerInformation CustInfo);
        void ModifyCustomerInformation(CustomerInformation CustInfo);
        void DeleteCustomerInformation(CustomerInformation CustInfo);
        void SaveCustomerInformations();
    }
}