namespace API_Proj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ExpenseCategories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Total = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Expenses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Payee = c.String(),
                        Total = c.Double(nullable: false),
                        CategoryID = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Revenues",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PayerID = c.Int(nullable: false),
                        Total = c.Double(nullable: false),
                        CategoryID = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Revenues");
            DropTable("dbo.Expenses");
            DropTable("dbo.ExpenseCategories");
        }
    }
}
