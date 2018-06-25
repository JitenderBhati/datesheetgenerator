namespace CodeBehind.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populatetblblockwithcapacityinttable : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE tbl_block SET capacity=2000 where name='Block 1'");
            Sql("UPDATE tbl_block SET capacity=2000 where name='Block 2'");
            Sql("UPDATE tbl_block SET capacity=2000 where name='Block 3'");
            Sql("UPDATE tbl_block SET capacity=2000 where name='Block 4'");
            Sql("UPDATE tbl_block SET capacity=2000 where name='Block 5'");
            Sql("UPDATE tbl_block SET capacity=2000 where name='Block 6'");
            Sql("UPDATE tbl_block SET capacity=2000 where name='Block 7'");
            Sql("UPDATE tbl_block SET capacity=2000 where name='Block 8'");
            Sql("UPDATE tbl_block SET capacity=2000 where name='Block 9'");
        }
        
        public override void Down()
        {
        }
    }
}
