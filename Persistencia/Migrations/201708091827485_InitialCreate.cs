namespace Persistencia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Setors",
                c => new
                    {
                        SetorId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.SetorId);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        UsuarioId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Sobrenome = c.String(),
                        Email = c.String(),
                        Senha = c.String(),
                        Foto = c.Binary(),
                        Aniversario = c.DateTime(nullable: false),
                        Setor_SetorId = c.Int(),
                    })
                .PrimaryKey(t => t.UsuarioId)
                .ForeignKey("dbo.Setors", t => t.Setor_SetorId)
                .Index(t => t.Setor_SetorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Usuarios", "Setor_SetorId", "dbo.Setors");
            DropIndex("dbo.Usuarios", new[] { "Setor_SetorId" });
            DropTable("dbo.Usuarios");
            DropTable("dbo.Setors");
        }
    }
}
