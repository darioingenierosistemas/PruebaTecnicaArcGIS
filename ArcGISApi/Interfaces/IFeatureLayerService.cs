using ArcGISApi.DTO;

namespace ArcGISApi.Interfaces
{
    public interface IFeatureLayerService
    {
        Task<bool> EditarMejora(string id, MejoraDTO mejoraDto);
        Task<bool> EliminarMejora(string id);
        Task<bool> EditarConstruccion(string id, ConstruccionDTO construccionDto);
        Task<bool> EliminarConstruccion(string id);
    }
}
