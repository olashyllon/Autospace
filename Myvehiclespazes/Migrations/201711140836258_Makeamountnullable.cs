namespace Myvehiclespazes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Makeamountnullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Invoices", "Amount", c => c.Decimal(storeType: "money"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Invoices", "Amount", c => c.Decimal(nullable: false, storeType: "money"));
        }
    }
}
