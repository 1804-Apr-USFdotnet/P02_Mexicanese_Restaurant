using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace BusinessLogicLayer
{
    public interface IOrder
    {
        List<Order> AllOdr();
        Order GetOrderByID(int ID);
        void AddOdr(Order Odr);
        void UpdateOdr(Order Odr);
        void DeleteOdr(Order Odr);
    }
}