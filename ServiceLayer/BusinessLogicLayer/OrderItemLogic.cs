using DataAccessLayer.Models;
using DataAccessLayer;
using System.Collections.Generic;
using System.Linq;
using System;

namespace BusinessLogicLayer
{
    public class OrderItemLogic : IOrderItem
    {
        private readonly IOrderItemRepository _OdrIRepo;
        public OrderItemLogic(IOrderItemRepository OdrIRepo)
        {
            _OdrIRepo = OdrIRepo;
        }
        public void AddOdrI(OrderItem OdrI)
        {
            _OdrIRepo.AddOrderItem(OdrI);
        }

        public List<OrderItem> AllOdrI()
        {
            return _OdrIRepo.GetAllOrderItems().ToList();
        }

        public void DeleteOdrI(OrderItem OdrI)
        {
            _OdrIRepo.DeleteOrderItem(OdrI);
        }

        public OrderItem GetOrderItemByID(int ID)
        {
            return _OdrIRepo.GetByID(ID);
        }

        public void UpdateOdrI(OrderItem OdrI)
        {
            _OdrIRepo.ModifyOrderItem(OdrI);
        }
    }
}