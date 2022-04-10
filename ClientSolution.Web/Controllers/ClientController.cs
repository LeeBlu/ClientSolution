using AutoMapper;
using ClientSolution.Model;
using ClientSolution.Web.Service;
using ClientSolution.Web.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientSolution.Web.Controllers
{
    public class ClientController : Controller
    {
        private readonly IGenericService<Person> _genericService;
        private readonly IMapper Mapper;
        public ClientController(IGenericService<Person> genericService, IMapper _mapper)
        {
            _genericService = genericService;
            Mapper = _mapper;
        }

        // GET: ClientController
        public async Task<ActionResult> Index()
        {
            var _person =( await _genericService.GetAll()).ToList();
            List<PersonVM> _personVM = new List<PersonVM>();
            Mapper.Map(_person, _personVM);
            return View(_personVM);
        }

        // GET: ClientController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var _person =(await _genericService.GetById(id));
            PersonVM _personVM = new PersonVM();
            Mapper.Map(_person, _personVM);
            return View(_personVM);
        }

        // GET: ClientController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClientController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(PersonVM value)
        {
            try
            {
                Person _person = new Person();
                Mapper.Map(value, _person);

                 await _genericService.Insert(_person);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClientController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var _person = (await _genericService.GetById(id));
            PersonVM personVM = new PersonVM();
            Mapper.Map(_person, personVM);
            return View(personVM);
           
        }

        // POST: ClientController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit( PersonVM person)
        {
            try
            {
                Person _person = new Person();
                Mapper.Map(person, _person);

                await _genericService.Insert(_person);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClientController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var _person = (await _genericService.GetById(id));
            PersonVM personVM = new PersonVM();
            Mapper.Map(_person, personVM);
            return View(personVM);
        }

        // POST: ClientController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
               await _genericService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public async Task<ActionResult> Print()
        {
            try
            {
                var _person = (await _genericService.GetAll()).ToList();
                List<PersonVM> people = new List<PersonVM>();
                Mapper.Map(_person, people);

                 PrintService.WriteToFile(people);
                  return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
