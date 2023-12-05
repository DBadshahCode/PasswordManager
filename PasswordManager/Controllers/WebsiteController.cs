using PasswordManager.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace PasswordManager.Controllers
{
    public class WebsiteController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();
        // GET: Website
        public ActionResult Index()
        {
            var websites = _context.Websites.ToList();
            return View("List", websites);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Websites websites)
        {
            if (websites != null)
            {
                _context.Websites.Add(
                new Websites()
                {
                    SysId = Guid.NewGuid(),
                    CreatedDate = DateTime.Now,
                    UpdatedDate = null,
                    Name = websites.Name,
                    Url = websites.Url,
                    Status = websites.Status,
                });
                _context.SaveChanges();
            }
            return RedirectToAction("Index", "Website");
        }

        public ActionResult Details(Guid id)
        {
            var website = _context.Websites.SingleOrDefault(o => o.SysId == id);
            return View(website);
        }

        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            var website = _context.Websites.SingleOrDefault(o => o.SysId == id);
            return View(website);
        }

        [HttpPost]
        public ActionResult Edit(Guid id, Websites websites)
        {
            var website = _context.Websites.SingleOrDefault(o => o.SysId == id);
            if (website != null)
            {
                website.UpdatedDate = DateTime.Now;
                website.Name = websites.Name;
                website.Status = websites.Status;
                website.Url = websites.Url;
                _context.SaveChanges();
            }
            return View();
        }

        public ActionResult Delete(Guid id)
        {
            var website = _context.Websites.SingleOrDefault(o => o.SysId == id);
            _context.Websites.Remove(website);
            _context.SaveChanges();
            return RedirectToAction("Index", "Website");
        }
    }
}