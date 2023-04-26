using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using UAI672_WEB.Models;

namespace UAI672_WEB.Repositories
{
    public class DetailsRepository : IDetailsRepository
    {
        private readonly Model1 _db;

        public DetailsRepository(Model1 db)
        {
            _db = db;
        }

        public List<Details> GetAllDetails()
        {
            return _db.Details.ToList();
        }

        public Details GetDetailById(int id)
        {
            return _db.Details.Find(id);
        }

        public void AddDetail(Details detail)
        {
            _db.Details.Add(detail);
            _db.SaveChanges();
        }

        public void UpdateDetail(Details detail)
        {
            _db.Entry(detail).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void DeleteDetail(int id)
        {
            var detail = _db.Details.Find(id);
            _db.Details.Remove(detail);
            _db.SaveChanges();
        }
    }
}