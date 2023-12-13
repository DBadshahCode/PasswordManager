using PasswordManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace PasswordManager.Controllers
{
    public class CategoryController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();
        // GET: Category
        public ActionResult Index()
        {
            var categories = _context.Categories.ToList();
            return View("List", categories);
        }

        public JsonResult GetCategories()
        {
            var categories = _context.Categories
                .Select(o => new
                {
                    o.SysId,
                    CreatedDate = o.CreatedDate.ToString(),
                    UpdatedDate = o.UpdatedDate.ToString(),
                    o.Name,
                    Status = o.Status.ToString(),
                })
                .ToList();
            var js = new JavaScriptSerializer();
            var data = js.Serialize(categories);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Categories categories)
        {
            if (categories != null)
            {
                _context.Categories.Add(
                new Categories()
                {
                    SysId = Guid.NewGuid(),
                    CreatedDate = DateTime.Now,
                    UpdatedDate = null,
                    Name = categories.Name,
                });
                _context.SaveChanges();
            }
            return RedirectToAction("Index", "Category");
        }

        public ActionResult Details(Guid id)
        {
            var category = _context.Categories.SingleOrDefault(o => o.SysId == id);
            return View(category);
        }

        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            var category = _context.Categories.SingleOrDefault(o => o.SysId == id);
            return View(category);
        }

        [HttpPost]
        public ActionResult Edit(Guid id, Categories categories)
        {
            var category = _context.Categories.SingleOrDefault(o => o.SysId == id);
            if (category != null)
            {
                category.UpdatedDate = DateTime.Now;
                category.Name = categories.Name;
                _context.SaveChanges();
            }
            return View();
        }

        public ActionResult Delete(Guid id)
        {
            var category = _context.Categories.SingleOrDefault(o => o.SysId == id);
            _context.Categories.Remove(category);
            _context.SaveChanges();
            return RedirectToAction("Index", "Category");
        }
    }
}