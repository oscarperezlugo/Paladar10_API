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
    
    public partial class MA_Bienes
    {
        public decimal IDDeActivo { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public System.DateTime Fecha { get; set; }
        public double Monto { get; set; }
        public Nullable<double> ValorSalvamento { get; set; }
        public Nullable<double> VidaUtil { get; set; }
        public Nullable<double> Depreciacion { get; set; }
        public string Departamento { get; set; }
    }
}
