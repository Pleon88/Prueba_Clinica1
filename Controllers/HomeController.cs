using Prueba_Clinica.Models;
using System.Web.Mvc;

namespace Prueba_Clinica.Controllers
{
    public class HomeController : Controller
    {
        private BD_Clinica_Linda_sonrisaEntities db = new BD_Clinica_Linda_sonrisaEntities();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Mision()
        {
            return View();
        }

        public ActionResult Registrar()
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

        public ActionResult Registrar([Bind(Include = "run_usuario,nombre_usuario,apellidoP_usuario,apellidoM_usuario,fecha_nac_usuario,usuario1,password_usuario,confir_password_usuario,direccion_usuario,region_usuario,comuna_usuario,email_usuario,fono_usuario,idTipo_usuario,idCliente_usuario,persona_cargo,status_usuario,fecha_creacion")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Usuario.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            ViewBag.idCliente_usuario = new SelectList(db.Cliente, "Id_cliente", "nombre_cliente", usuario.idCliente_usuario);
            ViewBag.comuna_usuario = new SelectList(db.Comuna, "id_comuna", "nombre_comuna", usuario.comuna_usuario);
            ViewBag.idTipo_usuario = new SelectList(db.Tipo_Usuario, "idTipo_usuario", "nombre_usuario", usuario.idTipo_usuario);
            ViewBag.region_usuario = new SelectList(db.Region, "id_region", "nombre_region", usuario.Region);
            return View(usuario);
        }
    }
}