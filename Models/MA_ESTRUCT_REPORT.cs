//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Paladar10_API.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class MA_ESTRUCT_REPORT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MA_ESTRUCT_REPORT()
        {
            this.TR_ESTRUCT_REPORT = new HashSet<TR_ESTRUCT_REPORT>();
        }
    
        public string Relacion { get; set; }
        public string Clave { get; set; }
        public string texto { get; set; }
        public string imagen { get; set; }
        public string tag { get; set; }
        public string ruta { get; set; }
        public decimal id { get; set; }
        public int NiveldeOrden { get; set; }
        public int ModoImpresion { get; set; }
        public string puerto { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TR_ESTRUCT_REPORT> TR_ESTRUCT_REPORT { get; set; }
    }
}
