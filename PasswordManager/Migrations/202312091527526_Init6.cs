namespace PasswordManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init6 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Phones", "Number", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Phones", "Number", c => c.Int(nullable: false));
        }
    }
}
