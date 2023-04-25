using System.Collections.Generic;
using UAI672_WEB.Models;

namespace UAI672_WEB.Repositories
{
    public interface IDetailsRepository
    {
        List<Details> GetAllDetails();
        Details GetDetailById(int id);
        void AddDetail(Details detail);
        void UpdateDetail(Details detail);
        void DeleteDetail(int id);
    }
}