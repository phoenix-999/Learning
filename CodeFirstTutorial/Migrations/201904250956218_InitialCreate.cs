namespace CodeFirstTutorial.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sareas",
                c => new
                    {
                        SareaId = c.Int(nullable: false, identity: true),
                        SareaName = c.String(),
                        User_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.SareaId)
                .ForeignKey("dbo.Users", t => t.User_UserId)
                .Index(t => t.User_UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Age = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sareas", "User_UserId", "dbo.Users");
            DropIndex("dbo.Sareas", new[] { "User_UserId" });
            DropTable("dbo.Users");
            DropTable("dbo.Sareas");
        }
    }
}
