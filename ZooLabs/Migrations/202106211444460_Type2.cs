namespace ZooLabs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Type2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Animals", name: "TypeId", newName: "AnimalTypeId");
            RenameIndex(table: "dbo.Animals", name: "IX_TypeId", newName: "IX_AnimalTypeId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Animals", name: "IX_AnimalTypeId", newName: "IX_TypeId");
            RenameColumn(table: "dbo.Animals", name: "AnimalTypeId", newName: "TypeId");
        }
    }
}
