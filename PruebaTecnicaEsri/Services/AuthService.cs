using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PruebaTecnicaEsri.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaEsri.Services
{
    public class AuthService
    {
        private static string _token;

        public static string Token
        {
            get => _token;
            set => _token = value;
        }

        public async Task<bool> Login(string username, string password)
        {
            using (var client = new HttpClient())
            {
                var loginDto = new
                {
                    Username = username,
                    Password = password
                };

                var json = JsonConvert.SerializeObject(loginDto);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync("https://localhost:7110/api/Auth/login", content);

                if (response.IsSuccessStatusCode)
                {
                    var responseData = await response.Content.ReadAsStringAsync();
                    var tokenResponse = JsonConvert.DeserializeObject<TokenResponse>(responseData);
                    Token = tokenResponse.Token; // Store token in the global variable
                    TokenStorage.Token = Token;
                    return true;
                }

                return false;
            }
        }
    }
    public class TokenResponse
    {
        public string Token { get; set; }
    }
}
