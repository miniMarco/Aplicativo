using Modelo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Persistencia.Contexts
{
    public class EFContext : DbContext
    {
        public EFContext() : base("Aplicativo_BD")
        {

        }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}