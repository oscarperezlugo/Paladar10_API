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
    
    public partial class MA_BANCOS
    {
        public string c_CODIGO { get; set; }
        public string c_DESCRIPCIO { get; set; }
        public string c_GRUPO { get; set; }
        public string c_OBSERVACIO { get; set; }
        public double N_IDB { get; set; }
        public bool bs_verificacionoperaciones_especiales { get; set; }
        public string cs_mensaje { get; set; }
        public string ns_codigooperacion { get; set; }
        public string cs_rtfcheque { get; set; }
        public string cs_codigobanco_che { get; set; }
        public decimal id { get; set; }
        public string cu_FormatoArchivo { get; set; }
        public string cu_FormatoArchivoMismoBanco { get; set; }
        public string cu_FormatoArchivoOtrosBancos { get; set; }
        public string cu_tipoArchivoConciliacion { get; set; }
        public string cu_separadorArchivoConciliacion { get; set; }
        public string cu_campoTipo { get; set; }
        public string cu_campoDocumento { get; set; }
        public string cu_campoDetalle { get; set; }
        public string cu_campoMonto { get; set; }
        public string cu_campoFecha { get; set; }
        public bool bActivo { get; set; }
        public bool bUsoEnPOS { get; set; }
    }
}
