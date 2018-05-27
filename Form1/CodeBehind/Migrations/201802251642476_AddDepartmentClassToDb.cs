namespace CodeBehind.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDepartmentClassToDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbl_department",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tbl_department");
        }
    }
}
