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
        UsuarioServico usuarioServico = new UsuarioServico();

        public ActionResult Index()
        {
            return View(usuarioServico.getUsuariosOrdenadosPorNome());
        }

        public ActionResult Create()
        {
            return View();
        }
    }
}