using DataAccessLayer.Models;
using DataAccessLayer;
using System.Collections.Generic;
using System.Linq;
using System;

namespace BusinessLogicLayer
{
    public class CouponLogic : ICoupon
    {
        private readonly ICouponRepository _CpnRepo;
        public CouponLogic(ICouponRepository CpnRepo)
        {
            _CpnRepo = CpnRepo;
        }
        public void AddCpn(Coupon Cpn)
        {
            _CpnRepo.AddCoupon(Cpn);
        }

        public List<Coupon> AllCpn()
        {
            return _CpnRepo.GetAllCoupons().ToList();
        }

        public void DeleteCpn(Coupon Cpn)
        {
            _CpnRepo.DeleteCoupon(Cpn);
        }

        public Coupon GetCouponByID(int ID)
        {
            return _CpnRepo.GetByID(ID);
        }

        public void UpdateCpn(Coupon Cpn)
        {
            _CpnRepo.ModifyCoupon(Cpn);
        }
    }
}