using Modelo;
using Persistencia.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.DAL
{
    public class SetorDAL
    {
        private EFContext contexto = new EFContext();
        public IQueryable<Setor> listSetoresOrdenados()
        {
            return contexto.Setores.OrderBy(item => item.Nome);
        }
    }
}
