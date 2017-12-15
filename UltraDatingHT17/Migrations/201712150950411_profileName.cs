namespace UltraDatingHT17.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class profileName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Profilename", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Profilename");
        }
    }
}
