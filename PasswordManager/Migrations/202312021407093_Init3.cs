namespace PasswordManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Passwords", "Length", c => c.Int(nullable: false));
            AddColumn("dbo.Passwords", "Generated", c => c.Boolean(nullable: false));
            AddColumn("dbo.Pins", "MinValue", c => c.Int(nullable: false));
            AddColumn("dbo.Pins", "MaxValue", c => c.Int(nullable: false));
            AddColumn("dbo.Pins", "Generated", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Pins", "Pin", c => c.Int(nullable: false));
            DropColumn("dbo.Passwords", "PasswordGenerated");
            DropColumn("dbo.Pins", "PinGenerated");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pins", "PinGenerated", c => c.Boolean(nullable: false));
            AddColumn("dbo.Passwords", "PasswordGenerated", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Pins", "Pin", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Pins", "Generated");
            DropColumn("dbo.Pins", "MaxValue");
            DropColumn("dbo.Pins", "MinValue");
            DropColumn("dbo.Passwords", "Generated");
            DropColumn("dbo.Passwords", "Length");
        }
    }
}
