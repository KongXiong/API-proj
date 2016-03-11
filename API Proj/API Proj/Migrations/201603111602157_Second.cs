namespace API_Proj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Second : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Expenses", "RegisteredUserID", "dbo.RegisteredUsers");
            DropForeignKey("dbo.Revenues", "RegisteredUserID", "dbo.RegisteredUsers");
            DropIndex("dbo.Expenses", new[] { "RegisteredUserID" });
            DropIndex("dbo.Revenues", new[] { "RegisteredUserID" });
            AddColumn("dbo.Clients", "RegisteredUserID", c => c.String());
            AddColumn("dbo.Clients", "RegisteredUser_ID", c => c.Int());
            AddColumn("dbo.Expenses", "RegisteredUser_ID", c => c.Int());
            AddColumn("dbo.Revenues", "RegisteredUser_ID", c => c.Int());
            AlterColumn("dbo.Expenses", "RegisteredUserID", c => c.String());
            AlterColumn("dbo.Revenues", "RegisteredUserID", c => c.String());
            CreateIndex("dbo.Clients", "RegisteredUser_ID");
            CreateIndex("dbo.Expenses", "RegisteredUser_ID");
            CreateIndex("dbo.Revenues", "RegisteredUser_ID");
            AddForeignKey("dbo.Clients", "RegisteredUser_ID", "dbo.RegisteredUsers", "ID");
            AddForeignKey("dbo.Expenses", "RegisteredUser_ID", "dbo.RegisteredUsers", "ID");
            AddForeignKey("dbo.Revenues", "RegisteredUser_ID", "dbo.RegisteredUsers", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Revenues", "RegisteredUser_ID", "dbo.RegisteredUsers");
            DropForeignKey("dbo.Expenses", "RegisteredUser_ID", "dbo.RegisteredUsers");
            DropForeignKey("dbo.Clients", "RegisteredUser_ID", "dbo.RegisteredUsers");
            DropIndex("dbo.Revenues", new[] { "RegisteredUser_ID" });
            DropIndex("dbo.Expenses", new[] { "RegisteredUser_ID" });
            DropIndex("dbo.Clients", new[] { "RegisteredUser_ID" });
            AlterColumn("dbo.Revenues", "RegisteredUserID", c => c.Int(nullable: false));
            AlterColumn("dbo.Expenses", "RegisteredUserID", c => c.Int(nullable: false));
            DropColumn("dbo.Revenues", "RegisteredUser_ID");
            DropColumn("dbo.Expenses", "RegisteredUser_ID");
            DropColumn("dbo.Clients", "RegisteredUser_ID");
            DropColumn("dbo.Clients", "RegisteredUserID");
            CreateIndex("dbo.Revenues", "RegisteredUserID");
            CreateIndex("dbo.Expenses", "RegisteredUserID");
            AddForeignKey("dbo.Revenues", "RegisteredUserID", "dbo.RegisteredUsers", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Expenses", "RegisteredUserID", "dbo.RegisteredUsers", "ID", cascadeDelete: true);
        }
    }
}
