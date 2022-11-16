namespace CodeFirstDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v6anotationschanges : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "CustomerLastName", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "Dni", c => c.String(nullable: false, maxLength: 8));
            AlterColumn("dbo.Invoices", "InvoiceNumber", c => c.String(nullable: false, maxLength: 8));
            AlterColumn("dbo.Products", "Name", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Sellers", "Dni", c => c.String(nullable: false, maxLength: 8));
            AlterColumn("dbo.Sellers", "Ruc", c => c.String(nullable: false, maxLength: 11));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Sellers", "Ruc", c => c.String());
            AlterColumn("dbo.Sellers", "Dni", c => c.String());
            AlterColumn("dbo.Products", "Name", c => c.String());
            AlterColumn("dbo.Invoices", "InvoiceNumber", c => c.String());
            AlterColumn("dbo.Customers", "Dni", c => c.String());
            AlterColumn("dbo.Customers", "CustomerLastName", c => c.String());
        }
    }
}
