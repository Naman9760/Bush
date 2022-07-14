namespace Bush.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Empolyees",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        age = c.Int(nullable: false),
                        salary = c.Int(nullable: false),
                        gender = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Empolyees");
        }
    }
}
