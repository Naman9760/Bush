namespace Bush.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m8 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Empolyees", "Maneger", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Empolyees", "Maneger");
        }
    }
}
