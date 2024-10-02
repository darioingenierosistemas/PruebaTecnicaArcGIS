using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaEsri.Helpers
{
    public static class Urls
    {
        public static string BaseUrl = "https://localhost:7110"; // Cambiar a la URL base correspondiente

        // Endpoints Mejora
        public static string LoginUrl = $"{BaseUrl}/api/Auth/login";

        // Endpoints Mejora
        public static string UpdateMejoraUrl = $"{BaseUrl}/api/MejoraConstruccion/mejora";
        public static string DeleteMejoraUrl = $"{BaseUrl}/api/MejoraConstruccion/mejora/eliminar";

        // Endpoints Construccion
        public static string UpdateConstruccionUrl = $"{BaseUrl}/api/MejoraConstruccion/construccion";
        public static string DeleteConstruccionUrl = $"{BaseUrl}/api/MejoraConstruccion/construccion/eliminar";

    }

}
