using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace DataAccessLayer
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly MexicaneseModel _repoContext;

        public OrderItemRepository()
        {
            _repoContext = new MexicaneseModel();

        }

        public OrderItemRepository(MexicaneseModel context)
        {
            _repoContext = context;
            
        }

        public IEnumerable<OrderItem> GetByID(int orderID)
        {
            return _repoContext.OrderItems.Where(x=>x.orderID == orderID);
        }

        public MenuItem GetMenuItem(OrderItem item)
        {
            return _repoContext.MenuItems.Find(item.itemID);
        }

        public void AddOrderItem(OrderItem OdrI)
        {
            _repoContext.OrderItems.Add(OdrI);
            _repoContext.SaveChanges();
        }

        public void DeleteOrderItem(OrderItem OdrI)
        {
            var delete = _repoContext.OrderItems.Find(OdrI.orderID);
            _repoContext.OrderItems.Remove(delete);
            _repoContext.SaveChanges();
        }

        public IEnumerable<OrderItem> GetAllOrderItems()
        {
            return _repoContext.OrderItems;
        }

        public void ModifyOrderItem(OrderItem OdrI)
        {
            var modify = _repoContext.OrderItems.Find(OdrI.orderID);
            _repoContext.Entry(modify).CurrentValues.SetValues(OdrI);
            _repoContext.SaveChanges();
        }

        public void SaveOrderItems()
        {
            _repoContext.SaveChanges();
        }
    }
}