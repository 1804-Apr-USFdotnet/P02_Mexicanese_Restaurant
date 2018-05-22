using DataAccessLayer.Models;
using DataAccessLayer;
using System.Collections.Generic;
using System.Linq;
using System;

namespace BusinessLogicLayer
{
    public class AddressLogic : IAddress
    {
        private readonly IAddressRepository _AddrRepo;
        public AddressLogic(IAddressRepository AddrRepo)
        {
            _AddrRepo = AddrRepo;
        }
        public void AddAddr(Address Addr)
        {
            _AddrRepo.AddAddress(Addr);
        }

        public List<Address> AllAddr()
        {
            return _AddrRepo.GetAllAddresses().ToList();
        }

        public void DeleteAddr(Address Addr)
        {
            _AddrRepo.DeleteAddress(Addr);
        }

        public Address GetAddressByID(int ID)
        {
            return _AddrRepo.GetByID(ID);
        }

        public void UpdateAddr(Address Addr)
        {
            _AddrRepo.ModifyAddress(Addr);
        }
    }
}