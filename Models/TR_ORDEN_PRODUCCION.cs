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
    
    public partial class TR_ORDEN_PRODUCCION
    {
        public string c_Documento { get; set; }
        public decimal c_Linea { get; set; }
        public string c_CodigoInput { get; set; }
        public string c_CodArticulo { get; set; }
        public string c_Descripcion { get; set; }
        public string c_Presenta { get; set; }
        public double n_Cantidad { get; set; }
        public double n_Costo { get; set; }
        public double n_PorcMerma { get; set; }
        public double n_MontoMerma { get; set; }
        public double n_Subtotal { get; set; }
        public double n_Descuento { get; set; }
        public double n_Impuesto { get; set; }
        public double n_Total { get; set; }
        public bool b_Producir { get; set; }
        public double n_Cant_Utilizada { get; set; }
        public double n_Cant_Realizada { get; set; }
        public double Impuesto1 { get; set; }
        public double Impuesto2 { get; set; }
        public double Impuesto3 { get; set; }
        public string c_IDLote { get; set; }
        public double n_CostoOriginal { get; set; }
        public string c_CodLocalidad { get; set; }
        public string c_MonedaProd { get; set; }
        public double n_FactorMonedaProd { get; set; }
        public int n_Decimales { get; set; }
        public string n_Prod_Ext { get; set; }
        public double ns_CantidadEmpaque { get; set; }
        public double nu_FactorCosto { get; set; }
        public decimal ID { get; set; }
    }
}
