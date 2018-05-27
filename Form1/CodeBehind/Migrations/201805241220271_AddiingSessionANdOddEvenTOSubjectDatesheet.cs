namespace CodeBehind.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddiingSessionANdOddEvenTOSubjectDatesheet : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbl_subjectDatesheet", "session", c => c.Int(nullable: false));
            AddColumn("dbo.tbl_subjectDatesheet", "odd_even", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tbl_subjectDatesheet", "odd_even");
            DropColumn("dbo.tbl_subjectDatesheet", "session");
        }
    }
}
