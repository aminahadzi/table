namespace Coffee_Table.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class endToDateTime2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Events", "End", c => c.DateTime(precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Events", "End", c => c.DateTime());
        }
    }
}
