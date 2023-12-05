namespace PasswordManager.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class Init4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pins", "Length", c => c.Int(nullable: false));
            DropColumn("dbo.Pins", "MinValue");
            DropColumn("dbo.Pins", "MaxValue");
        }

        public override void Down()
        {
            AddColumn("dbo.Pins", "MaxValue", c => c.Int(nullable: false));
            AddColumn("dbo.Pins", "MinValue", c => c.Int(nullable: false));
            DropColumn("dbo.Pins", "Length");
        }
    }
}
