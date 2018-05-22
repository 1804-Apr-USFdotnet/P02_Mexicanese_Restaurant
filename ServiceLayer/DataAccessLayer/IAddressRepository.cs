using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace DataAccessLayer
{
    public interface IAddressRepository
    {
        Address GetByID(int ID);
        IEnumerable<Address> GetAllAddresses();
        void AddAddress(Address Addr);
        void ModifyAddress(Address Addr);
        void DeleteAddress(Address Addr);
        void SaveAddresses();
    }
}