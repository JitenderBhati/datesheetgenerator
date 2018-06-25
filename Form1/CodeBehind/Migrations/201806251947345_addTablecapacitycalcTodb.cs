namespace CodeBehind.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTablecapacitycalcTodb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbl_capacityCalc",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        capacity = c.Int(nullable: false),
                        date = c.DateTime(nullable: false),
                        tbl_shiftId = c.Int(nullable: false),
                        year = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.tbl_shift", t => t.tbl_shiftId, cascadeDelete: false)
                .Index(t => t.tbl_shiftId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tbl_capacityCalc", "tbl_shiftId", "dbo.tbl_shift");
            DropIndex("dbo.tbl_capacityCalc", new[] { "tbl_shiftId" });
            DropTable("dbo.tbl_capacityCalc");
        }
    }
}
