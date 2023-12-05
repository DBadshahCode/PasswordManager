namespace PasswordManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Accounts", "PasswordId", "dbo.Passwords");
            DropForeignKey("dbo.Accounts", "PinId", "dbo.Pins");
            DropIndex("dbo.Accounts", new[] { "PasswordId" });
            DropIndex("dbo.Accounts", new[] { "PinId" });
            AddColumn("dbo.Passwords", "AccountId", c => c.Guid());
            AddColumn("dbo.Pins", "AccountId", c => c.Guid());
            CreateIndex("dbo.Passwords", "AccountId");
            CreateIndex("dbo.Pins", "AccountId");
            AddForeignKey("dbo.Passwords", "AccountId", "dbo.Accounts", "SysId");
            AddForeignKey("dbo.Pins", "AccountId", "dbo.Accounts", "SysId");
            DropColumn("dbo.Accounts", "PasswordId");
            DropColumn("dbo.Accounts", "PinId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Accounts", "PinId", c => c.Guid());
            AddColumn("dbo.Accounts", "PasswordId", c => c.Guid());
            DropForeignKey("dbo.Pins", "AccountId", "dbo.Accounts");
            DropForeignKey("dbo.Passwords", "AccountId", "dbo.Accounts");
            DropIndex("dbo.Pins", new[] { "AccountId" });
            DropIndex("dbo.Passwords", new[] { "AccountId" });
            DropColumn("dbo.Pins", "AccountId");
            DropColumn("dbo.Passwords", "AccountId");
            CreateIndex("dbo.Accounts", "PinId");
            CreateIndex("dbo.Accounts", "PasswordId");
            AddForeignKey("dbo.Accounts", "PinId", "dbo.Pins", "SysId");
            AddForeignKey("dbo.Accounts", "PasswordId", "dbo.Passwords", "SysId");
        }
    }
}
