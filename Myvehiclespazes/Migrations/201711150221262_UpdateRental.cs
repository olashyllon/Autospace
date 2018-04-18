namespace Myvehiclespazes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateRental : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Rentals", "Rentalamount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rentals", "Rentalamount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
