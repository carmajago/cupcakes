namespace CupcakeYPasteles.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class caciprd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ingresoes", "cantidad", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Ingresoes", "cantidad");
        }
    }
}
