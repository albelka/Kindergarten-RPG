using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Kinder.Models;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Kinder.Controllers
{
    public class RolesController : Controller
    {
        private readonly ApplicationDbContext _db;

        public RolesController(ApplicationDbContext db)
        {
            _db = db;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            var roles = _db.Roles.ToList();
            return View(roles);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost, ActionName("Create")]
        public IActionResult CreateRole()
        {
            try
            {
                string roleName = HttpContext.Request.Form["RoleName"];
                _db.Roles.Add(new IdentityRole()
                {
                    Name = roleName,
                    NormalizedName = roleName.ToUpper()
                });
                _db.SaveChanges();
                ViewBag.ResultMessage = "Role created successfully!";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Delete(string RoleName)
        {
            var thisRole = _db.Roles.Where(r => r.Name.Equals(RoleName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            _db.Roles.Remove(thisRole);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(string id)
        {
            var thisRole = _db.Roles.Where(r => r.Id == id).FirstOrDefault();
            return View(thisRole);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(IdentityRole role)
        {
            try
            {
                var thisRole = _db.Roles.Where(r => r.Id == role.Id).FirstOrDefault();
                thisRole.Name = role.Name;
                thisRole.NormalizedName = role.Name.ToUpper();
                _db.Entry(thisRole).State = EntityState.Modified;
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
