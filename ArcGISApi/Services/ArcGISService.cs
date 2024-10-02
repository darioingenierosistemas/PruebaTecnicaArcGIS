using ArcGISApi.DTO;
using ArcGISApi.Interfaces;
using Newtonsoft.Json;

namespace ArcGISApi.Services
{
    public class ArcGISService : IArcGISService
    {
        private readonly HttpClient _httpClient;
        private readonly string _mejoraFeatureLayerUrl = "https://calidadevolutionscsas.com/server/rest/services/sigebPredial/GPR_CartoGestion/FeatureServer/1"; 
        private readonly string _construccionFeatureLayerUrl = "https://calidadevolutionscsas.com/server/rest/services/sigebPredial/GPR_CartoGestion/FeatureServer/5"; 

        public ArcGISService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Método para actualizar una mejora
        public async Task<bool> UpdateMejora(string id, MejoraDTO mejoraDto)
        {
            var url = $"{_mejoraFeatureLayerUrl}/updateFeatures";

            // Crear el cuerpo del request con los atributos y la geometría
            var requestBody = new
            {
                features = new[]
                {
            new
            {
                attributes = new
                {
                    OBJECTID = Convert.ToInt32(id), // El ID de la mejora
                    mejoraDto.CodigoMejora,
                    mejoraDto.Invasion,
                    mejoraDto.TipoMejora,
                    mejoraDto.EstadoConservacion,
                    mejoraDto.AreaMejora,
                    mejoraDto.Edad,
                    mejoraDto.EdadAnios,
                    mejoraDto.Cantidad,
                    mejoraDto.Unidad,
                    mejoraDto.ValorAnuevo,
                    mejoraDto.ValorMejora,
                    mejoraDto.ValorUnitario,
                    mejoraDto.CalidadDato,
                    mejoraDto.FuenteDato,
                    mejoraDto.Descripcion,
                    mejoraDto.FKIDTramoPredial,
                    mejoraDto.CodigoNegocioMejora,
                    mejoraDto.FechaCreacion,
                    mejoraDto.UsuarioCreador,
                    mejoraDto.FechaModificacion,
                    mejoraDto.UsuarioModifica,
                    mejoraDto.IDMejora,
                    mejoraDto.RelacionMejora,
                    mejoraDto.RelacionMigracion,
                    mejoraDto.FechaSicronizacion
                },
            }
        },
                f = "json",
                rollbackOnFailure = true
            };

            var response = await _httpClient.PostAsJsonAsync(url, requestBody);
            var content = await response.Content.ReadAsStringAsync();

            // Verificar si la respuesta fue exitosa
            return response.IsSuccessStatusCode && content.Contains("\"success\": true");
        }


        // Método para eliminar una mejora
        public async Task<bool> DeleteMejora(string id)
        {
            var url = $"{_mejoraFeatureLayerUrl}/deleteFeatures";

            // Crear el cuerpo de la petición para eliminar la mejora
            var requestBody = new
            {
                objectIds = id, // El ID de la mejora a eliminar
                f = "json"
            };

            var response = await _httpClient.PostAsJsonAsync(url, requestBody);
            var content = await response.Content.ReadAsStringAsync();

            // Verificar si la respuesta fue exitosa
            return response.IsSuccessStatusCode && content.Contains("\"success\": true");
        }

        // Método para actualizar una construcción
        public async Task<bool> UpdateConstruccion(string id, ConstruccionDTO construccionDto)
        {
            var url = $"{_construccionFeatureLayerUrl}/updateFeatures";

            // Crear el cuerpo de la petición para actualizar la entidad de construcción
            var requestBody = new
            {
                features = new[]
                {
                    new
                    {
                        attributes = new
                        {
                            OBJECTID = Convert.ToInt32(id),
                            TipoUnidadEspacial = construccionDto.TipoUnidadEspacial ?? 1, 
                            AreaCalculada = construccionDto.AreaCalculada,
                            ValorUnitario = construccionDto.ValorUnitario,
                            ValorNuevo = construccionDto.ValorNuevo,
                            CodConstruccion = construccionDto.CodConstruccion,
                            EstadoConstruccion = construccionDto.EstadoConstruccion,
                            UCTipoConstruccion = construccionDto.UCTipoConstruccion,
                            UCNumeroPisos = construccionDto.UCNumeroPisos,
                            UCAnioConstruccion = construccionDto.UCAnioConstruccion,
                            UCNumSalas = construccionDto.UCNumSalas,
                            UCNumLocales = construccionDto.UCNumLocales,
                            UCNumHabitaciones = construccionDto.UCNumHabitaciones,
                            UCNumBanios = construccionDto.UCNumBanios,
                            UCNumCocinas = construccionDto.UCNumCocinas,
                            UCNumOficinas = construccionDto.UCNumOficinas,
                            UCNumEstudios = construccionDto.UCNumEstudios ?? 0,
                            UCNumBodegas = construccionDto.UCNumBodegas ?? 0, 
                            UCRelacionSuperficie = construccionDto.UCRelacionSuperficie,
                            UCPiso = construccionDto.UCPiso,
                            UCEstadoConservacion = construccionDto.UCEstadoConservacion,
                            UCMaterialCubierta = construccionDto.UCMaterialCubierta,
                            UCMaterialParedes = construccionDto.UCMaterialParedes,
                            UCMaterialPiso = construccionDto.UCMaterialPiso,
                            ObservacionesModificacion = construccionDto.ObservacionesModificacion,
                            Observacion = construccionDto.Observacion,
                            CodigoNegocioUnidadEspacial = construccionDto.CodigoNegocioUnidadEspacial,
                            FechaCreacion = construccionDto.FechaCreacion,
                            UsuarioCreador = construccionDto.UsuarioCreador,
                            FechaModificacion = construccionDto.FechaModificacion,
                            UsuarioModifica = construccionDto.UsuarioModifica,
                            IDUnidadEspacial = construccionDto.IDUnidadEspacial,
                            RelacionUnidadEspacial = construccionDto.RelacionUnidadEspacial,
                            RelacionMigracion = construccionDto.RelacionMigracion,
                            ShapeArea = construccionDto.ShapeArea,
                            ShapeLength = construccionDto.ShapeLength,
                            FKIDTerreno = construccionDto.FKIDTerreno,
                            FechaSicronizacion = construccionDto.FechaSicronizacion
                        }
                    }
                },
                f = "json",
                rollbackOnFailure = true
            };

            var response = await _httpClient.PostAsJsonAsync(url, requestBody);
            var content = await response.Content.ReadAsStringAsync();

            return response.IsSuccessStatusCode && content.Contains("\"success\": true");
        }


        // Método para eliminar una construcción
        public async Task<bool> DeleteConstruccion(string id)
        {
            var url = $"{_construccionFeatureLayerUrl}/deleteFeatures";

            // Crear el cuerpo de la petición para eliminar la construcción
            var requestBody = new
            {
                objectIds = id, // El ID de la construcción a eliminar
                f = "json"
            };

            var response = await _httpClient.PostAsJsonAsync(url, requestBody);
            var content = await response.Content.ReadAsStringAsync();

            // Verificar si la respuesta fue exitosa
            return response.IsSuccessStatusCode && content.Contains("\"success\": true");
        }

    }

}
