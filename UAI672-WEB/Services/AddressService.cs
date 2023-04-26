using System.Collections.Generic;
using UAI672_WEB.Models;
using UAI672_WEB.Repositories;

namespace UAI672_WEB.Services
{
    public class AddressService : IService<Addresses>
    {
        private readonly IRepository<Addresses> _addressRepository;

        public AddressService(IRepository<Addresses> addressRepository) => _addressRepository = addressRepository;

        IEnumerable<Addresses> IService<Addresses>.GetAll() => _addressRepository.GetAll();

        public Addresses GetById(int id) => _addressRepository.GetById(id);

        public void Add(Addresses address) => _addressRepository.Add(address);

        public void Update(Addresses address) => _addressRepository.Update(address);

        public void Delete(int id) => _addressRepository.Delete(id);
    }
}