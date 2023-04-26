using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAI672_WEB.Models;
using UAI672_WEB.Repositories;

namespace UAI672_WEB.Services
{
    public interface IService<T>
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Add(T details);
        void Update(T details);
        void Delete(int id);
        IRepository<T> Get();
    }
}
