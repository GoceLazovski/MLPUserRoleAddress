using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data.Models;
using Repository.Context;
using Repository.Repository;
using UI.Models;

namespace UI.Controllers
{
    public class AddressesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddressesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Addresses
        public IActionResult Index()
        {
            return View(_unitOfWork.AddressRepository.Get());
        }

        // GET: Addresses/Details/5
        public IActionResult Details(int id)
        {
            var address = _unitOfWork.AddressRepository.GetAddressByIdWithItsUsers(id);
            if (address == null)
            {
                return NotFound();
            }

            ViewModelAddress a = new ViewModelAddress
            {
                AddressStreetAndNumber = address.AddressStreetAndNumber,
                UserAddresses = address.UserAddresses.Select(ua => new ViewModelUserAddresses
                {
                    AddressId = ua.AddressId,
                    UserId = ua.UserId,
                    User = new ViewModelUser
                    {
                        Id = ua.User.Id,
                        UserName = ua.User.UserName
                    }
                }).ToList()
            };

            return View(a);
        }

        // GET: Addresses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Addresses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ViewModelAddress address)
        {
            Address a = new Address
            {
                AddressStreetAndNumber = address.AddressStreetAndNumber
            };
            if (ModelState.IsValid)
            {
                _unitOfWork.AddressRepository.Insert(a);
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(address);
        }

        // GET: Addresses/Edit/5
        public IActionResult Edit(int id)
        {            
            var address = _unitOfWork.AddressRepository.GetById(id);
            if (address == null)
            {
                return NotFound();
            }

            ViewModelAddress a = new ViewModelAddress
            {
                Id = address.Id,
                AddressStreetAndNumber = address.AddressStreetAndNumber,
                UserAddresses = address.UserAddresses.Select(ua => new ViewModelUserAddresses
                {
                    AddressId = ua.AddressId,                    
                    UserId = ua.UserId

                }).ToList()
            };
            return View(a);
        }

        // POST: Addresses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, /*[Bind("Id,AddressStreetAndNumber")]*/ ViewModelAddress address)
        {
            if (ModelState.IsValid)
            {                
                Address a = new Address
                {
                    AddressStreetAndNumber = address.AddressStreetAndNumber
                };
                _unitOfWork.AddressRepository.Update(a);
                _unitOfWork.Save();
                                   
                return RedirectToAction(nameof(Index));
            }
            return View(address);
        }

        // GET: Addresses/Delete/5
        public IActionResult Delete(int id)
        {
            var address = _unitOfWork.AddressRepository.GetById(id);
            if (address == null)
            {
                return NotFound();
            }
            ViewModelAddress a = new ViewModelAddress
            {
                Id = address.Id,
                AddressStreetAndNumber = address.AddressStreetAndNumber,
                UserAddresses = address.UserAddresses.Select(ua => new ViewModelUserAddresses
                {
                    AddressId = ua.AddressId,
                    UserId = ua.UserId

                }).ToList()
            };
            return View(a);
        }

        // POST: Addresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var address = _unitOfWork.AddressRepository.GetById(id);
            _unitOfWork.AddressRepository.Delete(address);
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }

        //private bool AddressExists(int id)
        //{
        //    return _context.Addresses.Any(e => e.Id == id);
        //}
    }
}
