namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class panier : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Paniers",
                c => new
                    {
                        PanierId = c.Int(nullable: false, identity: true),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.PanierId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateIndex("dbo.Commands", "PanierId");
            AddForeignKey("dbo.Commands", "PanierId", "dbo.Paniers", "PanierId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Commands", "PanierId", "dbo.Paniers");
            DropForeignKey("dbo.Paniers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Paniers", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Commands", new[] { "PanierId" });
            DropTable("dbo.Paniers");
        }
    }
}
