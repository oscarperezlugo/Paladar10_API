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
    
    public partial class TMP_Comprobante
    {
        public Nullable<decimal> IDDeCuenta { get; set; }
        public string Codigo { get; set; }
        public Nullable<short> Tipo { get; set; }
        public Nullable<double> Monto { get; set; }
        public string Referencia { get; set; }
        public string Descripcion { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
        public string Usuario { get; set; }
        public Nullable<decimal> Linea { get; set; }
        public decimal id { get; set; }
        public Nullable<decimal> IDDeCentroCosto { get; set; }
    }
}
