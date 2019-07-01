namespace Coffee_Table.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class returnToprevius : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Groups", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Groups", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Groups", "ApplicationUser_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Groups", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Groups", "ApplicationUser_Id");
            AddForeignKey("dbo.Groups", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
