using DataAccessLayer.Models;
using DataAccessLayer;
using System.Collections.Generic;
using System.Linq;
using System;

namespace BusinessLogicLayer
{
    public class OrderLogic : IOrder
    {
        private readonly IOrderRepository _OdrRepo;
        public OrderLogic(IOrderRepository OdrRepo)
        {
            _OdrRepo = OdrRepo;
        }
        public void AddOdr(Order Odr)
        {
            _OdrRepo.AddOrder(Odr);
        }

        public List<Order> AllOdr()
        {
            return _OdrRepo.GetAllOrders().ToList();
        }

        public void DeleteOdr(Order Odr)
        {
            _OdrRepo.DeleteOrder(Odr);
        }

        public Order GetOrderByID(int ID)
        {
            return _OdrRepo.GetByID(ID);
        }

        public void UpdateOdr(Order Odr)
        {
            _OdrRepo.ModifyOrder(Odr);
        }
    }
}