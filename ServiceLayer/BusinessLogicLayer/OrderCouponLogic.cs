using DataAccessLayer.Models;
using DataAccessLayer;
using System.Collections.Generic;
using System.Linq;
using System;

namespace BusinessLogicLayer
{
    public class OrderCouponLogic : IOrderCoupon
    {
        private readonly IOrderCouponRepository _OCRepo;
        public OrderCouponLogic(IOrderCouponRepository OCRepo)
        {
            _OCRepo = OCRepo;
        }
        public void AddOC(OrderCoupon OC)
        {
            _OCRepo.AddOrderCoupon(OC);
        }

        public List<OrderCoupon> AllOC()
        {
            return _OCRepo.GetAllOrderCoupons().ToList();
        }

        public void DeleteOC(OrderCoupon OC)
        {
            _OCRepo.DeleteOrderCoupon(OC);
        }

        public OrderCoupon GetOrderCouponByID(int ID)
        {
            return _OCRepo.GetByID(ID);
        }

        public void UpdateOC(OrderCoupon OC)
        {
            _OCRepo.ModifyOrderCoupon(OC);
        }
    }
}