namespace API_Proj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addadmin : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AddColumn("dbo.AspNetUsers", "AddressStreet", c => c.String());
            AddColumn("dbo.AspNetUsers", "AddressCity", c => c.String());
            AddColumn("dbo.AspNetUsers", "AddressState", c => c.String());
            AddColumn("dbo.AspNetUsers", "AddressZipcode", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "AddressZipcode");
            DropColumn("dbo.AspNetUsers", "AddressState");
            DropColumn("dbo.AspNetUsers", "AddressCity");
            DropColumn("dbo.AspNetUsers", "AddressStreet");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
        }
    }
}
