namespace Coffee_Table.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingEventsToDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Subject = c.String(nullable: false),
                        Description = c.String(),
                        Start = c.DateTime(nullable: false),
                        End = c.DateTime(),
                        ThemeColor = c.String(),
                        isFullDay = c.Boolean(nullable: false),
                        GroupId = c.Int(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Groups", t => t.GroupId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.GroupId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Events", "GroupId", "dbo.Groups");
            DropIndex("dbo.Events", new[] { "UserId" });
            DropIndex("dbo.Events", new[] { "GroupId" });
            DropTable("dbo.Events");
        }
    }
}
