using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using Persistencia.DAL;

namespace Servico
{
    public class NotificacaoServico
    {
        NotificacaoDAL notificacaoDAL = new NotificacaoDAL();
        public IQueryable<Notificacao> listNotificacoes()
        {
            return notificacaoDAL.listNotificacoes();
        }

        public void salvarNotificacao(Notificacao notificacao)
        {
            notificacaoDAL.salvarNotificacao(notificacao);
        }
    }
}
