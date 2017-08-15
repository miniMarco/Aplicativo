using Modelo;
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
            popularDropDown();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Usuario usuario, HttpPostedFileBase foto = null, string removerImagem = null)
        {
            return gravarUsuario(usuario, foto, removerImagem);
        }

        private ActionResult gravarUsuario(Usuario usuario, HttpPostedFileBase foto, string removerImagem)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (!string.IsNullOrEmpty(removerImagem))
                    {
                        usuario.Foto = null;
                    }
                    if (foto != null)
                    {
                        usuario.FotoMimeType = foto.ContentType;
                        usuario.Foto = setFoto(foto);
                    }

                    usuarioServico.gravarUsuario(usuario);
                    return RedirectToAction("Index");
                }
                popularDropDown(usuario);
                return View(usuario);
            }
            catch
            {
                popularDropDown(usuario);
                return View(usuario);
            }
        }

        private void popularDropDown(Usuario usuario = null)
        {
            if (usuario == null)
            {
                ViewBag.Setores = new SelectList(SetorServico.listSetoresOrdenados(), "SetorId", "Nome");
            }
            else
            {
                ViewBag.Setores = new SelectList(SetorServico.listSetoresOrdenados(), "SetorId", "Nome", usuario.Setor.SetorId);
            }
        }

        private byte[] setFoto(HttpPostedFileBase foto)
        {
            var bytesFoto = new byte[foto.ContentLength];
            foto.InputStream.Read(bytesFoto, 0, foto.ContentLength);
            return bytesFoto;
        }
    }
}