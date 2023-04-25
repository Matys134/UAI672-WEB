using System.Data.Entity;
using System.Linq;

namespace UAI672_WEB.Repositories
{
    using System.Collections.Generic;
    using UAI672_WEB.Models;

    public interface IAddressesRepository
    {
        List<Addresses> GetAllAddresses();
        Addresses GetAddressById(int id);
        void AddAddress(Addresses address);
        void UpdateAddress(Addresses address);
        void DeleteAddress(int id);
    }
}