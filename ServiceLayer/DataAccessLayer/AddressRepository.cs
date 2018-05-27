using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace DataAccessLayer
{
    public class AddressRepository : IAddressRepository
    {
        private readonly MexicaneseModel _repoContext;
        
        public AddressRepository(MexicaneseModel context)
        {
            _repoContext = context;
        }

        public Address GetByID(int ID)
        {
            return _repoContext.Addresses.Find(ID);
        }

        public IEnumerable<Address> SearchByEmail(string email)
        {
            return _repoContext.Addresses.Where(x => x.email == email);
        }

        public void AddAddress(Address Addr)
        {
            _repoContext.Addresses.Add(Addr);
            _repoContext.SaveChanges();
        }

        public void DeleteAddress(Address Addr)
        {
            var delete = _repoContext.Addresses.Find(Addr.id);
            _repoContext.Addresses.Remove(delete);
            _repoContext.SaveChanges();
        }

        public IEnumerable<Address> GetAllAddresses()
        {
            return _repoContext.Addresses;
        }

        public void ModifyAddress(Address Addr)
        {
            var modify = _repoContext.Addresses.Find(Addr.id);
            _repoContext.Entry(modify).CurrentValues.SetValues(Addr);
            _repoContext.SaveChanges();
        }

        public void SaveAddresses()
        {
            _repoContext.SaveChanges();
        }
    }
}