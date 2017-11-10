namespace CupcakeYPasteles.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mg1carlos2112 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DineroEnCajas",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        fecha = c.DateTime(nullable: false),
                        dinero = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DineroEnCajas");
        }
    }
}
