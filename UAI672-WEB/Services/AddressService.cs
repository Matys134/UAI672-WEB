using System.Collections.Generic;
using UAI672_WEB.Models;
using UAI672_WEB.Repositories;

namespace UAI672_WEB.Services
{
    public class AddressService : IAddressService
    {
        private readonly IAddressesRepository _addressRepository;

        public AddressService(IAddressesRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public List<Addresses> GetAllAddresses()
        {
            return _addressRepository.GetAllAddresses();
        }

        public Addresses GetAddressById(int id)
        {
            return _addressRepository.GetAddressById(id);
        }

        public void AddAddress(Addresses address)
        {
            _addressRepository.AddAddress(address);
        }

        public void UpdateAddress(Addresses address)
        {
            _addressRepository.UpdateAddress(address);
        }

        public void DeleteAddress(int id)
        {
            _addressRepository.DeleteAddress(id);
        }
    }
}