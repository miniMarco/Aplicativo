using Modelo;
using Servico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        public ActionResult Create(Usuario usuario, HttpPostedFileBase foto_perfil = null)
        {
            return gravarUsuario(usuario, foto_perfil);
        }

        public ActionResult Edit(int id)
        {
            popularDropDown(UsuarioServico.getUsuarioPorId(id));
            return getViewUsuario(id);
        }

        [HttpPost]
        public ActionResult Edit(Usuario usuario, HttpPostedFileBase foto_perfil = null)
        {
            return gravarUsuario(usuario,foto_perfil);
        }

        private ActionResult gravarUsuario(Usuario usuario, HttpPostedFileBase foto_perfil)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (foto_perfil != null)
                    {
                        usuario.FotoMimeType = foto_perfil.ContentType;
                        usuario.Foto = setFoto(foto_perfil);
                    }

                    UsuarioServico.gravarUsuario(usuario);
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
            if (usuario == null || usuario.UsuarioId == null)
            {
                ViewBag.SetorId = new SelectList(SetorServico.listSetoresOrdenados(), "SetorId", "Nome");
            }
            else
            {
                ViewBag.SetorId = new SelectList(SetorServico.listSetoresOrdenados(), "SetorId", "Nome", usuario.SetorId);
            }
        }

        private byte[] setFoto(HttpPostedFileBase foto)
        {
            var bytesFoto = new byte[foto.ContentLength];
            foto.InputStream.Read(bytesFoto, 0, foto.ContentLength);
            return bytesFoto;
        }

        private ActionResult getViewUsuario(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Usuario usuario = UsuarioServico.getUsuarioPorId(id.Value);
            if (usuario == null)
                return HttpNotFound();

            return View(usuario);
        }

        public FileContentResult getFoto(int id)
        {
            Usuario usuario = UsuarioServico.getUsuarioPorId(id);
            if (usuario != null)
            {
                return File(usuario.Foto, usuario.FotoMimeType);
            }
            return null;
        }
    }
}