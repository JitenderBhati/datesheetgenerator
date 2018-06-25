namespace CodeBehind.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateTotblDepartmentinDatabase : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into tbl_department(name) values('Department Of Engineering')");
            Sql("Insert into tbl_department(name) values('Department of Hospital Management')");
        }
        
        public override void Down()
        {
        }
    }
}
