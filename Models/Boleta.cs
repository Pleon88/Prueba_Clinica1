//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Prueba_Clinica.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Boleta
    {
        public int id_boleta { get; set; }
        public int id_presupuesto { get; set; }
        public string monto_boleta { get; set; }
        public System.DateTime fecha_boleta { get; set; }
    
        public virtual Presupuesto Presupuesto { get; set; }
    }
}
