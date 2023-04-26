using System.Collections.Generic;
using UAI672_WEB.Models;
using UAI672_WEB.Repositories;

namespace UAI672_WEB.Services
{
    public class AddressService : IService<Addresses>
    {
        private readonly IAddressesRepository _addressRepository;

        public AddressService(IAddressesRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }
       

        public List<Addresses> GetAll()
        {
            return _addressRepository.GetAllAddresses();
        }

        public Addresses GetById(int id)
        {
            return _addressRepository.GetAddressById(id);
        }

        public void Add(Addresses address)
        {
            _addressRepository.AddAddress(address);
        }

        public void Update(Addresses address)
        {
            _addressRepository.UpdateAddress(address);
        }

        public void Delete(int id)
        {
            _addressRepository.DeleteAddress(id);
        }

        IEnumerable<Addresses> IService<Addresses>.GetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}