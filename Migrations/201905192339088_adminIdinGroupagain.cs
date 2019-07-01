namespace Coffee_Table.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adminIdinGroupagain : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Groups", name: "applicationUser_Id", newName: "applicationUserId");
            RenameIndex(table: "dbo.Groups", name: "IX_applicationUser_Id", newName: "IX_applicationUserId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Groups", name: "IX_applicationUserId", newName: "IX_applicationUser_Id");
            RenameColumn(table: "dbo.Groups", name: "applicationUserId", newName: "applicationUser_Id");
        }
    }
}
