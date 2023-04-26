using System.Collections.Generic;
using UAI672_WEB.Models;

namespace UAI672_WEB.Repositories
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Add(T ob);
        void Update(T ob);
        void Delete(int id);
    }
}