using Esri.ArcGISRuntime.Data;
using Esri.ArcGISRuntime.Geometry;
using Esri.ArcGISRuntime.Location;
using Esri.ArcGISRuntime.Mapping;
using Esri.ArcGISRuntime.Security;
using Esri.ArcGISRuntime.Symbology;
using Esri.ArcGISRuntime.Tasks;
using Esri.ArcGISRuntime.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Esri.ArcGISRuntime.Portal;
using Esri.ArcGISRuntime.UI.Controls;

namespace PruebaTecnicaEsri
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

        private async void Initialize()
        {

            double latitude = 5.084377;   
            double longitude = -73.780041;
            double scale = 150;

            MapPoint centerPoint = new MapPoint(longitude, latitude, SpatialReferences.Wgs84);
            Viewpoint initialViewpoint = new Viewpoint(centerPoint, scale);

            _mapEsri = new Map(SpatialReferences.WebMercator)
            {

                InitialViewpoint = initialViewpoint,
                Basemap = new Basemap(BasemapStyle.ArcGISTopographic)
            };

            // ZHG (11)
            string zhgLayerUrl = "https://calidadevolutionscsas.com/server/rest/services/sigebPredial/GPR_CartoGestion/FeatureServer/11";
            var zhgLayer = new ServiceFeatureTable(new Uri(zhgLayerUrl));
            await zhgLayer.LoadAsync();
            _mapEsri.OperationalLayers.Add(new FeatureLayer(zhgLayer));

            // ZHF (12)
            string zhfLayerUrl = "https://calidadevolutionscsas.com/server/rest/services/sigebPredial/GPR_CartoGestion/FeatureServer/12";
            var zhfLayer = new ServiceFeatureTable(new Uri(zhfLayerUrl));
            await zhfLayer.LoadAsync();
            _mapEsri.OperationalLayers.Add(new FeatureLayer(zhfLayer));

            // Mejora (1)
            string mejoraLayerUrl = "https://calidadevolutionscsas.com/server/rest/services/sigebPredial/GPR_CartoGestion/FeatureServer/1";
            var mejoraLayer = new ServiceFeatureTable(new Uri(mejoraLayerUrl));
            await mejoraLayer.LoadAsync();
            _mapEsri.OperationalLayers.Add(new FeatureLayer(mejoraLayer));

            // Construccion (5)
            string construccionLayerUrl = "https://calidadevolutionscsas.com/server/rest/services/sigebPredial/GPR_CartoGestion/FeatureServer/5";
            var construccionLayer = new ServiceFeatureTable(new Uri(construccionLayerUrl));
            await construccionLayer.LoadAsync();
            _mapEsri.OperationalLayers.Add(new FeatureLayer(construccionLayer));

            _mapEsri.LoadStatusChanged += _mapEsri_LoadStatusChanged; ;
        }

        private void _mapEsri_LoadStatusChanged(object? sender, Esri.ArcGISRuntime.LoadStatusEventArgs e)
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
