namespace CupcakeYPasteles.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class caciprdvodks : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DineroEnCajas", "dinero", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DineroEnCajas", "dinero", c => c.Double(nullable: false));
        }
    }
}
