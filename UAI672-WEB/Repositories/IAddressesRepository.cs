using System.Collections.Generic;
using UAI672_WEB.Models;

namespace UAI672_WEB.Repositories
{
    public interface IAddressesRepository
    {
        List<Addresses> GetAllAddresses();
        Addresses GetAddressById(int id);
        void AddAddress(Addresses address);
        void UpdateAddress(Addresses address);
        void DeleteAddress(int id);
    }
}