namespace Coffee_Table.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _201905191335591_InitialCreate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Name", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "Surname", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "BirthDate", c => c.DateTime());
            AddColumn("dbo.AspNetUsers", "isGroupAdmin", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "GroupId", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "GroupId");
            DropColumn("dbo.AspNetUsers", "isGroupAdmin");
            DropColumn("dbo.AspNetUsers", "BirthDate");
            DropColumn("dbo.AspNetUsers", "Surname");
            DropColumn("dbo.AspNetUsers", "Name");
        }
    }
}
