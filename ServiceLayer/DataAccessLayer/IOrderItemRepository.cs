using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace DataAccessLayer
{
    public interface IOrderItemRepository
    {
        OrderItem GetByID(int ID);
        IEnumerable<OrderItem> GetAllOrderItems();
        void AddOrderItem(OrderItem OdrI);
        void ModifyOrderItem(OrderItem OdrI);
        void DeleteOrderItem(OrderItem OdrI);
        void SaveOrderItems();
    }
}