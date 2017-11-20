namespace CupcakeYPasteles.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cascasfsa : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Materials", "nombre", c => c.String(nullable: false));
            AlterColumn("dbo.Productoes", "nombre", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Productoes", "nombre", c => c.String());
            AlterColumn("dbo.Materials", "nombre", c => c.String());
        }
    }
}
