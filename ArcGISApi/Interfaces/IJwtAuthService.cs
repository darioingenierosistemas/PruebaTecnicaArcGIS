using System.Threading.Tasks;

namespace ArcGISApi.Interfaces
{
    public interface IJwtAuthService
    {
        string GenerateToken(string username, string password);
        Task<bool> ValidateToken(HttpContext httpContext);
    }
}
