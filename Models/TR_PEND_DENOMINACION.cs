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
    
    public partial class TR_PEND_DENOMINACION
    {
        public string C_CODMONEDA { get; set; }
        public string C_CODDENOMINA { get; set; }
        public string C_DENOMINACION { get; set; }
        public double N_VALOR { get; set; }
        public bool C_REAL { get; set; }
        public bool C_POS { get; set; }
        public double N_MONTO_COMPRA { get; set; }
        public double N_MONTO_VUELTO { get; set; }
        public bool B_PERMITE_VUELTO { get; set; }
        public int TIPO_CAMBIO { get; set; }
        public decimal ID { get; set; }
        public int nu_requiere_endoso { get; set; }
        public int nu_imprime_forma { get; set; }
        public int nu_requiere_conformacion { get; set; }
        public int nu_requiere_serial { get; set; }
        public bool bs_verificacionoperaciones_especiales { get; set; }
        public bool bs_credito { get; set; }
        public int nu_verificacionElectronica { get; set; }
        public bool bAutoDeclaracion { get; set; }
    }
}
