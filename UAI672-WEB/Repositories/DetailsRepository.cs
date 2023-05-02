using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using UAI672_WEB.Models;

namespace UAI672_WEB.Repositories
{
    public class DetailsRepository : IRepository<Details>
    {
        private readonly Model1 _db;

        public DetailsRepository(Model1 db) => _db = db;

        public async Task<IEnumerable<Details>> GetAllAsync() => await _db.Details.ToListAsync();

        public async Task<Details> GetByIdAsync(int id) => await _db.Details.FindAsync(id);

        public async Task AddAsync(Details ob)
        {
            _db.Details.Add(ob);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(Details ob)
        {
            _db.Entry(ob).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var detail = await _db.Details.FindAsync(id);
            _db.Details.Remove(detail);
            await _db.SaveChangesAsync();
        }

        public Model1 Get() => _db;
    }
}