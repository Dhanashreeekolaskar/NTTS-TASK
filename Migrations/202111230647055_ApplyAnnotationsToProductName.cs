namespace ProjectTask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyAnnotationsToProductName : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categories", "CategoryName", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "ProductName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "ProductName", c => c.String());
            AlterColumn("dbo.Categories", "CategoryName", c => c.String());
        }
    }
}
