namespace API_Proj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clients", "Expense_ID", c => c.Int());
            AddColumn("dbo.Clients", "Revenue_ID", c => c.Int());
            CreateIndex("dbo.Clients", "Expense_ID");
            CreateIndex("dbo.Clients", "Revenue_ID");
            AddForeignKey("dbo.Clients", "Expense_ID", "dbo.Expenses", "ID");
            AddForeignKey("dbo.Clients", "Revenue_ID", "dbo.Revenues", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Clients", "Revenue_ID", "dbo.Revenues");
            DropForeignKey("dbo.Clients", "Expense_ID", "dbo.Expenses");
            DropIndex("dbo.Clients", new[] { "Revenue_ID" });
            DropIndex("dbo.Clients", new[] { "Expense_ID" });
            DropColumn("dbo.Clients", "Revenue_ID");
            DropColumn("dbo.Clients", "Expense_ID");
        }
    }
}
