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

        public OrderItemLogic()
        {
            _OdrIRepo = new OrderItemRepository();
        }
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

        public void DeleteOdrI(List<OrderItem> OdrI)
        {
            foreach (var delt in OdrI)
            {
                _OdrIRepo.DeleteOrderItem(delt);
            }
        }

        public MenuItem GetMenuItem(OrderItem odrI)
        {
           return _OdrIRepo.GetMenuItem(odrI);
        }

        public List<OrderItem> GetOrderItemsByID(int ID)
        {
            return _OdrIRepo.GetByID(ID).ToList();
        }

        public void UpdateOdrI(OrderItem OdrI)
        {
            _OdrIRepo.ModifyOrderItem(OdrI);
        }
    }
}