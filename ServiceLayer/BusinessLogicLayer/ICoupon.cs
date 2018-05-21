using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace BusinessLogicLayer
{
    public interface ICoupon
    {
        List<Coupon> AllCpn();
        Coupon GetCouponByID(int ID);
        void AddCpn(Coupon Cpn);
        void UpdateCpn(Coupon Cpn);
        void DeleteCpn(Coupon Cpn);
    }
}