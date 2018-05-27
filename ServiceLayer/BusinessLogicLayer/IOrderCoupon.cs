using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace BusinessLogicLayer
{
    public interface IOrderCoupon
    {
        List<OrderCoupon> AllOC();
        OrderCoupon GetOrderCouponByID(int orderId);
        void AddOC(OrderCoupon OC);
        void UpdateOC(OrderCoupon OC);
        void DeleteOC(OrderCoupon OC);
    }
}
