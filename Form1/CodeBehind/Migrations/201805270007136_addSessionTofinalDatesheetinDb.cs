namespace CodeBehind.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addSessionTofinalDatesheetinDb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbl_finalDatesheet", "session", c => c.Int(nullable: false));
            AddColumn("dbo.tbl_finalDatesheet", "odd_even", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tbl_finalDatesheet", "odd_even");
            DropColumn("dbo.tbl_finalDatesheet", "session");
        }
    }
}
