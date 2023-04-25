using System.Collections.Generic;
using UAI672_WEB.Models;

namespace UAI672_WEB.Services
{
    public interface IDetailService
    {
        IEnumerable<Details> GetAllDetails();
        Details GetDetailsById(int id);
        void AddDetails(Details details);
        void UpdateDetails(Details details);
        void DeleteDetails(int id);
    }
}