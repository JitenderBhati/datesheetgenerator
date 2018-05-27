namespace CodeBehind.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addhiftClassToDb : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tbl_subjectDatesheet", "tbl_subjectId", "dbo.tbl_subject");
            DropIndex("dbo.tbl_subjectDatesheet", new[] { "tbl_subjectId" });
            CreateTable(
                "dbo.tbl_shift",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        shift = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            DropTable("dbo.tbl_subjectDatesheet");
        }
        
        public override void Down()
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
                .PrimaryKey(t => t.id);
            
            DropTable("dbo.tbl_shift");
            CreateIndex("dbo.tbl_subjectDatesheet", "tbl_subjectId");
            AddForeignKey("dbo.tbl_subjectDatesheet", "tbl_subjectId", "dbo.tbl_subject", "id", cascadeDelete: true);
        }
    }
}
