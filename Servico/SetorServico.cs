using Modelo;
using Persistencia.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servico
{
    public class SetorServico
    {
        SetorDAL setorDAL = new SetorDAL();
        public IQueryable<Setor> listSetoresOrdenados()
        {
            return setorDAL.listSetoresOrdenados();
        }
    }
}
