namespace CodeBehind.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addBlocksetTableToDb1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbl_BlockSet",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        tbl_subjectDateshhetid = c.Int(nullable: false),
                        tbl_blockId = c.Int(nullable: false),
                        subject_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.tbl_block", t => t.tbl_blockId, cascadeDelete: true)
                .ForeignKey("dbo.tbl_subjectDatesheet", t => t.subject_id)
                .Index(t => t.tbl_blockId)
                .Index(t => t.subject_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tbl_BlockSet", "subject_id", "dbo.tbl_subjectDatesheet");
            DropForeignKey("dbo.tbl_BlockSet", "tbl_blockId", "dbo.tbl_block");
            DropIndex("dbo.tbl_BlockSet", new[] { "subject_id" });
            DropIndex("dbo.tbl_BlockSet", new[] { "tbl_blockId" });
            DropTable("dbo.tbl_BlockSet");
        }
    }
}
