using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PasswordManager.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
            
        }

        public DbSet<Accounts> Accounts { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Emails> Emails { get; set; }
        public DbSet<Passwords> Passwords { get; set; }
        public DbSet<Phones> Phones { get; set; }
        public DbSet<Pins> Pins { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Websites> Websites { get; set; }
    }
}