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
    
    public partial class Agenda
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Agenda()
        {
            this.Reserva = new HashSet<Reserva>();
        }
    
        public int id_agenda { get; set; }
        public string id_usuario_agenda { get; set; }
        public System.DateTime fecha_agenda { get; set; }
        public string status_agenda { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reserva> Reserva { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
