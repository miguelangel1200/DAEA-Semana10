namespace MVCCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2_CreateAll : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                    })
                .PrimaryKey(t => t.CustomerID);
            
            CreateTable(
                "dbo.Details",
                c => new
                    {
                        DetailID = c.Int(nullable: false, identity: true),
                        Price = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        InvoiceID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DetailID)
                .ForeignKey("dbo.Invoices", t => t.InvoiceID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ProductID)
                .Index(t => t.InvoiceID);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        InvoiceID = c.Int(nullable: false, identity: true),
                        CreatedOn = c.DateTime(nullable: false),
                        CustomerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvoiceID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Details", "ProductID", "dbo.Products");
            DropForeignKey("dbo.Details", "InvoiceID", "dbo.Invoices");
            DropIndex("dbo.Details", new[] { "InvoiceID" });
            DropIndex("dbo.Details", new[] { "ProductID" });
            DropTable("dbo.Invoices");
            DropTable("dbo.Details");
            DropTable("dbo.Customers");
        }
    }
}
