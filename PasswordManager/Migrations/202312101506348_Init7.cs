namespace PasswordManager.Migrations
{
    using PasswordManager.Models;
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init7 : DbMigration
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        public override void Up()
        {
            #region Categories
            _context.Categories.Add(new Categories()
            {
                SysId = Guid.NewGuid(),
                CreatedDate = DateTime.Now,
                UpdatedDate = null,
                Name = "Banking",
                Status = Status.Unused
            });
            _context.Categories.Add(new Categories()
            {
                SysId = Guid.NewGuid(),
                CreatedDate = DateTime.Now,
                UpdatedDate = null,
                Name = "Social Media",
                Status = Status.Unused
            });
            _context.Categories.Add(new Categories()
            {
                SysId = Guid.NewGuid(),
                CreatedDate = DateTime.Now,
                UpdatedDate = null,
                Name = "Google",
                Status = Status.Unused
            });
            _context.Categories.Add(new Categories()
            {
                SysId = Guid.NewGuid(),
                CreatedDate = DateTime.Now,
                UpdatedDate = null,
                Name = "Community",
                Status = Status.Unused
            });
            _context.Categories.Add(new Categories()
            {
                SysId = Guid.NewGuid(),
                CreatedDate = DateTime.Now,
                UpdatedDate = null,
                Name = "Shopping",
                Status = Status.Unused
            });
            _context.Categories.Add(new Categories()
            {
                SysId = Guid.NewGuid(),
                CreatedDate = DateTime.Now,
                UpdatedDate = null,
                Name = "Food Delivery",
                Status = Status.Unused
            });
            _context.SaveChanges();
            #endregion

            #region Websites
            _context.Websites.Add(new Websites()
            {
                SysId = Guid.NewGuid(),
                CreatedDate = DateTime.Now,
                UpdatedDate = null,
                Name = "Stack Overflow",
                Url = "https://stackoverflow.com/",
                Status = Status.Unused
            });
            _context.Websites.Add(new Websites()
            {
                SysId = Guid.NewGuid(),
                CreatedDate = DateTime.Now,
                UpdatedDate = null,
                Name = "Canva",
                Url = "https://canva.com/",
                Status = Status.Unused
            });
            _context.Websites.Add(new Websites()
            {
                SysId = Guid.NewGuid(),
                CreatedDate = DateTime.Now,
                UpdatedDate = null,
                Name = "Github",
                Url = "https://github.com/",
                Status = Status.Unused
            });
            _context.Websites.Add(new Websites()
            {
                SysId = Guid.NewGuid(),
                CreatedDate = DateTime.Now,
                UpdatedDate = null,
                Name = "ChatGPT",
                Url = "https://chat.openai.com/",
                Status = Status.Unused
            });
            _context.Websites.Add(new Websites()
            {
                SysId = Guid.NewGuid(),
                CreatedDate = DateTime.Now,
                UpdatedDate = null,
                Name = "Bard",
                Url = "https://bard.google.com/",
                Status = Status.Unused
            });
            _context.SaveChanges();
            #endregion

            #region Users
            _context.Users.Add(new Users()
            {
                SysId = Guid.NewGuid(),
                CreatedDate = DateTime.Now,
                UpdatedDate = null,
                Name = "Mary119",
                Status = Status.Unused
            });
            _context.Users.Add(new Users()
            {
                SysId = Guid.NewGuid(),
                CreatedDate = DateTime.Now,
                UpdatedDate = null,
                Name = "Hello90s",
                Status = Status.Unused
            });
            _context.Users.Add(new Users()
            {
                SysId = Guid.NewGuid(),
                CreatedDate = DateTime.Now,
                UpdatedDate = null,
                Name = "Maurya222",
                Status = Status.Unused
            });
            _context.Users.Add(new Users()
            {
                SysId = Guid.NewGuid(),
                CreatedDate = DateTime.Now,
                UpdatedDate = null,
                Name = "Tech2000",
                Status = Status.Unused
            });
            _context.SaveChanges();
            #endregion

            #region Emails
            _context.Emails.Add(new Emails()
            {
                SysId = Guid.NewGuid(),
                CreatedDate = DateTime.Now,
                UpdatedDate = null,
                EmailAddress = "harry112@yahoo.com",
                Status = Status.Unused
            });
            _context.Emails.Add(new Emails()
            {
                SysId = Guid.NewGuid(),
                CreatedDate = DateTime.Now,
                UpdatedDate = null,
                EmailAddress = "henry146@hotmail.com",
                Status = Status.Unused
            });
            _context.Emails.Add(new Emails()
            {
                SysId = Guid.NewGuid(),
                CreatedDate = DateTime.Now,
                UpdatedDate = null,
                EmailAddress = "reddit119@outlook.com",
                Status = Status.Unused
            });
            _context.Emails.Add(new Emails()
            {
                SysId = Guid.NewGuid(),
                CreatedDate = DateTime.Now,
                UpdatedDate = null,
                EmailAddress = "avengers3000@gmail.com",
                Status = Status.Unused
            });
            _context.Emails.Add(new Emails()
            {
                SysId = Guid.NewGuid(),
                CreatedDate = DateTime.Now,
                UpdatedDate = null,
                EmailAddress = "hero330@outlook.com",
                Status = Status.Unused
            });
            _context.SaveChanges();
            #endregion
        }

        public override void Down()
        {
        }
    }
}
