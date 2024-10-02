namespace ArcGISApi.DTO
{
    public class MejoraDTO
    {
        public string CodigoMejora { get; set; }
        public int? Invasion { get; set; } 
        public string TipoMejora { get; set; }
        public string EstadoConservacion { get; set; }
        public double? AreaMejora { get; set; }
        public string Edad { get; set; }
        public int? EdadAnios { get; set; }
        public int? Cantidad { get; set; }
        public string Unidad { get; set; }
        public double? ValorAnuevo { get; set; }
        public double? ValorMejora { get; set; }
        public double? ValorUnitario { get; set; }
        public int? CalidadDato { get; set; } 
        public int? FuenteDato { get; set; } 
        public string Descripcion { get; set; }
        public Guid? FKIDTramoPredial { get; set; }
        public string CodigoNegocioMejora { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string UsuarioCreador { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public string UsuarioModifica { get; set; }
        public int OBJECTID { get; set; }
        public Guid IDMejora { get; set; }
        public string RelacionMejora { get; set; }
        public Guid? RelacionMigracion { get; set; }
        public DateTime? FechaSicronizacion { get; set; }
    }
}
