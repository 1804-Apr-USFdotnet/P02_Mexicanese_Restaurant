using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace DataAccessLayer
{
    public class OrderCouponRepository : IOrderCouponRepository
    {
        private readonly MexicaneseModel _repoContext;
        public OrderCouponRepository(MexicaneseModel context)
        {
            _repoContext = context;
        }

        public OrderCoupon GetByID(int orderID)
        {
            return _repoContext.OrderCoupons.Find(orderID);
        }

        public void AddOrderCoupon(OrderCoupon OC)
        {
            _repoContext.OrderCoupons.Add(OC);
            _repoContext.SaveChanges();
        }

        public void DeleteOrderCoupon(OrderCoupon OC)
        {
            var delete = _repoContext.OrderCoupons.Find(OC.orderId);
            _repoContext.OrderCoupons.Remove(delete);
            _repoContext.SaveChanges();
        }

        public IEnumerable<OrderCoupon> GetAllOrderCoupons()
        {
            return _repoContext.OrderCoupons;
        }

        public void ModifyOrderCoupon(OrderCoupon OC)
        {
            var modify = _repoContext.OrderCoupons.Find(OC.orderId);
            _repoContext.Entry(modify).CurrentValues.SetValues(OC);
            _repoContext.SaveChanges();
        }

        public void SaveOrderCoupons()
        {
            _repoContext.SaveChanges();
        }
    }
}