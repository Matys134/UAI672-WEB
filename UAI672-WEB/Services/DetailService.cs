using System.Collections.Generic;
using System.Linq;
using UAI672_WEB.Models;
using UAI672_WEB.Repositories;

namespace UAI672_WEB.Services
{
    public class DetailService : IService<Details>
    {
        private readonly IDetailsRepository _detailsRepository;

        public DetailService(IDetailsRepository detailsRepository)
        {
            _detailsRepository = detailsRepository;
        }

        IEnumerable<Details> IService<Details>.GetAll()
        {
            return GetAll();
        }

        public Details GetById(int id)
        {
            return _detailsRepository.GetDetailById(id);
        }

        public void Add(Details details)
        {
            _detailsRepository.AddDetail(details);
        }

        public void Update(Details details)
        {
            _detailsRepository.UpdateDetail(details);
        }

        public void Delete(int id)
        {
            _detailsRepository.DeleteDetail(id);
        }

        public IList<Details> GetAll()
        {
            return _detailsRepository.GetAllDetails().ToList();
        }

        public void Create(Details details)
        {
            _detailsRepository.AddDetail(details);
        }
    }
}