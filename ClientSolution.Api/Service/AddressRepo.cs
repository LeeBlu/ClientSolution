using ClientSolution.Api.IService;
using ClientSolution.Api.Model;
using ClientSolution.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientSolution.Api.Service
{
    public class AddressRepo : IPersonAddressRepo
    {
        private readonly AppDbContext appDbContext;
        public AddressRepo(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public List<Address> Delete(int Id)
        {
            var _address = appDbContext.Address.Where(a => a.PersonId == Id).FirstOrDefault();
            appDbContext.Address.Remove(_address);
            appDbContext.SaveChanges();
            return appDbContext.Address.ToList();
        }

        public List<Address> GetAll()
        {
            return appDbContext.Address.ToList();
        }

        public Address GetById(int Id)
        {
            return appDbContext.Address.Where(a => a.AddressId == Id).FirstOrDefault();
        }

        public List<Address> GetAddressByPersonId(int Id)
        {
            return appDbContext.Address.Where(a => a.PersonId == Id).ToList();
        }

        public List<Address> Insert(Address address)
        {
            appDbContext.Address.Add(address);
            appDbContext.SaveChanges();
            return appDbContext.Address.ToList();
        }

        public Address Update(Address address)
        {
            var update = appDbContext.Address.Where(a => a.AddressId == address.AddressId).FirstOrDefault();

            if (update != null)
            {
                update.AddressTypeId = address.AddressTypeId;
                update.PersonId = address.PersonId;
                update.ProvinceId = address.ProvinceId;
                update.StreetName = address.StreetName;
                update.Town = address.Town;


                appDbContext.SaveChanges();
                return update;
            }
            return null;

        }
    }
}
