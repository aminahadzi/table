namespace Coffee_Table.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingAdminIdToGroup : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Groups", "ApplicationUserId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Groups", "ApplicationUserId");
        }
    }
}
