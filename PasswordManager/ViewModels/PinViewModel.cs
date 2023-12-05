using PasswordManager.Models;
using System.Collections.Generic;

namespace PasswordManager.ViewModels
{
    public class PinViewModel
    {
        public Pins Pins { get; set; }
        public IEnumerable<Accounts> Accounts { get; set; }
    }
}