using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UAI672_WEB.Models;
using UAI672_WEB.Repositories;

namespace UAI672_WEB.Services
{
    public class DetailService : IService<Details>
    {
        private readonly IRepository<Details> _detailsRepository;

        public DetailService(IRepository<Details> detailsRepository) => _detailsRepository = detailsRepository;

        public async Task<IEnumerable<Details>> GetAllAsync() => await _detailsRepository.GetAllAsync();

        public async Task<Details> GetByIdAsync(int id) => await _detailsRepository.GetByIdAsync(id);

        public async Task AddAsync(Details details) => await _detailsRepository.AddAsync(details);

        public async Task UpdateAsync(Details details) => await _detailsRepository.UpdateAsync(details);

        public async Task DeleteAsync(int id) => await _detailsRepository.DeleteAsync(id);

        public IRepository<Details> Get() => _detailsRepository;
    }
}