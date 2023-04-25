using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using UAI672_WEB.Models;

namespace UAI672_WEB.Repositories
{
    public class DetailsRepository : IDetailsRepository
    {
        private Model1 db = new Model1();

        public IEnumerable<Details> GetAllDetails()
        {
            return db.Details.Include(d => d.Addresses).ToList();
        }

        public Details GetDetailsById(int id)
        {
            return db.Details.Find(id);
        }

        public void AddDetails(Details details)
        {
            db.Details.Add(details);
            db.SaveChanges();
        }

        public void UpdateDetails(Details details)
        {
            db.Entry(details).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteDetails(int id)
        {
            Details details = db.Details.Find(id);
            db.Details.Remove(details);
            db.SaveChanges();
        }
    }
}