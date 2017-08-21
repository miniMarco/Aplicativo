using Persistencia.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using System.Data.Entity;

namespace Persistencia.DAL
{
    
    public class NotificacaoDAL
    {
        private EFContext contexto = new EFContext();

        public IQueryable<Notificacao> listNotificacoes()
        {
            return contexto.Notificacoes.OrderByDescending(not => not.DataInicio);
        }

        public void salvarNotificacao(Notificacao notificacao)
        {
            if (notificacao.NotificacaoId == null)
                contexto.Notificacoes.Add(notificacao);
            else
                contexto.Entry(notificacao).State = EntityState.Modified;

            contexto.SaveChanges();
        }
    }
}
