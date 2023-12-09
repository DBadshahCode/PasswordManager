namespace PasswordManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init5 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Phones", "Number", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Phones", "Number", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
