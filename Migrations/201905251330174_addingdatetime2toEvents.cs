namespace Coffee_Table.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingdatetime2toEvents : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Events", "Start", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Events", "Start", c => c.DateTime(nullable: false));
        }
    }
}
