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
    
    public partial class MA_AUDITORIAS
    {
        public int ID { get; set; }
        public int Cod_Prod { get; set; }
        public string Nom_Prod { get; set; }
        public int Tipo { get; set; }
        public string Descripcion { get; set; }
        public string Evento { get; set; }
        public System.DateTime Fecha { get; set; }
        public string CodUsuario { get; set; }
        public string Usuario { get; set; }
        public string Ventana { get; set; }
        public string TipoObjAuditado { get; set; }
        public string CodigoAuditado { get; set; }
        public string CodigoRetorno { get; set; }
        public string AccionRealizada { get; set; }
    }
}
