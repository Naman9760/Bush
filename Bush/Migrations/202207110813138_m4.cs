namespace Bush.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Empolyees", "Department", c => c.String());
            DropColumn("dbo.Empolyees", "Post");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Empolyees", "Post", c => c.String());
            DropColumn("dbo.Empolyees", "Department");
        }
    }
}
