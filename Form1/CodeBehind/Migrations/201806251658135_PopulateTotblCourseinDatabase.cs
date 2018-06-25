namespace CodeBehind.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateTotblCourseinDatabase : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into tbl_shift(shift) values('Shift 1')");
            Sql("Insert into tbl_shift(shift) values('Shift 2')");
        }
        
        public override void Down()
        {
        }
    }
}
