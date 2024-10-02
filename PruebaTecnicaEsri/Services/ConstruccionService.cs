using Newtonsoft.Json;
using PruebaTecnicaEsri.DTO;
using PruebaTecnicaEsri.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaEsri.Services
{

    public class ConstruccionService
    {
        private readonly HttpClient _httpClient;

        public ConstruccionService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> UpdateConstruccion(string id, ConstruccionDTO construccionDTO, string token)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, $"{Urls.UpdateConstruccionUrl}/{id}");
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            requestMessage.Content = new StringContent(JsonConvert.SerializeObject(construccionDTO), Encoding.UTF8, "application/json");

            var response = await _httpClient.SendAsync(requestMessage);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteConstruccion(string id, string token)
        {

            var requestBody = new

            {
                objectIds = new[] { id }, // El ID de la construcción a eliminar
                f = "json", // Formato de respuesta
                rollbackOnFailure = true, // Opción para rollback
                returnDeleteResults = true // Para recibir resultados de la eliminación
            };

            // Crear el HttpRequestMessage
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, $"{Urls.DeleteConstruccionUrl}/{id}");
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            requestMessage.Content = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");

            // Enviar la solicitud
            var response = await _httpClient.SendAsync(requestMessage);
            var content = await response.Content.ReadAsStringAsync();

            // Verificar si la respuesta fue exitosa
            return response.IsSuccessStatusCode && content.Contains("\"success\": true");
        }
    }
}
