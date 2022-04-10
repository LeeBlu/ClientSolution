using ClientSolution.Model;
using ClientSolution.Web.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientSolution.Web.IService
{
    public interface IPersonAddressService : IGenericService<Address>
    {
        Task<List<Address>> GetAddressByPersonId(int Id);
    }
}
