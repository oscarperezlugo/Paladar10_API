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
    
    public partial class MA_CONFIGURACION_AUTO_DEPOSITO_CP
    {
        public decimal ID { get; set; }
        public string c_CodMoneda { get; set; }
        public string c_CodDenomina { get; set; }
        public string c_CodBanco_Origen { get; set; }
        public string c_CodBanco_Depositar { get; set; }
        public string c_NumeroCuenta_Depositar { get; set; }
        public System.DateTime FechaRegistro { get; set; }
        public string CodUsuario { get; set; }
        public string LogInfo { get; set; }
    }
}
