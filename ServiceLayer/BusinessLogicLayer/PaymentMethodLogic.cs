using DataAccessLayer.Models;
using DataAccessLayer;
using System.Collections.Generic;
using System.Linq;
using System;

namespace BusinessLogicLayer
{
    public class PaymentMethodLogic : IPaymentMethod
    {
        private readonly IPaymentMethodRepository _PMRepo;
        public PaymentMethodLogic(IPaymentMethodRepository PMRepo)
        {
            _PMRepo = PMRepo;
        }
        public void AddPM(PaymentMethod PM)
        {
            _PMRepo.AddPaymentMethod(PM);
        }

        public List<PaymentMethod> AllPM()
        {
            return _PMRepo.GetAllPaymentMethodes().ToList();
        }

        public void DeletePM(PaymentMethod PM)
        {
            _PMRepo.DeletePaymentMethod(PM);
        }

        public PaymentMethod GetPaymentMethodByID(int ID)
        {
            return _PMRepo.GetByID(ID);
        }

        public void UpdatePM(PaymentMethod PM)
        {
            _PMRepo.ModifyPaymentMethod(PM);
        }
    }
}