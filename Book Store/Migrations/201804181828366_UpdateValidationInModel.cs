namespace Book_Store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateValidationInModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Books", "Author", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Books", "Author", c => c.String(nullable: false, maxLength: 255));
        }
    }
}
