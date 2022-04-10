using ClientSolution.Api.IService;
using ClientSolution.Api.Model;
using ClientSolution.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientSolution.Api.Service
{
    public class PersonRepo : IGenericRepo<Person>
    {
        private readonly AppDbContext appDbContext;
        public PersonRepo(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public List<Person> Delete(int Id)
        {
           var person= appDbContext.Person.Where(a => a.PersonId == Id).FirstOrDefault();
            appDbContext.Person.Remove(person);
            appDbContext.SaveChanges();
            return appDbContext.Person.ToList();
        }

        public List<Person> GetAll()
        {
            return appDbContext.Person.ToList();
        }

        public Person GetById(int Id)
        {
            return appDbContext.Person.Where(a => a.PersonId == Id).FirstOrDefault();
        }

        public List<Person> Insert(Person person)
        {
             appDbContext.Person.Add(person);
             appDbContext.SaveChanges();
             return appDbContext.Person.ToList();
        }

        public Person Update( Person person)
        {
           var update = appDbContext.Person.Where(a => a.PersonId == person.PersonId).FirstOrDefault();

            if (update!=null)
            {
                update.Name = person.Name;
                update.LastName = person.LastName;
                update.Email = person.Email;
                update.SecondaryNumber = person.SecondaryNumber;
                update.PrimaryNumber = person.PrimaryNumber;
                update.GenderId = person.GenderId;

                appDbContext.SaveChanges();
                return update;
            }
            return null;
            
        }
    }
}
