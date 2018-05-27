namespace CodeBehind.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteTableTableSet : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tbl_BlockSet", "tbl_blockId", "dbo.tbl_block");
            DropForeignKey("dbo.tbl_BlockSet", "tbl_datesheetId", "dbo.tbl_datesheet");
            DropForeignKey("dbo.tbl_BlockSet", "tbl_subjectDatesheetid", "dbo.tbl_subjectDatesheet");
            DropIndex("dbo.tbl_BlockSet", new[] { "tbl_subjectDatesheetid" });
            DropIndex("dbo.tbl_BlockSet", new[] { "tbl_blockId" });
            DropIndex("dbo.tbl_BlockSet", new[] { "tbl_datesheetId" });
            DropTable("dbo.tbl_BlockSet");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.tbl_BlockSet",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        tbl_subjectDatesheetid = c.Int(),
                        tbl_blockId = c.Int(nullable: false),
                        tbl_datesheetId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateIndex("dbo.tbl_BlockSet", "tbl_datesheetId");
            CreateIndex("dbo.tbl_BlockSet", "tbl_blockId");
            CreateIndex("dbo.tbl_BlockSet", "tbl_subjectDatesheetid");
            AddForeignKey("dbo.tbl_BlockSet", "tbl_subjectDatesheetid", "dbo.tbl_subjectDatesheet", "id");
            AddForeignKey("dbo.tbl_BlockSet", "tbl_datesheetId", "dbo.tbl_datesheet", "id", cascadeDelete: true);
            AddForeignKey("dbo.tbl_BlockSet", "tbl_blockId", "dbo.tbl_block", "id", cascadeDelete: true);
        }
    }
}
