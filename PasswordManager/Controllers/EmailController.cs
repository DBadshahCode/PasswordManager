using PasswordManager.Models;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace PasswordManager.Controllers
{
    public class EmailController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();
        // GET: Email
        public ActionResult Index()
        {
            var emails = _context.Emails.ToList();
            return View("List", emails);
        }

        public JsonResult GetEmails()
        {
            var emails = _context.Emails
                .Select(o => new
                {
                    CreatedDate = o.CreatedDate.ToString(),
                    UpdatedDate = o.UpdatedDate.ToString(),
                    o.EmailAddress,
                    Status = o.Status.ToString(),
                })
                .ToList();
            var js = new JavaScriptSerializer();
            var data = js.Serialize(emails);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Emails emails)
        {
            if (emails != null)
            {
                _context.Emails.Add(
                new Emails()
                {
                    SysId = Guid.NewGuid(),
                    CreatedDate = DateTime.Now,
                    UpdatedDate = null,
                    EmailAddress = emails.EmailAddress,
                    Status = emails.Status,
                });
                _context.SaveChanges();
            }
            return RedirectToAction("Index", "Email");
        }

        public ActionResult Details(Guid id)
        {
            var email = _context.Emails.SingleOrDefault(o => o.SysId == id);
            return View(email);
        }

        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            var email = _context.Emails.SingleOrDefault(o => o.SysId == id);
            return View(email);
        }

        [HttpPost]
        public ActionResult Edit(Guid id, Emails emails)
        {
            var email = _context.Emails.SingleOrDefault(o => o.SysId == id);
            if (email != null)
            {
                email.UpdatedDate = DateTime.Now;
                email.EmailAddress = emails.EmailAddress;
                email.Status = emails.Status;
                _context.SaveChanges();
            }
            return View();
        }

        public ActionResult Delete(Guid id)
        {
            var email = _context.Emails.SingleOrDefault(o => o.SysId == id);
            _context.Emails.Remove(email);
            _context.SaveChanges();
            return RedirectToAction("Index", "Email");
        }
    }
}