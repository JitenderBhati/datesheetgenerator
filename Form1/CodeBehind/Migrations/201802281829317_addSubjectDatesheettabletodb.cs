namespace CodeBehind.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addSubjectDatesheettabletodb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbl_subjectDatesheet",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        tbl_subjectId = c.Int(nullable: false),
                        date = c.DateTime(nullable: false),
                        shift = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.tbl_subject", t => t.tbl_subjectId, cascadeDelete: true)
                .Index(t => t.tbl_subjectId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tbl_subjectDatesheet", "tbl_subjectId", "dbo.tbl_subject");
            DropIndex("dbo.tbl_subjectDatesheet", new[] { "tbl_subjectId" });
            DropTable("dbo.tbl_subjectDatesheet");
        }
    }
}
