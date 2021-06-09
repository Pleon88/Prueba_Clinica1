using Prueba_Clinica.Controllers;
using Prueba_Clinica.Models;
using System.Web;
using System.Web.Mvc;

namespace Prueba_Clinica.Filtros
{
    public class VerificaciónSession : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var oUsuario = (Usuario)HttpContext.Current.Session["Usuario"];

            if (oUsuario == null)
            {
                if (filterContext.Controller is AccesoController == true)
                {
                    filterContext.HttpContext.Response.Redirect("~/Acceso/Ingresar");
                }
            }
            else
            {
                if (filterContext.Controller is AccesoController == false)
                {
                    filterContext.HttpContext.Response.Redirect("~/Home/Index");
                }

            }


            base.OnActionExecuting(filterContext);
        }

    }
}