using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace DataAccessLayer
{
    public class OrderRepository : IOrderRepository
    {
        private readonly MexicaneseModel _repoContext;
        public OrderRepository(MexicaneseModel context)
        {
            _repoContext = context;
        }

        public Order GetByID(int ID)
        {
            
            return _repoContext.Orders.Find(ID);
        }

        public void AddOrder(Order Odr)
        {
            _repoContext.Orders.Add(Odr);
            _repoContext.SaveChanges();
        }

        public void DeleteOrder(Order Odr)
        {
            var delete = _repoContext.Orders.Find(Odr.OrderID);
            _repoContext.Orders.Remove(delete);
            _repoContext.SaveChanges();
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return _repoContext.Orders;
        }

        public void ModifyOrder(Order Odr)
        {
            var modify = _repoContext.Orders.Find(Odr.OrderID);
            _repoContext.Entry(modify).CurrentValues.SetValues(Odr);
            _repoContext.SaveChanges();
        }

        public void SaveOrders()
        {
            _repoContext.SaveChanges();
        }
    }
}