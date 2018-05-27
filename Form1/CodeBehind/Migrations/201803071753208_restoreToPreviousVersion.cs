namespace CodeBehind.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class restoreToPreviousVersion : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tbl_datesheet", "tbl_blockId", "dbo.tbl_block");
            DropForeignKey("dbo.tbl_datesheet", "tbl_subjectId", "dbo.tbl_subject");
            DropIndex("dbo.tbl_datesheet", new[] { "tbl_blockId" });
            DropIndex("dbo.tbl_datesheet", new[] { "tbl_subjectId" });
            CreateTable(
                "dbo.tbl_subjectDatesheet",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        date = c.DateTime(nullable: false),
                        shift = c.Int(nullable: false),
                        tbl_datesheetId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.tbl_datesheet", t => t.tbl_datesheetId, cascadeDelete: true)
                .Index(t => t.tbl_datesheetId);
            
            AddColumn("dbo.tbl_datesheet", "tbl_typeId", c => c.Int(nullable: false));
            AddColumn("dbo.tbl_datesheet", "tbl_courseId", c => c.Int(nullable: false));
            AddColumn("dbo.tbl_datesheet", "tbl_semesterId", c => c.Int(nullable: false));
            CreateIndex("dbo.tbl_datesheet", "tbl_typeId");
            CreateIndex("dbo.tbl_datesheet", "tbl_courseId");
            CreateIndex("dbo.tbl_datesheet", "tbl_semesterId");
            AddForeignKey("dbo.tbl_datesheet", "tbl_courseId", "dbo.tbl_course", "id", cascadeDelete: true);
            AddForeignKey("dbo.tbl_datesheet", "tbl_semesterId", "dbo.tbl_semester", "id", cascadeDelete: true);
            AddForeignKey("dbo.tbl_datesheet", "tbl_typeId", "dbo.tbl_type", "id", cascadeDelete: true);
            DropColumn("dbo.tbl_datesheet", "type");
            DropColumn("dbo.tbl_datesheet", "shift");
            DropColumn("dbo.tbl_datesheet", "date");
            DropColumn("dbo.tbl_datesheet", "tbl_blockId");
            DropColumn("dbo.tbl_datesheet", "tbl_subjectId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tbl_datesheet", "tbl_subjectId", c => c.Int(nullable: false));
            AddColumn("dbo.tbl_datesheet", "tbl_blockId", c => c.Int(nullable: false));
            AddColumn("dbo.tbl_datesheet", "date", c => c.DateTime(nullable: false));
            AddColumn("dbo.tbl_datesheet", "shift", c => c.Int(nullable: false));
            AddColumn("dbo.tbl_datesheet", "type", c => c.String());
            DropForeignKey("dbo.tbl_subjectDatesheet", "tbl_datesheetId", "dbo.tbl_datesheet");
            DropForeignKey("dbo.tbl_datesheet", "tbl_typeId", "dbo.tbl_type");
            DropForeignKey("dbo.tbl_datesheet", "tbl_semesterId", "dbo.tbl_semester");
            DropForeignKey("dbo.tbl_datesheet", "tbl_courseId", "dbo.tbl_course");
            DropIndex("dbo.tbl_subjectDatesheet", new[] { "tbl_datesheetId" });
            DropIndex("dbo.tbl_datesheet", new[] { "tbl_semesterId" });
            DropIndex("dbo.tbl_datesheet", new[] { "tbl_courseId" });
            DropIndex("dbo.tbl_datesheet", new[] { "tbl_typeId" });
            DropColumn("dbo.tbl_datesheet", "tbl_semesterId");
            DropColumn("dbo.tbl_datesheet", "tbl_courseId");
            DropColumn("dbo.tbl_datesheet", "tbl_typeId");
            DropTable("dbo.tbl_subjectDatesheet");
            CreateIndex("dbo.tbl_datesheet", "tbl_subjectId");
            CreateIndex("dbo.tbl_datesheet", "tbl_blockId");
            AddForeignKey("dbo.tbl_datesheet", "tbl_subjectId", "dbo.tbl_subject", "id", cascadeDelete: true);
            AddForeignKey("dbo.tbl_datesheet", "tbl_blockId", "dbo.tbl_block", "id", cascadeDelete: true);
        }
    }
}
