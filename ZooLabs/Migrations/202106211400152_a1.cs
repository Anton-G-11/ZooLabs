namespace ZooLabs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Animals", "CageId", "dbo.Cages");
            DropIndex("dbo.Animals", new[] { "CageId" });
            AlterColumn("dbo.Animals", "CageId", c => c.Int());
            CreateIndex("dbo.Animals", "CageId");
            AddForeignKey("dbo.Animals", "CageId", "dbo.Cages", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Animals", "CageId", "dbo.Cages");
            DropIndex("dbo.Animals", new[] { "CageId" });
            AlterColumn("dbo.Animals", "CageId", c => c.Int(nullable: false));
            CreateIndex("dbo.Animals", "CageId");
            AddForeignKey("dbo.Animals", "CageId", "dbo.Cages", "Id", cascadeDelete: true);
        }
    }
}
