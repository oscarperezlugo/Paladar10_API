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
    
    public partial class MA_CXP
    {
        public string C_Documento { get; set; }
        public string C_Relacion { get; set; }
        public string C_Codigo { get; set; }
        public string C_localidad { get; set; }
        public string C_usuario { get; set; }
        public string c_concepto { get; set; }
        public string c_detalle { get; set; }
        public string c_observacion { get; set; }
        public System.DateTime f_fechae { get; set; }
        public System.DateTime f_fechav { get; set; }
        public double n_impuesto { get; set; }
        public double n_bimpuesto { get; set; }
        public double n_total { get; set; }
        public double n_PagadoImp { get; set; }
        public double n_Pagado { get; set; }
        public double n_retencion { get; set; }
        public double n_subtotal { get; set; }
        public double N_pimpuesto { get; set; }
        public string c_codmoneda { get; set; }
        public double n_factor { get; set; }
        public System.DateTime F_CANCELACION { get; set; }
        public decimal codconcepto { get; set; }
        public double N_PAGADORETENCION { get; set; }
        public string cs_comprobanteContable { get; set; }
        public double n_totalcxp { get; set; }
        public string cs_codlocalidad { get; set; }
        public string cs_documento_ret { get; set; }
        public string cs_comprobante_ret { get; set; }
        public System.DateTime ds_fecha_ret { get; set; }
        public decimal id { get; set; }
        public string cs_descripcion_prov { get; set; }
        public string cs_direccion_prov { get; set; }
        public string cs_rif_prov { get; set; }
        public string cs_telefono_prov { get; set; }
        public string CS_CODUNIDAD { get; set; }
        public string cu_documentoRecepcion { get; set; }
        public string cs_documento_ndc { get; set; }
        public string cs_ncontrol_ndc { get; set; }
        public System.DateTime ds_fechaemision_nota { get; set; }
        public string cs_RelacionAnticipo { get; set; }
        public string CS_RELACION_NDC { get; set; }
        public string CS_NUMTRANSF_DESTINO { get; set; }
        public string CS_NUMERO_TRANSFERENCIA { get; set; }
    }
}
