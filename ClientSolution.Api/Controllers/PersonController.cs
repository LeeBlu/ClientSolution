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
    public class PersonController : BaseController<Person>
    {
        public PersonController(IGenericRepo<Person> genericRepo) : base(genericRepo)
        {
        
        }
    }
}
