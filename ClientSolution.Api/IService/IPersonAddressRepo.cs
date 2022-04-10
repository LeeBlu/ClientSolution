using ClientSolution.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientSolution.Api.IService
{
    public interface IPersonAddressRepo: IGenericRepo<Address>
    {
        List<Address> GetAddressByPersonId(int Id);
    }
}
