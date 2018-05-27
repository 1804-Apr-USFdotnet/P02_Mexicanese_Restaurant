using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace DataAccessLayer
{
    public interface IOrderCouponRepository
    {
        OrderCoupon GetByID(int ID);
        IEnumerable<OrderCoupon> GetAllOrderCoupons();
        void AddOrderCoupon(OrderCoupon OC);
        void ModifyOrderCoupon(OrderCoupon OC);
        void DeleteOrderCoupon(OrderCoupon OC);
        void SaveOrderCoupons();
    }
}