using Servico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aplicativo.Controllers
{
    public class UsuariosController : Controller
    {
        private UsuarioServico usuarioServico = null;
        private UsuarioServico UsuarioServico
        {
            get
            {
                if (usuarioServico == null)
                    usuarioServico = new UsuarioServico();
                return usuarioServico;
            }
        }

        private SetorServico setorServico = null;
        private SetorServico SetorServico
        {
            get
            {
                if (setorServico == null)
                    setorServico = new SetorServico();
                return setorServico;
            }
        }

        public ActionResult Index()
        {
            return View(UsuarioServico.getUsuariosOrdenadosPorNome());
        }

        public ActionResult Create()
        {
            ViewBag.Setores = new SelectList(SetorServico.listSetoresOrdenados(), "SetorId", "Nome");
            return View();
        }
    }
}