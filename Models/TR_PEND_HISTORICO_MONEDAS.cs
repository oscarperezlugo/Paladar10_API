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
    
    public partial class TR_PEND_HISTORICO_MONEDAS
    {
        public decimal ID { get; set; }
        public System.DateTime d_FechaCambioAnterior { get; set; }
        public System.DateTime d_FechaCambioActual { get; set; }
        public string c_CodMoneda { get; set; }
        public string c_Descripcion { get; set; }
        public double n_FactorAnterior { get; set; }
        public double n_FactorPeriodo { get; set; }
        public bool b_Preferencia { get; set; }
        public string c_Observacio { get; set; }
        public bool b_Activa { get; set; }
        public string c_Simbolo { get; set; }
        public int n_Decimales { get; set; }
        public System.DateTime FechaInsert { get; set; }
        public string Host_Name { get; set; }
        public string TxtPlus1 { get; set; }
        public string TxtPlus2 { get; set; }
        public string c_CodUsuario { get; set; }
        public int TipoCambio { get; set; }
    }
}
