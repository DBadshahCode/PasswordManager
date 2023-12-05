namespace PasswordManager.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class Init1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                {
                    SysId = c.Guid(nullable: false),
                    CreatedDate = c.DateTime(nullable: false),
                    UpdatedDate = c.DateTime(),
                    Name = c.String(),
                    CategoryId = c.Guid(),
                    WebsiteId = c.Guid(),
                    UserId = c.Guid(),
                    PasswordId = c.Guid(),
                    PinId = c.Guid(),
                    EmailId = c.Guid(),
                    PhoneId = c.Guid(),
                    SecurityType = c.Int(nullable: false),
                    Comments = c.String(),
                    Closed = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.SysId)
                .ForeignKey("dbo.Categories", t => t.CategoryId)
                .ForeignKey("dbo.Emails", t => t.EmailId)
                .ForeignKey("dbo.Passwords", t => t.PasswordId)
                .ForeignKey("dbo.Phones", t => t.PhoneId)
                .ForeignKey("dbo.Pins", t => t.PinId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .ForeignKey("dbo.Websites", t => t.WebsiteId)
                .Index(t => t.CategoryId)
                .Index(t => t.WebsiteId)
                .Index(t => t.UserId)
                .Index(t => t.PasswordId)
                .Index(t => t.PinId)
                .Index(t => t.EmailId)
                .Index(t => t.PhoneId);

            CreateTable(
                "dbo.Categories",
                c => new
                {
                    SysId = c.Guid(nullable: false),
                    CreatedDate = c.DateTime(nullable: false),
                    UpdatedDate = c.DateTime(),
                    Name = c.String(),
                    Status = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.SysId);

            CreateTable(
                "dbo.Emails",
                c => new
                {
                    SysId = c.Guid(nullable: false),
                    CreatedDate = c.DateTime(nullable: false),
                    UpdatedDate = c.DateTime(),
                    EmailAddress = c.String(),
                    Status = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.SysId);

            CreateTable(
                "dbo.Passwords",
                c => new
                {
                    SysId = c.Guid(nullable: false),
                    CreatedDate = c.DateTime(nullable: false),
                    UpdatedDate = c.DateTime(),
                    Password = c.String(),
                    PasswordGenerated = c.Boolean(nullable: false),
                    Status = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.SysId);

            CreateTable(
                "dbo.Phones",
                c => new
                {
                    SysId = c.Guid(nullable: false),
                    CreatedDate = c.DateTime(nullable: false),
                    UpdatedDate = c.DateTime(),
                    Number = c.Decimal(nullable: false, precision: 18, scale: 2),
                    Status = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.SysId);

            CreateTable(
                "dbo.Pins",
                c => new
                {
                    SysId = c.Guid(nullable: false),
                    CreatedDate = c.DateTime(nullable: false),
                    UpdatedDate = c.DateTime(),
                    Pin = c.Decimal(nullable: false, precision: 18, scale: 2),
                    PinGenerated = c.Boolean(nullable: false),
                    Status = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.SysId);

            CreateTable(
                "dbo.Users",
                c => new
                {
                    SysId = c.Guid(nullable: false),
                    CreatedDate = c.DateTime(nullable: false),
                    UpdatedDate = c.DateTime(),
                    Name = c.String(),
                    Status = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.SysId);

            CreateTable(
                "dbo.Websites",
                c => new
                {
                    SysId = c.Guid(nullable: false),
                    CreatedDate = c.DateTime(nullable: false),
                    UpdatedDate = c.DateTime(),
                    Name = c.String(),
                    Url = c.String(),
                    Status = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.SysId);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Accounts", "WebsiteId", "dbo.Websites");
            DropForeignKey("dbo.Accounts", "UserId", "dbo.Users");
            DropForeignKey("dbo.Accounts", "PinId", "dbo.Pins");
            DropForeignKey("dbo.Accounts", "PhoneId", "dbo.Phones");
            DropForeignKey("dbo.Accounts", "PasswordId", "dbo.Passwords");
            DropForeignKey("dbo.Accounts", "EmailId", "dbo.Emails");
            DropForeignKey("dbo.Accounts", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Accounts", new[] { "PhoneId" });
            DropIndex("dbo.Accounts", new[] { "EmailId" });
            DropIndex("dbo.Accounts", new[] { "PinId" });
            DropIndex("dbo.Accounts", new[] { "PasswordId" });
            DropIndex("dbo.Accounts", new[] { "UserId" });
            DropIndex("dbo.Accounts", new[] { "WebsiteId" });
            DropIndex("dbo.Accounts", new[] { "CategoryId" });
            DropTable("dbo.Websites");
            DropTable("dbo.Users");
            DropTable("dbo.Pins");
            DropTable("dbo.Phones");
            DropTable("dbo.Passwords");
            DropTable("dbo.Emails");
            DropTable("dbo.Categories");
            DropTable("dbo.Accounts");
        }
    }
}
