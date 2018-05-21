using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace DataAccessLayer
{
    public interface IOrderRepository
    {
        Order GetByID(int ID);
        IEnumerable<Order> GetAllOrders();
        void AddOrder(Order Odr);
        void ModifyOrder(Order Odr);
        void DeleteOrder(Order Odr);
        void SaveOrders();
    }
}