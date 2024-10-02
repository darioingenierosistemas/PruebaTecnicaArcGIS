using ArcGISApi.DTO;

namespace ArcGISApi.Interfaces
{
    public interface IArcGISService
    {
        // Actualiza una mejora específica
        Task<bool> UpdateMejora(string id, MejoraDTO mejoraDto);

        // Elimina una mejora específica
        Task<bool> DeleteMejora(string id);

        // Actualiza una construcción específica
        Task<bool> UpdateConstruccion(string id, ConstruccionDTO construccionDto);

        // Elimina una construcción específica
        Task<bool> DeleteConstruccion(string id);
    }

}
