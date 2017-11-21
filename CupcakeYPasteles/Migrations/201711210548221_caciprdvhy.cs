namespace CupcakeYPasteles.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class caciprdvhy : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Gastoes", "valor", c => c.Int(nullable: false));
            AlterColumn("dbo.Ingresoes", "valor", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Ingresoes", "valor", c => c.Double(nullable: false));
            AlterColumn("dbo.Gastoes", "valor", c => c.Double(nullable: false));
        }
    }
}
