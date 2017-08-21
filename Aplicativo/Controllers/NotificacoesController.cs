using Modelo;
using Servico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aplicativo.Controllers
{
    public class NotificacoesController : Controller
    {
        NotificacaoServico notificacaoServico = new NotificacaoServico();

        public ActionResult Index()
        {
            return View(notificacaoServico.listNotificacoes());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Notificacao notificacao)
        {
            return salvarNotificacao(notificacao);
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(Notificacao notificacao)
        {
            return View();
        }
        
        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(Notificacao notificacao)
        {
            return View();
        }


        private ActionResult salvarNotificacao(Notificacao notificacao)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    notificacaoServico.salvarNotificacao(notificacao);
                    return RedirectToAction("Index");
                }
                return View(notificacao);
            }
            catch(Exception e)
            {
                return View(notificacao);
            }

        }
    }
}