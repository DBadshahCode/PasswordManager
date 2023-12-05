using PasswordManager.Models;
using System.Collections.Generic;

namespace PasswordManager.ViewModels
{
    public class PasswordViewModel
    {
        public Passwords Passwords { get; set; }
        public IEnumerable<Accounts> Accounts { get; set; }
    }
}