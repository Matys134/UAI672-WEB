using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using UAI672_WEB.Models;

namespace UAI672_WEB.Repositories
{
    public class DetailsRepository : IRepository<Details>
    {
        private readonly Model1 _db;

        public DetailsRepository(Model1 db) => _db = db;

        public IEnumerable<Details> GetAll() => _db.Details.ToList();

        public Details GetById(int id) => _db.Details.Find(id);

        public void Add(Details ob)
        {
            _db.Details.Add(ob);
            _db.SaveChanges();
        }

        public void Update(Details ob)
        {
            _db.Entry(ob).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var detail = _db.Details.Find(id);
            _db.Details.Remove(detail);
            _db.SaveChanges();
        }
    }
}