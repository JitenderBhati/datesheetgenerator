namespace CodeBehind.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeRelationbtwnsemesterandsemesterclass : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tbl_semester", "semester_id", "dbo.tbl_semester");
            DropIndex("dbo.tbl_semester", new[] { "semester_id" });
            DropColumn("dbo.tbl_semester", "semester_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tbl_semester", "semester_id", c => c.Int());
            CreateIndex("dbo.tbl_semester", "semester_id");
            AddForeignKey("dbo.tbl_semester", "semester_id", "dbo.tbl_semester", "id");
        }
    }
}
