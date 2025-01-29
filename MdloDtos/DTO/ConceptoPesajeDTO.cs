using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdloDtos.DTO
{
    /// <summary>
    /// DTO Concepto Pesaje , Control de pesaje
    /// Daniel Lopez
    /// </summary>
    public class ConceptoPesajeDTO
    {

        [StringLength(15)]
        [DataType(DataType.Text)]
        public string CodigoCompania { get; set; } = null!;

        [StringLength(15)]
        [DataType(DataType.Text)]
        public string CodigoConceptoPesaje { get; set; } = null!;

        [StringLength(40)]
        [DataType(DataType.Text)]
        public string NombreConceptoPesaje { get; set; } = null!;

        [StringLength(150)]
        [DataType(DataType.Text)]
        public string Descripcion { get; set; } = null!;

        [StringLength(15)]
        [DataType(DataType.Text)]
        public string CodigoTipoConcepto { get; set; } = null!;

        public int IdConsectivo { get; set; } = 0;

        [StringLength(2)]
        [DataType(DataType.Text)]
        public string NaturalezaConceptoPesaje { get; set; } = null!;

        public bool? ModalidadDescargue { get; set; }= false;

        public bool? PedirEscotilla { get; set; }=false;

        public bool? IdSociedad { get; set; } = false;

        public bool? IdentificacionConductor { get; set; } = false;

        public bool? PedirRemolque { get; set; } = false;

        public bool? OrdenInterna { get; set; } =false;

        public bool? ConfiguracionVehicular { get; set; } = false;

        public DateTime? FechaCreacion { get; set; }= DateTime.Today;

        public bool? ControlSobrePeso { get; set; } = false;

        [StringLength(30)]
        [DataType(DataType.Text)]
        public string? FormatoImpresion { get; set; } = null!;

        public bool? ConfirmarEntreada { get; set; } = false;

        public bool? ConfirmarSalida { get; set; } = false;

        public bool? ValidaManifiesto { get; set; } = false;

        public bool? ReportaInside { get; set; } = false;

        public bool? ControlCargue { get; set; } = false;

        public bool? Activo { get; set; } = false;

        public bool? UsoReserva { get; set; } = false;

        public bool? UsoBascula { get; set; } = false;

        public short? NumerosPesadasTra { get; set; } = 0;

        public short? NumeroCopiasTiquete { get; set; } = 0;

        public bool? Compartido { get; set; } = false;

        public bool? PedirBodega { get; set; } = false;

        public bool? PedirPatio { get; set; } = false;

        public bool? PermitirPesaje { get; set; } = false;

        public bool? DesactivarProgramacion { get; set; } = false;

        [StringLength(200)]
        [DataType(DataType.Text)]
        public string? ParametroGeneral { get; set; } = null!;

        //Consecutivo
        [StringLength(15)]
        [DataType(DataType.Text)]
        public string? NombreConsecutivo { get; set; } = null!;

        [StringLength(5)]
        [DataType(DataType.Text)]
        public string? CodigoConsecutivo { get; set; } = null!;

        public Int32 Contador { get; set; } = 0;

        //tipo de consecutivo
        [StringLength(30)]
        [DataType(DataType.Text)]
        public string? NombreTipoConsecutivo { get; set; } = null!;

        [StringLength(3)]
        [DataType(DataType.Text)]
        public string? NaturalezaTipoConsecutivo { get; set; } = null!;

        [StringLength(80)]
        [DataType(DataType.Text)]
        //empresa
        public string? NombreCompania { get; set; } = null!;


    }
}
