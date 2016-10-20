namespace ManagerUtn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "Book_Id", "dbo.Books");
            DropIndex("dbo.Comments", new[] { "Book_Id" });
            DropTable("dbo.Books");
            DropTable("dbo.Comments");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Comentario = c.String(),
                        Book_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Titulo = c.String(),
                        Image = c.String(),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Comments", "Book_Id");
            AddForeignKey("dbo.Comments", "Book_Id", "dbo.Books", "Id");
        }
    }
}
