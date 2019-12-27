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
    public class UsersController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public UsersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
      
        public ViewResult Index()
        {          
            var users = _unitOfWork.UserRepository.Get();
            
            return View(users.ToList());
        }
      
        // GET: Users/Details/5
        public ViewResult Details(int id)
        {            
            var user = _unitOfWork.UserRepository.GetUserById(id);

            ViewModelUser viewModelUser = new ViewModelUser
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                //Role = user.Role(r => new ViewModelRole
                //{
                //    Id = r.Id,
                //    Name = r.Name
                //})
            };

            return View(user);
        }

        // GET: Users/Create
        public IActionResult SignIn()
        {
            ViewData["RoleId"] = new SelectList(_unitOfWork.RoleRepository.Get(), "Id", "Name");
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Create(/*[Bind("Id,UserName,FirstName,LastName,Password,RoleId")]*/ ViewModelUser user)
        {
            var u = new User
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Password = user.Password,
                RoleId = user.RoleId,
                UserName = user.UserName//,
                //UserAddresses = user.UserAddresses
            };
            if (ModelState.IsValid)
            {
                _unitOfWork.UserRepository.Insert(u);
                 _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["RoleId"] = new SelectList(_unitOfWork.RoleRepository.Get(), "Id", "Name");
            return View(u);
        }

        // GET: Users/Edit/5
        public IActionResult Edit(int id)
        {
            var user = _unitOfWork.UserRepository.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            //ViewData["RoleId"] = new SelectList(_unitOfWork.RoleRepository.Get(), "Id", "Name");
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(/*[Bind("Id,UserName,FirstName,LastName,Password,RoleId")]*/ ViewModelUser user)
        {
            var u = new User
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Password = user.Password,
                RoleId = user.RoleId,
                UserName = user.UserName//,
                //UserAddresses = user.UserAddresses
            };
            
            if (ModelState.IsValid)
            {                
                _unitOfWork.UserRepository.Update(u);
                _unitOfWork.Save();
                
                return RedirectToAction(nameof(Index));
            }
            //ViewData["RoleId"] = new SelectList(_unitOfWork.RoleRepository.Get(), "Id", "Name");
            return View(u);
        }

        // GET: Users/Delete/5
        public  IActionResult Delete(int id)
        {
            var user =  _unitOfWork.UserRepository.GetUserById(id);
          
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var user = _unitOfWork.UserRepository.GetUserById(id);
            _unitOfWork.UserRepository.Delete(user);
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }

        //private bool UserExists(int id)
        //{
        //    return _context.Users.Any(e => e.Id == id);
        //}
    }
}
