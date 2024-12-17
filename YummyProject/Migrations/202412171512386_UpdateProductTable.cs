namespace YummyProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateProductTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "ImageUrl", c => c.String());
            DropColumn("dbo.Products", "CategoryName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "CategoryName", c => c.String());
            DropColumn("dbo.Products", "ImageUrl");
        }
    }
}
