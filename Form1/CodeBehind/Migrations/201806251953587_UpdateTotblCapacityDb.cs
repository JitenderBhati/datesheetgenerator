namespace CodeBehind.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTotblCapacityDb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbl_capacityCalc", "tbl_blockId", c => c.Int(nullable: false));
            CreateIndex("dbo.tbl_capacityCalc", "tbl_blockId");
            AddForeignKey("dbo.tbl_capacityCalc", "tbl_blockId", "dbo.tbl_block", "id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tbl_capacityCalc", "tbl_blockId", "dbo.tbl_block");
            DropIndex("dbo.tbl_capacityCalc", new[] { "tbl_blockId" });
            DropColumn("dbo.tbl_capacityCalc", "tbl_blockId");
        }
    }
}
