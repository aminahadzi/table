namespace Coffee_Table.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Groups", "applicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Groups", new[] { "applicationUserId" });
            AlterColumn("dbo.Groups", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Groups", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.Groups", "applicationUserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Groups", "applicationUserId");
            AddForeignKey("dbo.Groups", "applicationUserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Groups", "applicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Groups", new[] { "applicationUserId" });
            AlterColumn("dbo.Groups", "applicationUserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Groups", "Password", c => c.String());
            AlterColumn("dbo.Groups", "Name", c => c.String());
            CreateIndex("dbo.Groups", "applicationUserId");
            AddForeignKey("dbo.Groups", "applicationUserId", "dbo.AspNetUsers", "Id");
        }
    }
}
