using Newtonsoft.Json;
using PruebaTecnicaEsri.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using PruebaTecnicaEsri.Helpers;

namespace PruebaTecnicaEsri.Services
{
    public class MejoraService
    {
        private readonly HttpClient _httpClient;

        public MejoraService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> UpdateMejora(string id, MejoraDTO mejoraDto, string token)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, $"{Urls.UpdateMejoraUrl}/{id}");
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            requestMessage.Content = new StringContent(JsonConvert.SerializeObject(mejoraDto), Encoding.UTF8, "application/json");

            var response = await _httpClient.SendAsync(requestMessage);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteMejora(string id, string token)
        {
           
            var requestBody = new

            {
                objectIds = new[] { id }, // El ID de la construcción a eliminar
                f = "json", // Formato de respuesta
                rollbackOnFailure = true, // Opción para rollback
                returnDeleteResults = true // Para recibir resultados de la eliminación
            };

            // Crear el HttpRequestMessage
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, $"{Urls.DeleteMejoraUrl}/{id}");
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
