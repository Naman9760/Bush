namespace Bush.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m21 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Empolyees", "Post", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Empolyees", "Post");
        }
    }
}
