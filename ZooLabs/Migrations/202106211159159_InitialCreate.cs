namespace ZooLabs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Animals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TypeId = c.Int(),
                        CageId = c.Int(nullable: false),
                        Name = c.String(),
                        Age = c.Int(nullable: false),
                        Feeding = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cages", t => t.CageId, cascadeDelete: true)
                .ForeignKey("dbo.AnimalTypes", t => t.TypeId)
                .Index(t => t.TypeId)
                .Index(t => t.CageId);
            
            CreateTable(
                "dbo.Cages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TypeId = c.Int(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AnimalTypes", t => t.TypeId)
                .Index(t => t.TypeId);
            
            CreateTable(
                "dbo.AnimalTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Foods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TypeId = c.Int(nullable: false),
                        Name = c.String(),
                        Feeding = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AnimalTypes", t => t.TypeId, cascadeDelete: true)
                .Index(t => t.TypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Foods", "TypeId", "dbo.AnimalTypes");
            DropForeignKey("dbo.Animals", "TypeId", "dbo.AnimalTypes");
            DropForeignKey("dbo.Animals", "CageId", "dbo.Cages");
            DropForeignKey("dbo.Cages", "TypeId", "dbo.AnimalTypes");
            DropIndex("dbo.Foods", new[] { "TypeId" });
            DropIndex("dbo.Cages", new[] { "TypeId" });
            DropIndex("dbo.Animals", new[] { "CageId" });
            DropIndex("dbo.Animals", new[] { "TypeId" });
            DropTable("dbo.Foods");
            DropTable("dbo.AnimalTypes");
            DropTable("dbo.Cages");
            DropTable("dbo.Animals");
        }
    }
}
