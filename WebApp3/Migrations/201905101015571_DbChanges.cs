namespace WebApp3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DbChanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Phone", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Phone");
        }
    }
}
