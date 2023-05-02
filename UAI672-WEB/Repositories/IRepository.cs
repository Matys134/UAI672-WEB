using System.Collections.Generic;
using System.Threading.Tasks;
using UAI672_WEB.Models;

namespace UAI672_WEB.Repositories
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T ob);
        Task UpdateAsync(T ob);
        Task DeleteAsync(int id);
    }
}