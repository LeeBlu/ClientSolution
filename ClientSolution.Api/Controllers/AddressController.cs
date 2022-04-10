using ClientSolution.Api.IService;
using ClientSolution.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientSolution.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : BaseController<Address>
    {
        private readonly IPersonAddressRepo _personAddressRepo;
        public AddressController(IPersonAddressRepo genericRepo) : base(genericRepo)
        {
            _personAddressRepo = genericRepo;
        }

        // GET api/<BaseController>/5
    
        [HttpGet("GetAddressByPersonId/{id}")]
        public List<Address> GetAddressByPersonId(int id)
        {
            return _personAddressRepo.GetAddressByPersonId(id);
        }


    }
}
