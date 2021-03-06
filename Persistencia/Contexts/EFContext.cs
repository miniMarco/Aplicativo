﻿using Modelo;
using Persistencia.Migrations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Persistencia.Contexts
{
    public class EFContext : DbContext
    {
        public EFContext() : base("Aplicativo_BD")
        {
            Database.SetInitializer<EFContext>(new MigrateDatabaseToLatestVersion<EFContext, Configuration>());
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Setor> Setores { get; set; }
        public DbSet<Notificacao> Notificacoes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }

    
}