namespace CupcakeYPasteles.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cascasf34rescv : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Ingresoes", "Material_id", "dbo.Materials");
            DropIndex("dbo.Ingresoes", new[] { "Material_id" });
            DropColumn("dbo.Ingresoes", "Material_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ingresoes", "Material_id", c => c.Int());
            CreateIndex("dbo.Ingresoes", "Material_id");
            AddForeignKey("dbo.Ingresoes", "Material_id", "dbo.Materials", "id");
        }
    }
}
