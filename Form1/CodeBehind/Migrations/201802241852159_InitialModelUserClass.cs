namespace CodeBehind.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModelUserClass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbl_users",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        uname = c.String(),
                        password = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tbl_users");
        }
    }
}
