﻿using PasswordManager.Models;
using PasswordManager.ViewModels;
using System;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace PasswordManager.Controllers
{
    public class PinController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();
        // GET: Pin
        public ActionResult Index()
        {
            var pins = _context.Pins.Include(o => o.Accounts).ToList();
            return View("List", pins);
        }

        public JsonResult GetPins()
        {
            var accounts = _context.Pins
                .Select(o => new
                {
                    o.SysId,
                    CreatedDate = o.CreatedDate.ToString(),
                    UpdatedDate = o.UpdatedDate.ToString(),
                    Account = o.Accounts.Name,
                    o.Pin,
                    o.Length,
                    Generated = o.Generated.ToString(),
                    Status = o.Status.ToString(),
                })
                .ToList();
            var js = new JavaScriptSerializer();
            var data = js.Serialize(accounts);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var accounts = _context.Accounts.Where(o => o.SecurityType == SecurityType.Pin).ToList();

            var viewModel = new PinViewModel()
            {
                Pins = new Pins(),
                Accounts = accounts
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(Pins pins)
        {
            if (pins != null)
            {
                if (pins.Generated)
                {
                    StringBuilder builder = new StringBuilder();
                    Random random = new Random();
                    char character;
                    for (int i = 0; i < pins.Length; i++)
                    {
                        character = Convert.ToChar(Convert.ToInt32(Math.Floor(10 * random.NextDouble() + 48)));
                        builder.Append(character);
                    }

                    _context.Pins.Add(new Pins()
                    {
                        SysId = Guid.NewGuid(),
                        CreatedDate = DateTime.Now,
                        UpdatedDate = null,
                        AccountId = pins.AccountId,
                        Pin = Convert.ToInt32(builder.ToString()),
                        Length = pins.Length,
                        Generated = true,
                        Status = pins.Status,
                    });
                }
                else
                {
                    _context.Pins.Add(new Pins()
                    {
                        SysId = Guid.NewGuid(),
                        CreatedDate = DateTime.Now,
                        UpdatedDate = null,
                        AccountId = pins.AccountId,
                        Pin = pins.Pin,
                        Length = pins.Length,
                        Generated = pins.Generated,
                        Status = pins.Status,
                    });
                }

                _context.SaveChanges();
            }
            return RedirectToAction("Index", "Pin");
        }

        public ActionResult Details(Guid id)
        {
            var pin = _context.Pins.Include(o => o.Accounts).SingleOrDefault(o => o.SysId == id);
            return View(pin);
        }

        //[HttpGet]
        //public ActionResult Edit(Guid id)
        //{
        //    var pin = _context.Pins.SingleOrDefault(o => o.SysId == id);
        //    return View(pin);
        //}

        //[HttpPost]
        //public ActionResult Edit(Guid id, Pins pins)
        //{
        //    var pin = _context.Pins.SingleOrDefault(o => o.SysId == id);
        //    if (pin != null)
        //    {
        //        pin.UpdatedDate = DateTime.Now;
        //        pin.Pin = pins.Pin;
        //        pin.Status = pins.Status;
        //        pin.Generated = false;
        //        _context.SaveChanges();
        //    }
        //    return View();
        //}

        public ActionResult Delete(Guid id)
        {
            var pin = _context.Pins.SingleOrDefault(o => o.SysId == id);
            _context.Pins.Remove(pin);
            _context.SaveChanges();
            return RedirectToAction("Index", "Pin");
        }
    }
}