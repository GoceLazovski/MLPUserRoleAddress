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
    public class RolesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public RolesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Roles
        public IActionResult Index()
        {
            var roles = _unitOfWork.RoleRepository.Get();
            return View( roles.ToList());
        }

        // GET: Roles/Details/5
        public  IActionResult Details(int id)
        {            
            var role = _unitOfWork.RoleRepository.GetRoleWithItsUsersById(id);

            ViewModelRole vmRole = new ViewModelRole
            {
                Name = role.Name,
                Id = role.Id,
                Users = role.Users.Select(u => new ViewModelUser
                {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    UserName = u.UserName
                }).ToList()
            };

            if (role == null)
            {
                return NotFound();
            }

            return View(vmRole);
        }

        // GET: Roles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Roles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(/*[Bind("Id,Name")]*/ ViewModelRole role)
        {
            var r = new Role
            {
                Id = role.Id,
                Name = role.Name
            };

            if (ModelState.IsValid)
            {
                _unitOfWork.RoleRepository.Insert(r);
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(role);
        }

        // GET: Roles/Edit/5
        public IActionResult Edit(int id)
        {            
            var role = _unitOfWork.RoleRepository.GetById(id);
            if (role == null)
            {
                return NotFound();
            }
            ViewModelRole vmRole = new ViewModelRole
            {
                Name = role.Name,
                Id = role.Id                
            };
            return View(vmRole);
        }

        // POST: Roles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ViewModelRole vmRole)
        {
            var roletoedit = _unitOfWork.RoleRepository.GetById(vmRole.Id);
            roletoedit.Name = vmRole.Name;
            //

            if (ModelState.IsValid)
            {                
                _unitOfWork.RoleRepository.Update(roletoedit);
                _unitOfWork.Save();
                                
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Roles/Delete/5
        public IActionResult Delete(int id)
        {
            var role = _unitOfWork.RoleRepository.GetById(id);
            if (role == null)
            {
                return NotFound();
            }
            return View(role);
        }

        // POST: Roles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var role = _unitOfWork.RoleRepository.GetById(id);
            _unitOfWork.RoleRepository.Delete(role);
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }

        //private bool RoleExists(int id)
        //{
        //    return _context.Roles.Any(e => e.Id == id);
        //}
    }
}
