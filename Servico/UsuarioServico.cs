using Modelo;
using Persistencia.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servico
{
     public class UsuarioServico
    {
        UsuarioDAL usuarioDAL = new UsuarioDAL(); 
        public IQueryable<Usuario> getUsuariosOrdenadosPorNome()
        {
            return usuarioDAL.getUsuarioOrdenadoPorNome();
        }

        public void gravarUsuario(Usuario usuario)
        {
            usuarioDAL.gravarUsuario(usuario);
        }
    }
}
