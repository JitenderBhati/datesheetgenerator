namespace CodeBehind.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateTbl_Subjecttableidatabase : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into tbl_subject(name, tbl_courseId, tbl_semesterId, tbl_typeId) values('C++', 1, 1, 1)");
            Sql("Insert into tbl_subject(name, tbl_courseId, tbl_semesterId, tbl_typeId) values('Java', 1, 1, 1)");
        }
        
        public override void Down()
        {
        }
    }
}
