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
    
    public partial class MA_PEDIDOS_RUTA_PICKING
    {
        public string CodLote { get; set; }
        public string CodPedido { get; set; }
        public string CodProducto { get; set; }
        public string CodRecolector { get; set; }
        public string CodSupervisorPicking { get; set; }
        public string CodEmpacador { get; set; }
        public string CodSupervisorPacking { get; set; }
        public double CantSolicitada { get; set; }
        public double CantRecolectada { get; set; }
        public double CantEmpacada { get; set; }
        public bool Picking { get; set; }
        public bool Packing { get; set; }
        public System.DateTime FechaAsignacion { get; set; }
        public decimal PackingMobile_CantEmpaques { get; set; }
    }
}
