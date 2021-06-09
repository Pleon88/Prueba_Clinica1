using Prueba_Clinica.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Prueba_Clinica.Controllers
{
    public class UsuariosController : Controller
    {
        private BD_Clinica_Linda_sonrisaEntities db = new BD_Clinica_Linda_sonrisaEntities();

        // GET: Usuarios
        public ActionResult Index()
        {
            var usuario = db.Usuario.Include(u => u.Cliente).Include(u => u.Comuna).Include(u => u.Tipo_Usuario);
            return View(usuario.ToList());
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(string id)
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

        // GET: Usuarios/Create
        public ActionResult Crear()
        {
            ViewBag.idCliente_usuario = new SelectList(db.Cliente, "Id_cliente", "nombre_cliente");
            ViewBag.comuna_usuario = new SelectList(db.Comuna, "id_comuna", "nombre_comuna");
            ViewBag.idTipo_usuario = new SelectList(db.Tipo_Usuario, "idTipo_usuario", "nombre_usuario", selectedValue: 5);
            ViewBag.region_usuario = new SelectList(db.Region, "id_region", "nombre_region");
            return View();
        }


        // POST: Usuarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        //GET: Región

        public ActionResult Crear([Bind(Include = "run_usuario,nombre_usuario,apellidoP_usuario,apellidoM_usuario,fecha_nac_usuario,usuario1,password_usuario,confir_password_usuario,direccion_usuario,region_usuario,comuna_usuario,email_usuario,fono_usuario,idTipo_usuario,idCliente_usuario,persona_cargo,status_usuario,fecha_creacion")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Usuario.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("Index", "Usuarios");
            }

            ViewBag.idCliente_usuario = new SelectList(db.Cliente, "Id_cliente", "nombre_cliente", usuario.idCliente_usuario);
            ViewBag.comuna_usuario = new SelectList(db.Comuna, "id_comuna", "nombre_comuna", usuario.comuna_usuario);
            ViewBag.idTipo_usuario = new SelectList(db.Tipo_Usuario, "idTipo_usuario", "nombre_usuario", usuario.idTipo_usuario);
            ViewBag.region_usuario = new SelectList(db.Region, "id_region", "nombre_region", usuario.Region);
            return View(usuario);
        }

        // GET: Usuarios/Edit/5
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

        // GET: Usuarios/Delete/5
        public ActionResult Delete(string id)
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

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Usuario usuario = db.Usuario.Find(id);
            db.Usuario.Remove(usuario);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
