namespace Coffee_Table.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingAdminInfoToGroup : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Groups", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Groups", "ApplicationUser_Id");
            AddForeignKey("dbo.Groups", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
          
        }
        
        public override void Down()
        {
            AddColumn("dbo.Groups", "AdminId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Groups", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Groups", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Groups", "ApplicationUser_Id");
        }
    }
}
