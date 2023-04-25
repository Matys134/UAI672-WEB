using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using UAI672_WEB.Repositories;

namespace UAI672_WEB.Models
{
    public class AddressRepository : IAddressesRepository
    {
        private readonly Model1 _db;

        public AddressRepository(Model1 db)
        {
            _db = db;
        }

        public List<Addresses> GetAllAddresses()
        {
            return _db.Addresses.ToList();
        }

        public Addresses GetAddressById(int id)
        {
            return _db.Addresses.Find(id);
        }

        public void AddAddress(Addresses address)
        {
            _db.Addresses.Add(address);
            _db.SaveChanges();
        }

        public void UpdateAddress(Addresses address)
        {
            _db.Entry(address).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void DeleteAddress(int id)
        {
            Addresses address = _db.Addresses.Find(id);
            _db.Addresses.Remove(address);
            _db.SaveChanges();
        }
    }
}