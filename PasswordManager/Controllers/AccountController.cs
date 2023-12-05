using PasswordManager.Models;
using PasswordManager.ViewModels;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;

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
                .Include(o => o.Users)
                .Include(o => o.Emails)
                .Include(o => o.Phones)
                .ToList();
            return View("List", accounts);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var categories = _context.Categories.ToList();
            var websites = _context.Websites.ToList();
            var users = _context.Users.ToList();
            var emails = _context.Emails.ToList();
            var phones = _context.Phones.ToList();
            var viewModel = new AccountViewModel()
            {
                Accounts = new Accounts(),
                Categories = categories,
                Websites = websites,
                Users = users,
                Emails = emails,
                Phones = phones
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(Accounts accounts)
        {
            if (accounts != null)

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
                    UserId = accounts.UserId,
                    EmailId = accounts.EmailId,
                    PhoneId = accounts.PhoneId,
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
                .Include(o => o.Users)
                .Include(o => o.Emails)
                .Include(o => o.Phones)
                .SingleOrDefault(o => o.SysId == id);
            return View(account);
        }

        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            var account = _context.Accounts.SingleOrDefault(o => o.SysId == id);
            var category = _context.Categories.ToList();
            var website = _context.Websites.ToList();
            var user = _context.Users.ToList();
            var email = _context.Emails.ToList();
            var phone = _context.Phones.ToList();

            var viewModel = new AccountViewModel()
            {
                Accounts = account,
                Categories = category,
                Websites = website,
                Users = user,
                Emails = email,
                Phones = phone,
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
                account.UserId = accounts.UserId;
                account.EmailId = accounts.EmailId;
                account.PhoneId = accounts.PhoneId;
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