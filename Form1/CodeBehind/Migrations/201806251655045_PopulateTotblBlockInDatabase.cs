namespace CodeBehind.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateTotblBlockInDatabase : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into tbl_block(name) values('Block 1')");
            Sql("Insert into tbl_block(name) values('Block 2')");
            Sql("Insert into tbl_block(name) values('Block 3')");
            Sql("Insert into tbl_block(name) values('Block 4')");
            Sql("Insert into tbl_block(name) values('Block 5')");
            Sql("Insert into tbl_block(name) values('Block 6')");
            Sql("Insert into tbl_block(name) values('Block 7')");
            Sql("Insert into tbl_block(name) values('Block 8')");
            Sql("Insert into tbl_block(name) values('Block 9')");
        }
        
        public override void Down()
        {
        }
    }
}
