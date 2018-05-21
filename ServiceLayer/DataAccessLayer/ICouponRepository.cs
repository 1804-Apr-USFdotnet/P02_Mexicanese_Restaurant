using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace DataAccessLayer
{
    public interface ICouponRepository
    {
        Coupon GetByID(int ID);
        IEnumerable<Coupon> GetAllCoupons();
        void AddCoupon(Coupon Odr);
        void ModifyCoupon(Coupon Odr);
        void DeleteCoupon(Coupon Odr);
        void SaveCoupons();
    }
}