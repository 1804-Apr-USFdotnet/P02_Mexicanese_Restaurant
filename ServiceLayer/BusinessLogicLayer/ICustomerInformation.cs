using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace BusinessLogicLayer
{
    public interface ICustomerInformation
    {
        List<CustomerInformation> AllCustInfo();
        CustomerInformation GetCustomerInformationByEmail(String email);
        void AddCustInfo(CustomerInformation CustInfo);
        void UpdateCustInfo(CustomerInformation CustInfo);
        void DeleteCustInfo(CustomerInformation CustInfo);
    }
}