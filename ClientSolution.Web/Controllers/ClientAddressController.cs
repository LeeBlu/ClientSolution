using AutoMapper;
using ClientSolution.Model;
using ClientSolution.Web.IService;
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
    public class ClientAddressController : Controller
    {
        private readonly IPersonAddressService _genericService;
        private readonly IMapper Mapper;

        public ClientAddressController(IPersonAddressService genericService, IMapper _Mapper)
        {
            _genericService = genericService;
            Mapper = _Mapper;
        }

        // GET: ClientAddressController
        public async Task<ActionResult> Index()
        {
            var address =(await _genericService.GetAll()).ToList();
            List<AddressVM> _addressVM = new List<AddressVM>();
            Mapper.Map(address, _addressVM);
            return View(_addressVM);
        }

        public async Task<ActionResult> ClientAddress(int id)
        {
            TempData["PersonId"] = id;
            var personAddress = (await _genericService.GetAddressByPersonId(id)).ToList();
           
            List<AddressVM> _addressVM = new List<AddressVM>();
            Mapper.Map(personAddress, _addressVM);
            return View(_addressVM);
        }

        // GET: ClientAddressController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var _address = (await _genericService.GetById(id));
            AddressVM _addressVM = new AddressVM();
            Mapper.Map(_address, _addressVM);
            return View(_addressVM);
        }

        // GET: ClientAddressController/Create
        public ActionResult Create(int id)
        {
           
            AddressVM address = new AddressVM { PersonId = id };
            return View(address);
        }

        // POST: ClientAddressController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(AddressVM value)
        {
            try
            {
                Address _address = new Address();
                Mapper.Map(value,_address);

                await _genericService.Insert(_address);

                return  RedirectToAction("ClientAddress", "ClientAddress", new { id = _address.PersonId });
                //RedirectToAction(nameof(ClientAddress));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClientAddressController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var _address = (await _genericService.GetById(id));
            AddressVM _addressVM = new AddressVM();
            Mapper.Map(_address, _addressVM);
            return View(_addressVM);
        }

        // POST: ClientAddressController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(AddressVM address)
        {
            try
            {
                Address _address = new Address();
                Mapper.Map(address, _address);

               await  _genericService.Update(_address);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClientAddressController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var _address = (await _genericService.GetById(id));
            AddressVM _addressVM = new AddressVM();
            Mapper.Map(_address, _addressVM);
            return View(_addressVM);
        }

        // POST: ClientAddressController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
               await  _genericService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Print(int id )
        {
            try
            {
                var personAddress = (await _genericService.GetAddressByPersonId(id)).ToList();

                List<AddressVM> _addressVM = new List<AddressVM>();
                Mapper.Map(personAddress, _addressVM);
     
                PrintService.WriteToFile(_addressVM);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


    }
}
