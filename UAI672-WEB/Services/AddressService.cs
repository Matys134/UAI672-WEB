using System.Collections.Generic;
using System.Threading.Tasks;
using UAI672_WEB.Models;
using UAI672_WEB.Repositories;

namespace UAI672_WEB.Services
{
    public class AddressService : IService<Addresses>
    {
        private readonly IRepository<Addresses> _addressRepository;

        public AddressService(IRepository<Addresses> addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task<IEnumerable<Addresses>> GetAllAsync()
        {
            return await _addressRepository.GetAllAsync();
        }

        public async Task<Addresses> GetByIdAsync(int id)
        {
            return await _addressRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Addresses address)
        {
            await _addressRepository.AddAsync(address);
        }

        public async Task UpdateAsync(Addresses address)
        {
            await _addressRepository.UpdateAsync(address);
        }

        public async Task DeleteAsync(int id)
        {
            await _addressRepository.DeleteAsync(id);
        }

        public IRepository<Addresses> Get()
        {
            return _addressRepository;
        }
    }
}