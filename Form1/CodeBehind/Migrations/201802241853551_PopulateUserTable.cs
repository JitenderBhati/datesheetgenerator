namespace CodeBehind.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateUserTable : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into tbl_users(uname, password) values('Test', 'mydesire')");
        }
        
        public override void Down()
        {
        }
    }
}
