using DataAccessLayer.Models;
using DataAccessLayer;
using System.Collections.Generic;
using System.Linq;
using System;

namespace BusinessLogicLayer
{
    public class CustomerInformationLogic : ICustomerInformation
    {
        private readonly ICustomerInformationRepository _CustInfoRepo;
        public CustomerInformationLogic(ICustomerInformationRepository CustInfoRepo)
        {
            _CustInfoRepo = CustInfoRepo;
        }
        public void AddCustInfo(CustomerInformation CustInfo)
        {
            _CustInfoRepo.AddCustomerInformation(CustInfo);
        }

        public List<CustomerInformation> AllCustInfo()
        {
            return _CustInfoRepo.GetAllCustomerInformations().ToList();
        }

        public void DeleteCustInfo(CustomerInformation CustInfo)
        {
            _CustInfoRepo.DeleteCustomerInformation(CustInfo);
        }

        public CustomerInformation GetCustomerInformationByEmail(String email)
        {
            return _CustInfoRepo.GetByEmail(email);
        }

        public void UpdateCustInfo(CustomerInformation CustInfo)
        {
            _CustInfoRepo.ModifyCustomerInformation(CustInfo);
        }
    }
}