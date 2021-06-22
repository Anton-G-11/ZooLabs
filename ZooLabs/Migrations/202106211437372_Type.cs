namespace ZooLabs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Type : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Cages", name: "TypeId", newName: "AnimalTypeId");
            RenameIndex(table: "dbo.Cages", name: "IX_TypeId", newName: "IX_AnimalTypeId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Cages", name: "IX_AnimalTypeId", newName: "IX_TypeId");
            RenameColumn(table: "dbo.Cages", name: "AnimalTypeId", newName: "TypeId");
        }
    }
}
