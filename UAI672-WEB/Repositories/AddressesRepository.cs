using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using UAI672_WEB.Repositories;

namespace UAI672_WEB.Models
{
    public class AddressRepository : IRepository<Addresses>
    {
        private readonly Model1 _db;

        public AddressRepository(Model1 db) => _db = db;

        public IEnumerable<Addresses> GetAll() => _db.Addresses.ToList();

        public Addresses GetById(int id) => _db.Addresses.Find(id);

        public void Add(Addresses address)
        {
            _db.Addresses.Add(address);
            _db.SaveChanges();
        }

        public void Update(Addresses address)
        {
            _db.Entry(address).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var address = _db.Addresses.Find(id);
            _db.Addresses.Remove(address);
            _db.SaveChanges();
        }
    }
}