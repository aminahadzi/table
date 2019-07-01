namespace Coffee_Table.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingGroupUsersToDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GroupUsers",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        applicationUserId = c.String(nullable: false, maxLength: 128),
                        groupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.AspNetUsers", t => t.applicationUserId, cascadeDelete: false)
                .ForeignKey("dbo.Groups", t => t.groupId, cascadeDelete: false)
                .Index(t => t.applicationUserId)
                .Index(t => t.groupId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GroupUsers", "groupId", "dbo.Groups");
            DropForeignKey("dbo.GroupUsers", "applicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.GroupUsers", new[] { "groupId" });
            DropIndex("dbo.GroupUsers", new[] { "applicationUserId" });
            DropTable("dbo.GroupUsers");
        }
    }
}
