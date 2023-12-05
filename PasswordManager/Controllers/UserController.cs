﻿using PasswordManager.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace PasswordManager.Controllers
{
    public class UserController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();
        // GET: User
        public ActionResult Index()
        {
            var users = _context.Users.ToList();
            return View("List", users);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Users users)
        {
            if (users != null)
            {
                _context.Users.Add(
                new Users()
                {
                    SysId = Guid.NewGuid(),
                    CreatedDate = DateTime.Now,
                    UpdatedDate = null,
                    Name = users.Name,
                });
                _context.SaveChanges();
            }
            return RedirectToAction("Index", "User");
        }

        public ActionResult Details(Guid id)
        {
            var user = _context.Users.SingleOrDefault(o => o.SysId == id);
            return View(user);
        }

        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            var user = _context.Users.SingleOrDefault(o => o.SysId == id);
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(Guid id, Users users)
        {
            var user = _context.Users.SingleOrDefault(o => o.SysId == id);
            if (user != null)
            {
                user.UpdatedDate = DateTime.Now;
                user.Name = users.Name;
                _context.SaveChanges();
            }
            return View();
        }

        public ActionResult Delete(Guid id)
        {
            var user = _context.Users.SingleOrDefault(o => o.SysId == id);
            _context.Users.Remove(user);
            _context.SaveChanges();
            return RedirectToAction("Index", "User");
        }
    }
}