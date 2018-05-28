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
        IEnumerable<OrderItem> GetByID(int ID);
        IEnumerable<OrderItem> GetAllOrderItems();
        // Because of LazyLoading, I have to explictly ask for it
        // 'thems are the rules we play by'.
        MenuItem GetMenuItem(OrderItem ordI); 
        void AddOrderItem(OrderItem OdrI);
        void ModifyOrderItem(OrderItem OdrI);
        void DeleteOrderItem(OrderItem OdrI);
        void SaveOrderItems();
    }
}