using PasswordManager.Models;
using PasswordManager.ViewModels;
using System;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace PasswordManager.Controllers
{
    public class PasswordController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();
        // GET: Password
        public ActionResult Index()
        {
            var passwords = _context.Passwords.Include(o => o.Accounts).ToList();
            return View("List", passwords);
        }

        public JsonResult GetPasswords()
        {
            var passwords = _context.Passwords
                .Select(o => new
                {
                    CreatedDate = o.CreatedDate.ToString(),
                    UpdatedDate = o.UpdatedDate.ToString(),
                    Account = o.Accounts.Name,
                    o.Password,
                    o.Length,
                    Generated = o.Generated.ToString(),
                    Status = o.Status.ToString(),
                })
                .ToList();
            var js = new JavaScriptSerializer();
            var data = js.Serialize(passwords);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var accounts = _context.Accounts.Where(o => o.SecurityType == SecurityType.Password).ToList();

            var viewModel = new PasswordViewModel()
            {
                Passwords = new Passwords(),
                Accounts = accounts
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(Passwords passwords)
        {
            if (passwords != null)
            {
                if (passwords.Generated)
                {
                    StringBuilder builder = new StringBuilder();
                    Random random = new Random();
                    char character;
                    for (int i = 0; i < passwords.Length; i++)
                    {
                        character = Convert.ToChar(Convert.ToInt32(Math.Floor(94 * random.NextDouble() + 33)));
                        builder.Append(character);
                    }

                    _context.Passwords.Add(new Passwords()
                    {
                        SysId = Guid.NewGuid(),
                        CreatedDate = DateTime.Now,
                        UpdatedDate = null,
                        AccountId = passwords.AccountId,
                        Password = builder.ToString(),
                        Length = passwords.Length,
                        Generated = passwords.Generated,
                        Status = passwords.Status,
                    });
                }
                else
                {
                    _context.Passwords.Add(new Passwords()
                    {
                        SysId = Guid.NewGuid(),
                        CreatedDate = DateTime.Now,
                        UpdatedDate = null,
                        AccountId = passwords.AccountId,
                        Password = passwords.Password,
                        Length = passwords.Length,
                        Generated = passwords.Generated,
                        Status = passwords.Status,
                    });
                }

                _context.SaveChanges();
            }
            return RedirectToAction("Index", "Password");
        }

        public ActionResult Details(Guid id)
        {
            var password = _context.Passwords.Include(o => o.Accounts).SingleOrDefault(o => o.SysId == id);
            return View(password);
        }

        //[HttpGet]
        //public ActionResult Edit(Guid id)
        //{
        //    var password = _context.Passwords.SingleOrDefault(o => o.SysId == id);
        //    return View(password);
        //}

        //[HttpPost]
        //public ActionResult Edit(Guid id, Passwords passwords)
        //{
        //    var password = _context.Passwords.SingleOrDefault(o => o.SysId == id);
        //    if (password != null)
        //    {
        //        password.UpdatedDate = DateTime.Now;
        //        password.Password = passwords.Password;
        //        password.Status = passwords.Status;
        //        password.Generated = false;
        //        _context.SaveChanges();
        //    }
        //    return View();
        //}

        public ActionResult Delete(Guid id)
        {
            var password = _context.Passwords.SingleOrDefault(o => o.SysId == id);
            _context.Passwords.Remove(password);
            _context.SaveChanges();
            return RedirectToAction("Index", "Password");
        }
    }
}