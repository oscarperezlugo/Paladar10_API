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
    
    public partial class MA_SINCRONIZACION
    {
        public System.DateTime F_FECHA_MA_VENTAS { get; set; }
        public decimal C_DOC_MA_VENTAS_VEN { get; set; }
        public decimal C_DOC_MA_VENTAS_POS_VEN { get; set; }
        public decimal C_DOC_MA_VENTAS_DEV { get; set; }
        public decimal C_DOC_MA_VENTAS_POS_DEV { get; set; }
        public System.DateTime F_FECHA_MA_INVENTARIO { get; set; }
        public decimal C_DOC_MA_INVENTARIO_TRA { get; set; }
        public decimal C_DOC_MA_INVENTARIO_TRA_ANU { get; set; }
        public decimal C_DOC_MA_INVENTARIO_TRS { get; set; }
        public decimal C_DOC_MA_INVENTARIO_TRS_ANU { get; set; }
        public decimal C_DOC_MA_INVENTARIO_AJU { get; set; }
        public decimal C_DOC_MA_INVENTARIO_AJU_ANU { get; set; }
        public decimal C_DOC_MA_INVENTARIO_INV { get; set; }
        public decimal C_DOC_MA_INVENTARIO_INV_ANU { get; set; }
        public decimal C_DOC_MA_INVENTARIO_REC { get; set; }
        public decimal C_DOC_MA_INVENTARIO_REC_ANU { get; set; }
        public decimal C_DOC_MA_INVENTARIO_PRD { get; set; }
        public decimal C_DOC_MA_INVENTARIO_PRD_ANU { get; set; }
        public System.DateTime F_FECHA_MA_COMPRAS { get; set; }
        public decimal C_DOC_MA_COMPRAS_COM { get; set; }
        public decimal C_DOC_MA_COMPRAS_DCM { get; set; }
        public System.DateTime F_FECHA_ODC { get; set; }
        public decimal C_DOC_MA_ODC_ODC { get; set; }
        public System.DateTime H_BUSCAR_DATA { get; set; }
        public bool B_REINTENTAR { get; set; }
        public string C_CODSUCURSAL { get; set; }
        public decimal id { get; set; }
    }
}
