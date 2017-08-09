using Modelo;
using Persistencia.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.DAL
{
    public class UsuarioDAL
    {
        private EFContext contexto = new EFContext();

        public IQueryable<Usuario> getUsuarioOrdenadoPorNome()
        {
            return contexto.Usuarios.OrderBy(item => item.Nome);
        }
    }
}
