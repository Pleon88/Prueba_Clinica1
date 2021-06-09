using Prueba_Clinica.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Prueba_Clinica.Controllers
{
    public class AccesoController : Controller
    {
        private BD_Clinica_Linda_sonrisaEntities db = new BD_Clinica_Linda_sonrisaEntities();

        // GET: Acceso
        public ActionResult Ingresar()
        {
            return View();
        }

        public ActionResult Enter(string Usuario, string Password)
        {
            try
            {
                using (BD_Clinica_Linda_sonrisaEntities db = new BD_Clinica_Linda_sonrisaEntities())
                {

                    var lst = from d in db.Usuario
                              where d.usuario1 == Usuario && d.password_usuario == Password
                              select d;
                    if (lst.Count() > 0)
                    {
                        Usuario oUsuario = lst.First();
                        Session["Usuario"] = oUsuario;
                        Session["Cusuario"] = oUsuario.Tipo_Usuario.nombre_usuario;
                        Session["Nusuario"] = oUsuario.nombre_usuario;
                        Session["Rusuario"] = oUsuario.run_usuario;
                        return Content("1");
                    }
                    else
                    {
                        return Content("Usuario Invalido");
                    }
                }
            }
            catch (Exception ex)
            {
                return Content("Ocurrio un Error " + ex.Message);
            }
        }

        public ActionResult InicioSesion()
        {
            return View();
        }

        public ActionResult logoff()
        {
            Session["Usuario"] = null;
            return RedirectToAction("Index", "Accesso");
        }

        public ActionResult ReservaHora()
        {
            return View();
        }

        public ActionResult SituacionEconomica()
        {
            return View();
        }

        public ActionResult VerBoleta()
        {
            return View();
        }
        public ActionResult Modificar(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCliente_usuario = new SelectList(db.Cliente, "Id_cliente", "nombre_cliente", usuario.idCliente_usuario);
            ViewBag.comuna_usuario = new SelectList(db.Comuna, "id_comuna", "nombre_comuna", usuario.comuna_usuario);
            ViewBag.idTipo_usuario = new SelectList(db.Tipo_Usuario, "idTipo_usuario", "nombre_usuario", usuario.idTipo_usuario);
            ViewBag.region_usuario = new SelectList(db.Region, "id_region", "nombre_region", usuario.Region);
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Modificar([Bind(Include = "run_usuario,nombre_usuario,apellidoP_usuario,apellidoM_usuario,fecha_nac_usuario,usuario1,password_usuario,confir_password_usuario,direccion_usuario,regio_usuario,comuna_usuario,email_usuario,fono_usuario,idTipo_usuario,idCliente_usuario,persona_cargo,status_usuario,fecha_creacion")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idCliente_usuario = new SelectList(db.Cliente, "Id_cliente", "nombre_cliente", usuario.idCliente_usuario);
            ViewBag.comuna_usuario = new SelectList(db.Comuna, "id_comuna", "nombre_comuna", usuario.comuna_usuario);
            ViewBag.idTipo_usuario = new SelectList(db.Tipo_Usuario, "idTipo_usuario", "nombre_usuario", usuario.idTipo_usuario);
            ViewBag.region_usuario = new SelectList(db.Region, "id_region", "nombre_region", usuario.Region);
            return View(usuario);
        }
        public ActionResult Informacion(string id )
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }
    }
}