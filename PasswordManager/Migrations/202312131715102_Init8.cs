namespace PasswordManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init8 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Accounts", "EmailId", "dbo.Emails");
            DropForeignKey("dbo.Accounts", "PhoneId", "dbo.Phones");
            DropForeignKey("dbo.Accounts", "UserId", "dbo.Users");
            DropIndex("dbo.Accounts", new[] { "UserId" });
            DropIndex("dbo.Accounts", new[] { "EmailId" });
            DropIndex("dbo.Accounts", new[] { "PhoneId" });
            AddColumn("dbo.Accounts", "Username", c => c.String());
            AddColumn("dbo.Accounts", "EmailAddress", c => c.String());
            AddColumn("dbo.Accounts", "MobileNumber", c => c.String());
            DropColumn("dbo.Accounts", "UserId");
            DropColumn("dbo.Accounts", "EmailId");
            DropColumn("dbo.Accounts", "PhoneId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Accounts", "PhoneId", c => c.Guid());
            AddColumn("dbo.Accounts", "EmailId", c => c.Guid());
            AddColumn("dbo.Accounts", "UserId", c => c.Guid());
            DropColumn("dbo.Accounts", "MobileNumber");
            DropColumn("dbo.Accounts", "EmailAddress");
            DropColumn("dbo.Accounts", "Username");
            CreateIndex("dbo.Accounts", "PhoneId");
            CreateIndex("dbo.Accounts", "EmailId");
            CreateIndex("dbo.Accounts", "UserId");
            AddForeignKey("dbo.Accounts", "UserId", "dbo.Users", "SysId");
            AddForeignKey("dbo.Accounts", "PhoneId", "dbo.Phones", "SysId");
            AddForeignKey("dbo.Accounts", "EmailId", "dbo.Emails", "SysId");
        }
    }
}
