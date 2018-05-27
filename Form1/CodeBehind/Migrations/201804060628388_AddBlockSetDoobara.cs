namespace CodeBehind.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBlockSetDoobara : DbMigration
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
        }
    }
}
