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
    
    public partial class CONF_MENU_USER
    {
        public string clave_user { get; set; }
        public string clave_menu { get; set; }
        public string texto { get; set; }
        public Nullable<short> activado { get; set; }
        public string icono { get; set; }
        public string forma { get; set; }
        public string RELACION { get; set; }
        public int id { get; set; }
        public string ResourceId { get; set; }
        public bool OpcionDisponible { get; set; }
    }
}
