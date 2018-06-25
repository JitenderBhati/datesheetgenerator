namespace CodeBehind.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class Populatetblstudentcapacity : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into tbl_studentCapacity(capacity, tbl_semesterId, tbl_courseId) values(1000, 1, 1)");
            Sql("Insert into tbl_studentCapacity(capacity, tbl_semesterId, tbl_courseId) values(1500, 2, 1)"); 
            Sql("Insert into tbl_studentCapacity(capacity, tbl_semesterId, tbl_courseId) values(1200, 5, 1)"); 
        }
        
        public override void Down()
        {
        }
    }
}
