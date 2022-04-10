using ClientSolution.Api.IService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClientSolution.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController <T>: Controller where T:class
    {
        private IGenericRepo<T> _genericRepo;

        public BaseController(IGenericRepo<T> genericRepo)
        {
            _genericRepo = genericRepo;
        }
        // GET: api/<BaseController>
        [HttpGet]
        public List<T> Get()
        {
            return _genericRepo.GetAll();
        }

        // GET api/<BaseController>/5
        [HttpGet("{id}")]
        public T Get(int id)
        {
            return _genericRepo.GetById(id);
        }

        // POST api/<BaseController>
        [HttpPost]
        public List<T> Post([FromBody] T value)
        {
            return _genericRepo.Insert(value);
        }

        // PUT api/<BaseController>/5
        [HttpPut]
        public T Put([FromBody] T value)
        {
            return _genericRepo.Update(value);
        }

        // DELETE api/<BaseController>/5
        [HttpDelete("{id}")]
        public List<T> Delete(int id)
        {
            return _genericRepo.Delete(id);
        }
    }
}
