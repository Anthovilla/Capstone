namespace Capstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IntialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categoria",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Evento",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 255),
                        Data = c.DateTime(),
                        Location = c.String(maxLength: 150),
                        Description = c.String(),
                        Costo = c.Decimal(precision: 10, scale: 2),
                        MaxParticipanti = c.Int(),
                        Foto = c.String(maxLength: 50),
                        Disponibile = c.Boolean(nullable: false),
                        FkCategoria = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categoria", t => t.FkCategoria)
                .Index(t => t.FkCategoria);
            
            CreateTable(
                "dbo.Commenti",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        Data = c.DateTime(),
                        FKEventi = c.Int(nullable: false),
                        FKUser = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Utenti", t => t.FKUser)
                .ForeignKey("dbo.Evento", t => t.FKEventi)
                .Index(t => t.FKEventi)
                .Index(t => t.FKUser);
            
            CreateTable(
                "dbo.Utenti",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Nome = c.String(nullable: false, maxLength: 150),
                        CF = c.String(nullable: false, maxLength: 16),
                        Telefono = c.String(maxLength: 13),
                        Email = c.String(maxLength: 100),
                        Ruolo = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Prenotazione",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(),
                        Partecipanti = c.Int(),
                        Status = c.String(maxLength: 50),
                        FKEventi = c.Int(nullable: false),
                        FKUtente = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Utenti", t => t.FKUtente)
                .ForeignKey("dbo.Evento", t => t.FKEventi)
                .Index(t => t.FKEventi)
                .Index(t => t.FKUtente);
            
            CreateTable(
                "dbo.Recensioni",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rating = c.Int(),
                        Text = c.String(),
                        FKEventi = c.Int(nullable: false),
                        FKUtenti = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Utenti", t => t.FKUtenti)
                .ForeignKey("dbo.Evento", t => t.FKEventi)
                .Index(t => t.FKEventi)
                .Index(t => t.FKUtenti);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Evento", "FkCategoria", "dbo.Categoria");
            DropForeignKey("dbo.Recensioni", "FKEventi", "dbo.Evento");
            DropForeignKey("dbo.Prenotazione", "FKEventi", "dbo.Evento");
            DropForeignKey("dbo.Commenti", "FKEventi", "dbo.Evento");
            DropForeignKey("dbo.Recensioni", "FKUtenti", "dbo.Utenti");
            DropForeignKey("dbo.Prenotazione", "FKUtente", "dbo.Utenti");
            DropForeignKey("dbo.Commenti", "FKUser", "dbo.Utenti");
            DropIndex("dbo.Recensioni", new[] { "FKUtenti" });
            DropIndex("dbo.Recensioni", new[] { "FKEventi" });
            DropIndex("dbo.Prenotazione", new[] { "FKUtente" });
            DropIndex("dbo.Prenotazione", new[] { "FKEventi" });
            DropIndex("dbo.Commenti", new[] { "FKUser" });
            DropIndex("dbo.Commenti", new[] { "FKEventi" });
            DropIndex("dbo.Evento", new[] { "FkCategoria" });
            DropTable("dbo.Recensioni");
            DropTable("dbo.Prenotazione");
            DropTable("dbo.Utenti");
            DropTable("dbo.Commenti");
            DropTable("dbo.Evento");
            DropTable("dbo.Categoria");
        }
    }
}
