using System.Collections.Generic;
using System.Linq;
using UAI672_WEB.Models;
using UAI672_WEB.Repositories;

namespace UAI672_WEB.Services
{
    public class DetailService : IDetailService
    {
        private readonly IDetailsRepository _detailsRepository;

        public DetailService(IDetailsRepository detailsRepository)
        {
            _detailsRepository = detailsRepository;
        }

        public IList<Details> GetAllDetails()
        {
            return _detailsRepository.GetAllDetails().ToList();
        }

        IEnumerable<Details> IDetailService.GetAllDetails()
        {
            return GetAllDetails();
        }

        public Details GetDetailsById(int id)
        {
            return _detailsRepository.GetDetailById(id);
        }

        public void CreateDetails(Details details)
        {
            _detailsRepository.AddDetail(details);
        }

        public void AddDetails(Details details)
        {
            _detailsRepository.AddDetail(details);
        }

        public void UpdateDetails(Details details)
        {
            _detailsRepository.UpdateDetail(details);
        }

        public void DeleteDetails(int id)
        {
            _detailsRepository.DeleteDetail(id);
        }
    }
}