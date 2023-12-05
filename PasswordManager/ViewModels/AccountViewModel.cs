using PasswordManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PasswordManager.ViewModels
{
    public class AccountViewModel
    {
        public Accounts Accounts { get; set; }
        public IEnumerable<Categories> Categories { get; set; }
        public IEnumerable<Websites> Websites { get; set; }
        public IEnumerable<Users> Users { get; set; }
        public IEnumerable<Emails> Emails { get; set; }
        public IEnumerable<Phones> Phones { get; set; }
    }
}