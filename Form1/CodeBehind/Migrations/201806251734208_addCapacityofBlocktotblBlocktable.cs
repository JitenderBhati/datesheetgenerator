namespace CodeBehind.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCapacityofBlocktotblBlocktable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbl_block", "capacity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tbl_block", "capacity");
        }
    }
}
