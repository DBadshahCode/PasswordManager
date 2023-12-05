using PasswordManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PasswordManager.ViewModels
{
    public class PasswordViewModel
    {
        public Passwords Passwords { get; set; }
        public IEnumerable<Accounts> Accounts { get; set; }
    }
}