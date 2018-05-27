namespace CodeBehind.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddHolidayClassToDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbl_holiday",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tbl_holiday");
        }
    }
}
