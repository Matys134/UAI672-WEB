using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using UAI672_WEB.Repositories;

namespace UAI672_WEB.Models
{
    public class AddressRepository : IRepository<Addresses>
    {
        private readonly Model1 _db;

        public AddressRepository(Model1 db) => _db = db;

        public async Task<IEnumerable<Addresses>> GetAllAsync() => await _db.Addresses.ToListAsync();

        public async Task<Addresses> GetByIdAsync(int id) => await _db.Addresses.FindAsync(id);

        public async Task AddAsync(Addresses address)
        {
            _db.Addresses.Add(address);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(Addresses address)
        {
            _db.Entry(address).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var address = await _db.Addresses.FindAsync(id);
            _db.Addresses.Remove(address);
            await _db.SaveChangesAsync();
        }
    }
}