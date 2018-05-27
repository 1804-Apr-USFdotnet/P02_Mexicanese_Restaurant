using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace BusinessLogicLayer
{
    public interface IOrderItem
    {
        List<OrderItem> AllOdrI();
        OrderItem GetOrderItemByID(int orderId);
        void AddOdrI(OrderItem OdrI);
        void UpdateOdrI(OrderItem OdrI);
        void DeleteOdrI(OrderItem OdrI);
    }
}