namespace Myvehiclespazes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateModels : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Invoices", "RentalId", "dbo.Rentals");
            DropIndex("dbo.Invoices", new[] { "RentalId" });
            DropPrimaryKey("dbo.Invoices");
            AddColumn("dbo.Rentals", "Invoice_InvoiceId", c => c.Int());
            AddColumn("dbo.Invoices", "InvoiceId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Invoices", "InvoiceId");
            CreateIndex("dbo.Rentals", "Invoice_InvoiceId");
            AddForeignKey("dbo.Rentals", "Invoice_InvoiceId", "dbo.Invoices", "InvoiceId");
            DropColumn("dbo.Invoices", "RentalId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Invoices", "RentalId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Rentals", "Invoice_InvoiceId", "dbo.Invoices");
            DropIndex("dbo.Rentals", new[] { "Invoice_InvoiceId" });
            DropPrimaryKey("dbo.Invoices");
            DropColumn("dbo.Invoices", "InvoiceId");
            DropColumn("dbo.Rentals", "Invoice_InvoiceId");
            AddPrimaryKey("dbo.Invoices", "RentalId");
            CreateIndex("dbo.Invoices", "RentalId");
            AddForeignKey("dbo.Invoices", "RentalId", "dbo.Rentals", "RentalId");
        }
    }
}
