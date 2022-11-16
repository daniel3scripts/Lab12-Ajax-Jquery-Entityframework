namespace CodeFirstDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v5foreignkey : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(),
                        CustomerLastName = c.String(),
                        Dni = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerID);
            
            CreateTable(
                "dbo.EnvoiceDetails",
                c => new
                    {
                        EnvoiceDetailID = c.Int(nullable: false, identity: true),
                        InvoiceID = c.Int(nullable: false),
                        CustomerID = c.Int(nullable: false),
                        SellerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EnvoiceDetailID)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .ForeignKey("dbo.Invoices", t => t.InvoiceID, cascadeDelete: true)
                .ForeignKey("dbo.Sellers", t => t.SellerId, cascadeDelete: true)
                .Index(t => t.InvoiceID)
                .Index(t => t.CustomerID)
                .Index(t => t.SellerId);
            
            CreateTable(
                "dbo.Sellers",
                c => new
                    {
                        SellerId = c.Int(nullable: false, identity: true),
                        SellerName = c.String(),
                        SellerLastName = c.String(),
                        Dni = c.String(),
                        Email = c.String(),
                        Ruc = c.String(),
                        SellerDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.SellerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EnvoiceDetails", "SellerId", "dbo.Sellers");
            DropForeignKey("dbo.EnvoiceDetails", "InvoiceID", "dbo.Invoices");
            DropForeignKey("dbo.EnvoiceDetails", "CustomerID", "dbo.Customers");
            DropIndex("dbo.EnvoiceDetails", new[] { "SellerId" });
            DropIndex("dbo.EnvoiceDetails", new[] { "CustomerID" });
            DropIndex("dbo.EnvoiceDetails", new[] { "InvoiceID" });
            DropTable("dbo.Sellers");
            DropTable("dbo.EnvoiceDetails");
            DropTable("dbo.Customers");
        }
    }
}
