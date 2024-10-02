using Esri.ArcGISRuntime.Data;
using Esri.ArcGISRuntime.Geometry;
using Esri.ArcGISRuntime.Location;
using Esri.ArcGISRuntime.Mapping;
using Esri.ArcGISRuntime.Security;
using Esri.ArcGISRuntime.Symbology;
using Esri.ArcGISRuntime.Tasks;
using Esri.ArcGISRuntime.UI;
using Esri.ArcGISRuntime.UI.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaWpfArcGIS
{
    /// <summary>
    /// Provides map data to an application
    /// </summary>
    public class MapViewModel : INotifyPropertyChanged
    {
        public MapViewModel()
        {

            Initialize();

        }

        private void Initialize()
        {
            _mapEsri = new Map(BasemapStyle.ArcGISStreets);
            string featureServiceUrl = "https://calidadevolutionscsas.com/server/rest/services/sigebPredial/GPR_CartoGestion/FeatureServer/0";
            FeatureLayer featureLayer = new FeatureLayer(new Uri(featureServiceUrl));
            _mapEsri.OperationalLayers.Add(featureLayer);

            _mapEsri.LoadStatusChanged += _map_LoadStatusChanged;
        }

        private void _map_LoadStatusChanged(object? sender, Esri.ArcGISRuntime.LoadStatusEventArgs e)
        {
            Debug.WriteLine($"El status de carga cambio de {e.OldStatus} a {e.Status}");
            Debug.WriteLineIf(e.Status == Esri.ArcGISRuntime.LoadStatus.FailedToLoad, $"Error de Carga:  {MapEsri.LoadError?.Message}");
        }

        private Map _mapEsri;

        public Map MapEsri
        {
            get => _mapEsri;
            set { _mapEsri = value; OnPropertyChanged(); }
        }


        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
