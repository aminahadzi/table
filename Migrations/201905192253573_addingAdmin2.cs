namespace Coffee_Table.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingAdmin2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Groups", "applicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Groups", "applicationUser_Id");
            AddForeignKey("dbo.Groups", "applicationUser_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Groups", "applicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Groups", new[] { "applicationUser_Id" });
            DropColumn("dbo.Groups", "applicationUser_Id");
        }
    }
}
