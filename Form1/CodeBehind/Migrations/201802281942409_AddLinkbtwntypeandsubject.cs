namespace CodeBehind.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLinkbtwntypeandsubject : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbl_subject", "tbl_typeId", c => c.Int(nullable: false));
            CreateIndex("dbo.tbl_subject", "tbl_typeId");
            AddForeignKey("dbo.tbl_subject", "tbl_typeId", "dbo.tbl_type", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tbl_subject", "tbl_typeId", "dbo.tbl_type");
            DropIndex("dbo.tbl_subject", new[] { "tbl_typeId" });
            DropColumn("dbo.tbl_subject", "tbl_typeId");
        }
    }
}
