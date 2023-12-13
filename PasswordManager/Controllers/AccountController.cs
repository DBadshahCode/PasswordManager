using PasswordManager.Models;
using PasswordManager.ViewModels;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace PasswordManager.Controllers
{
    public class AccountController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();
        // GET: Account
        public ActionResult Index()
        {
            var accounts = _context.Accounts
                .Include(o => o.Categories)
                .Include(o => o.Websites)
                .ToList();
            return View("List", accounts);
        }

        public JsonResult GetAccounts()
        {
            var accounts = _context.Accounts
                .Select(o => new
                {
                    o.SysId,
                    CreatedDate = o.CreatedDate.ToString(),
                    UpdatedDate = o.UpdatedDate.ToString(),
                    o.Name,
                    o.Username,
                    o.EmailAddress,
                    o.MobileNumber,
                    SecurityType = o.SecurityType.ToString(),
                    o.Comments,
                    Closed = o.Closed.ToString(),
                    Category = o.Categories != null ? o.Categories.Name : "",
                    Website = o.Websites != null ? o.Websites.Name : "",
                })
                .ToList();
            var js = new JavaScriptSerializer();
            var data = js.Serialize(accounts);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var categories = _context.Categories.ToList();
            var websites = _context.Websites.ToList();
            var viewModel = new AccountViewModel()
            {
                Accounts = new Accounts(),
                Categories = categories,
                Websites = websites,
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(Accounts accounts)
        {
            if(accounts != null)
            {
                _context.Accounts.Add(
                new Accounts()
                {
                    SysId = Guid.NewGuid(),
                    CreatedDate = DateTime.Now,
                    UpdatedDate = null,
                    Name = accounts.Name,
                    CategoryId = accounts.CategoryId,
                    WebsiteId = accounts.WebsiteId,
                    Username = accounts.Username,
                    EmailAddress = accounts.EmailAddress,
                    MobileNumber = accounts.MobileNumber,
                    SecurityType = accounts.SecurityType,
                    Comments = accounts.Comments,
                });
                _context.SaveChanges();
            }
            return RedirectToAction("Index", "Account");
        }

        public ActionResult Details(Guid id)
        {
            var account = _context.Accounts
                .Include(o => o.Categories)
                .Include(o => o.Websites)
                .SingleOrDefault(o => o.SysId == id);
            return View(account);
        }

        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            var account = _context.Accounts.SingleOrDefault(o => o.SysId == id);
            var category = _context.Categories.ToList();
            var website = _context.Websites.ToList();

            var viewModel = new AccountViewModel()
            {
                Accounts = account,
                Categories = category,
                Websites = website
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(Guid id, Accounts accounts)
        {
            var account = _context.Accounts.SingleOrDefault(o => o.SysId == id);
            if (account != null)
            {
                account.UpdatedDate = DateTime.Now;
                account.Name = accounts.Name;
                account.CategoryId = accounts.CategoryId;
                account.WebsiteId = accounts.WebsiteId;
                account.Username = accounts.Username;
                account.EmailAddress = accounts.EmailAddress;
                account.MobileNumber = accounts.MobileNumber;
                account.SecurityType = accounts.SecurityType;
                account.Comments = accounts.Comments;
                _context.SaveChanges();
            }
            return View();
        }

        public ActionResult Delete(Guid id)
        {
            var account = _context.Accounts.SingleOrDefault(o => o.SysId == id);
            _context.Accounts.Remove(account);
            _context.SaveChanges();
            return RedirectToAction("Index", "Account");
        }
    }
}