namespace Coffee_Table.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class returnToprevius2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Groups", "ApplicationUserId");
        }
        
        public override void Down()
        {
        }
    }
}
