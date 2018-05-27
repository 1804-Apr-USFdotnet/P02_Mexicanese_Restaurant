using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace BusinessLogicLayer
{
    public interface IAddress
    {
        List<Address> AllAddr();
        List<Address> SearchByEmail(string email);
        Address GetAddressByID(int ID);
        void AddAddr(Address Addr);
        void UpdateAddr(Address Addr);
        void DeleteAddr(Address Addr);
    }
}