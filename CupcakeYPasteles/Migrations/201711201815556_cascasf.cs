namespace CupcakeYPasteles.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cascasf : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Gastoes", "productofk", "dbo.Productoes");
            DropIndex("dbo.Gastoes", new[] { "productofk" });
            CreateTable(
                "dbo.Materials",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.Gastoes", "materialFK", c => c.Int(nullable: false));
            AddColumn("dbo.Ingresoes", "Material_id", c => c.Int());
            AlterColumn("dbo.Productoes", "nombre", c => c.String());
            CreateIndex("dbo.Gastoes", "materialFK");
            CreateIndex("dbo.Ingresoes", "Material_id");
            AddForeignKey("dbo.Ingresoes", "Material_id", "dbo.Materials", "id");
            AddForeignKey("dbo.Gastoes", "materialFK", "dbo.Materials", "id", cascadeDelete: true);
            DropColumn("dbo.Gastoes", "productofk");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Gastoes", "productofk", c => c.Int(nullable: false));
            DropForeignKey("dbo.Gastoes", "materialFK", "dbo.Materials");
            DropForeignKey("dbo.Ingresoes", "Material_id", "dbo.Materials");
            DropIndex("dbo.Ingresoes", new[] { "Material_id" });
            DropIndex("dbo.Gastoes", new[] { "materialFK" });
            AlterColumn("dbo.Productoes", "nombre", c => c.Int(nullable: false));
            DropColumn("dbo.Ingresoes", "Material_id");
            DropColumn("dbo.Gastoes", "materialFK");
            DropTable("dbo.Materials");
            CreateIndex("dbo.Gastoes", "productofk");
            AddForeignKey("dbo.Gastoes", "productofk", "dbo.Productoes", "id", cascadeDelete: true);
        }
    }
}
