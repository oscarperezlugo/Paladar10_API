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
    
    public partial class TR_INVENTARIO
    {
        public int c_LINEA { get; set; }
        public string c_CONCEPTO { get; set; }
        public string c_DOCUMENTO { get; set; }
        public string c_DEPOSITO { get; set; }
        public string c_CODARTICULO { get; set; }
        public double n_CANTIDAD { get; set; }
        public double n_COSTO { get; set; }
        public double n_SUBTOTAL { get; set; }
        public double n_IMPUESTO { get; set; }
        public double n_TOTAL { get; set; }
        public string c_TIPOMOV { get; set; }
        public double n_cant_teorica { get; set; }
        public double n_cant_diferencia { get; set; }
        public double N_PRECIO { get; set; }
        public double N_PRECIO_ORIGINAL { get; set; }
        public System.DateTime f_fecha { get; set; }
        public string c_codlocalidad { get; set; }
        public double n_factorcambio { get; set; }
        public decimal id { get; set; }
        public string C_DESCRIPCION { get; set; }
        public string C_COMPUESTO { get; set; }
        public decimal codconcepto { get; set; }
        public double n_descuentogeneral { get; set; }
        public double n_descuentoespecifico { get; set; }
        public string c_documento_origen { get; set; }
        public string c_tipodoc_origen { get; set; }
        public double N_CANTIDADFAC { get; set; }
        public double ns_descuento { get; set; }
        public string cs_comprobanteContable { get; set; }
        public string cs_codlocalidad { get; set; }
        public double ns_CantidadEmpaque { get; set; }
        public double IMPUESTO { get; set; }
        public double n_FactorMonedaProd { get; set; }
        public Nullable<double> n_CostoRep { get; set; }
        public Nullable<double> n_CostoPro { get; set; }
    }
}
