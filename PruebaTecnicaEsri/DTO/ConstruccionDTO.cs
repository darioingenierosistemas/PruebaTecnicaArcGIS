using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaEsri.DTO
{
    public class ConstruccionDTO
    {
        public int? TipoUnidadEspacial { get; set; } // Default: 1
        public double? AreaCalculada { get; set; }
        public double? ValorUnitario { get; set; }
        public double? ValorNuevo { get; set; }
        public string CodConstruccion { get; set; }
        public string EstadoConstruccion { get; set; }
        public string UCTipoConstruccion { get; set; }
        public int? UCNumeroPisos { get; set; }
        public int? UCAnioConstruccion { get; set; }
        public int? UCNumSalas { get; set; }
        public int? UCNumLocales { get; set; }
        public int? UCNumHabitaciones { get; set; }
        public int? UCNumBanios { get; set; }
        public int? UCNumCocinas { get; set; }
        public int? UCNumOficinas { get; set; }
        public int? UCNumEstudios { get; set; } // Default: 0
        public int? UCNumBodegas { get; set; } // Default: 0
        public string UCRelacionSuperficie { get; set; }
        public string UCPiso { get; set; }
        public string UCEstadoConservacion { get; set; }
        public string UCMaterialCubierta { get; set; }
        public string UCMaterialParedes { get; set; }
        public string UCMaterialPiso { get; set; }
        public string ObservacionesModificacion { get; set; }
        public string Observacion { get; set; }
        public string CodigoNegocioUnidadEspacial { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string UsuarioCreador { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public string UsuarioModifica { get; set; }
        public int OBJECTID { get; set; }
        public Guid IDUnidadEspacial { get; set; }
        public string RelacionUnidadEspacial { get; set; }
        public Guid? RelacionMigracion { get; set; }
        public double? ShapeArea { get; set; }
        public double? ShapeLength { get; set; }
        public Guid? FKIDTerreno { get; set; }
        public DateTime? FechaSicronizacion { get; set; }
    }
}
