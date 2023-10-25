using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Capstone.Models.DbModels
{
    public partial class ModelDBContext : DbContext
    {
        public ModelDBContext()
            : base("name=ModelDBContext")
        {
        }

        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Commenti> Commenti { get; set; }
        public virtual DbSet<Evento> Evento { get; set; }
        public virtual DbSet<Prenotazione> Prenotazione { get; set; }
        public virtual DbSet<Recensioni> Recensioni { get; set; }
        public virtual DbSet<Utenti> Utenti { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>()
                .HasMany(e => e.Evento)
                .WithRequired(e => e.Categoria)
                .HasForeignKey(e => e.FkCategoria)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Evento>()
                .Property(e => e.Costo)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Evento>()
                .HasMany(e => e.Commenti)
                .WithRequired(e => e.Evento)
                .HasForeignKey(e => e.FKEventi)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Evento>()
                .HasMany(e => e.Prenotazione)
                .WithRequired(e => e.Evento)
                .HasForeignKey(e => e.FKEventi)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Evento>()
                .HasMany(e => e.Recensioni)
                .WithRequired(e => e.Evento)
                .HasForeignKey(e => e.FKEventi)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Utenti>()
                .HasMany(e => e.Commenti)
                .WithRequired(e => e.Utenti)
                .HasForeignKey(e => e.FKUser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Utenti>()
                .HasMany(e => e.Prenotazione)
                .WithRequired(e => e.Utenti)
                .HasForeignKey(e => e.FKUtente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Utenti>()
                .HasMany(e => e.Recensioni)
                .WithRequired(e => e.Utenti)
                .HasForeignKey(e => e.FKUtenti)
                .WillCascadeOnDelete(false);
        }
    }
}
