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
    
    public partial class Proveedor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Proveedor()
        {
            this.Orden_Pedidos = new HashSet<Orden_Pedidos>();
        }
    
        public string rut_proveedor { get; set; }
        public string razon_social_prov { get; set; }
        public string direccion_proveedor { get; set; }
        public int id_region { get; set; }
        public int id_comuna { get; set; }
        public string fono_proveedor { get; set; }
        public string email_proveedor { get; set; }
    
        public virtual Comuna Comuna { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Orden_Pedidos> Orden_Pedidos { get; set; }
    }
}
