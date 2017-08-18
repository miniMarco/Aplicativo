using Modelo;
using Persistencia.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Net;

namespace Persistencia.DAL
{
    public class UsuarioDAL
    {
        private EFContext contexto = new EFContext();

        public IQueryable<Usuario> getUsuarioOrdenadoPorNome()
        {
            return contexto.Usuarios.Include(set => set.Setor).OrderBy(item => item.Nome);
        }

        public void gravarUsuario(Usuario usuario)
        {
            if (usuario.UsuarioId == null)
                contexto.Usuarios.Add(usuario);
            else
                contexto.Entry(usuario).State = EntityState.Modified;

            contexto.SaveChanges();
        }

        public Usuario getUsuarioPorId(int usuarioId)
        {
            return contexto.Usuarios.Find(usuarioId);
        }
    }
}
