namespace CodeBehind.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateSemesterAndCourseTableWithData : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into tbl_semester(name) values('Sem 1')");
            Sql("Insert into tbl_semester(name) values('Sem 2')");
            Sql("Insert into tbl_semester(name) values('Sem 3')");
            Sql("Insert into tbl_semester(name) values('Sem 4')");
            Sql("Insert into tbl_semester(name) values('Sem 5')");
            Sql("Insert into tbl_semester(name) values('Sem 6')");
            
        }
        
        public override void Down()
        {
        }
    }
}
