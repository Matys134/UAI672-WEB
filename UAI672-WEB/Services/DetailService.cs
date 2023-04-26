using System;
using System.Collections.Generic;
using System.Linq;
using UAI672_WEB.Models;
using UAI672_WEB.Repositories;

namespace UAI672_WEB.Services
{
    public class DetailService : IService<Details>
    {
        private readonly IRepository<Details> _detailsRepository;

        public DetailService(IRepository<Details> detailsRepository) => _detailsRepository = detailsRepository;

        IEnumerable<Details> IService<Details>.GetAll() => _detailsRepository.GetAll();

        public Details GetById(int id) => _detailsRepository.GetById(id);

        public void Add(Details details) => _detailsRepository.Add(details);

        public void Update(Details details) => _detailsRepository.Update(details);

        public void Delete(int id) => _detailsRepository.Delete(id);

        public IRepository<Details> Get() => _detailsRepository;
    }
}