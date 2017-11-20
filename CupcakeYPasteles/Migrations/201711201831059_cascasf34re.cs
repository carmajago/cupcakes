namespace CupcakeYPasteles.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cascasf34re : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Gastoes", "nombre");
            DropColumn("dbo.Ingresoes", "nombre");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ingresoes", "nombre", c => c.String(nullable: false));
            AddColumn("dbo.Gastoes", "nombre", c => c.String(nullable: false));
        }
    }
}
