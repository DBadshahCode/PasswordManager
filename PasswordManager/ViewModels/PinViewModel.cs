using PasswordManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PasswordManager.ViewModels
{
    public class PinViewModel
    {
        public Pins Pins { get; set; }
        public IEnumerable<Accounts> Accounts { get; set; }
    }
}