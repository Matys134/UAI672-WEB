using UAI672_WEB.Repositories;

namespace UAI672_WEB.Services
{
    using System.Collections.Generic;
    using UAI672_WEB.Models;

    public interface IAddressService
    {
        List<Addresses> GetAllAddresses();
        Addresses GetAddressById(int id);
        void AddAddress(Addresses address);
        void UpdateAddress(Addresses address);
        void DeleteAddress(int id);
    }
}