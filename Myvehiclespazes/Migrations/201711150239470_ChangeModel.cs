namespace Myvehiclespazes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rentals", "Invoice_InvoiceId", "dbo.Invoices");
            DropIndex("dbo.Rentals", new[] { "Invoice_InvoiceId" });
            DropColumn("dbo.Rentals", "Invoice_InvoiceId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rentals", "Invoice_InvoiceId", c => c.Int());
            CreateIndex("dbo.Rentals", "Invoice_InvoiceId");
            AddForeignKey("dbo.Rentals", "Invoice_InvoiceId", "dbo.Invoices", "InvoiceId");
        }
    }
}
