namespace CodeBehind.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAgainBlockSetToDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbl_BlockSet",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        tbl_subjectDatesheetid = c.Int(nullable: false),
                        tbl_blockId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.tbl_block", t => t.tbl_blockId, cascadeDelete: true)
                .ForeignKey("dbo.tbl_subjectDatesheet", t => t.tbl_subjectDatesheetid, cascadeDelete: true)
                .Index(t => t.tbl_subjectDatesheetid)
                .Index(t => t.tbl_blockId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tbl_BlockSet", "tbl_subjectDatesheetid", "dbo.tbl_subjectDatesheet");
            DropForeignKey("dbo.tbl_BlockSet", "tbl_blockId", "dbo.tbl_block");
            DropIndex("dbo.tbl_BlockSet", new[] { "tbl_blockId" });
            DropIndex("dbo.tbl_BlockSet", new[] { "tbl_subjectDatesheetid" });
            DropTable("dbo.tbl_BlockSet");
        }
    }
}
