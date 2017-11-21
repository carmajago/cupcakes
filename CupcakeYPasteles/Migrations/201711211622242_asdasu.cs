namespace CupcakeYPasteles.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asdasu : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Gastoes", "cantidad", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Gastoes", "cantidad", c => c.String());
        }
    }
}
