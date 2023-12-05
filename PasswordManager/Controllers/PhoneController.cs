using PasswordManager.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace PasswordManager.Controllers
{
    public class PhoneController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();
        // GET: Phone
        public ActionResult Index()
        {
            var phones = _context.Phones.ToList();
            return View("List", phones);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Phones phones)
        {
            if (phones != null)
            {
                _context.Phones.Add(
                new Phones()
                {
                    SysId = Guid.NewGuid(),
                    CreatedDate = DateTime.Now,
                    UpdatedDate = null,
                    Number = phones.Number,
                    Status = phones.Status,
                });
                _context.SaveChanges();
            }
            return RedirectToAction("Index", "Phone");
        }

        public ActionResult Details(Guid id)
        {
            var phone = _context.Phones.SingleOrDefault(o => o.SysId == id);
            return View(phone);
        }

        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            var phone = _context.Phones.SingleOrDefault(o => o.SysId == id);
            return View(phone);
        }

        [HttpPost]
        public ActionResult Edit(Guid id, Phones phones)
        {
            var phone = _context.Phones.SingleOrDefault(o => o.SysId == id);
            if (phone != null)
            {
                phone.UpdatedDate = DateTime.Now;
                phone.Number = phones.Number;
                phone.Status = phones.Status;
                _context.SaveChanges();
            }
            return View();
        }

        public ActionResult Delete(Guid id)
        {
            var phone = _context.Phones.SingleOrDefault(o => o.SysId == id);
            _context.Phones.Remove(phone);
            _context.SaveChanges();
            return RedirectToAction("Index", "Phone");
        }
    }
}