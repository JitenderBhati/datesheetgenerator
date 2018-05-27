namespace CodeBehind.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateTypeTableWithData : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into tbl_type(name) values ('Regular')");
            Sql("Insert into tbl_type(name) values ('Reappear')");
        }
        
        public override void Down()
        {
        }
    }
}
