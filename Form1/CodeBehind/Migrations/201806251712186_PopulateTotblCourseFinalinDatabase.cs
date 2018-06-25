namespace CodeBehind.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateTotblCourseFinalinDatabase : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into tbl_course(name, tbl_departmentId, total_number_of_Semester) values('CSE', 1, 8)");
            Sql("Insert into tbl_course(name, tbl_departmentId, total_number_of_Semester) values('ME', 2, 8)");
        }
        
        public override void Down()
        {
        }
    }
}
