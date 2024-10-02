using Esri.ArcGISRuntime.Data;
using PruebaTecnicaEsri.Popups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PruebaTecnicaEsri
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MapView : Window
    {
        public MapView()
        {
            InitializeComponent();
            MapViewEsri.GeoViewTapped += MapViewEsri_GeoViewTapped;
        }

        private async void MapViewEsri_GeoViewTapped(object? sender, Esri.ArcGISRuntime.UI.Controls.GeoViewInputEventArgs e)
        {
            try
            {
                MapViewEsri.DismissCallout();
                IReadOnlyList<IdentifyLayerResult> identifyLayer = await MapViewEsri.IdentifyLayersAsync(e.Position, 15, false, 10);
                var result = await MapViewEsri.IdentifyLayersAsync(e.Position, 10, false);
                string resultLayer = "";

                foreach (IdentifyLayerResult layerResult in identifyLayer)
                {
                    resultLayer += layerResult.LayerContent.Name + "\n"; // Separa las capas con un salto de línea para mejor legibilidad.
                }

                if (result != null && result.Count > 0)
                {
                    // Identificar la primera capa y el feature seleccionado
                    var layerResult = result.First();
                    if (layerResult != null && layerResult.GeoElements.Count > 0)
                    {
                        var geoElement = layerResult.GeoElements.First();
                        var feature = geoElement as ArcGISFeature;

                        if (feature != null)
                        {
                            await feature.LoadAsync();
                            var attributes = feature.Attributes;

                            if (resultLayer.Contains("Mejora")) 
                            {
                                var editor = new PopupMejora(feature);
                                if (editor.ShowDialog() == true)
                                {
                                    await feature.FeatureTable.UpdateFeatureAsync(feature);
                                    await ((ServiceFeatureTable)feature.FeatureTable).ApplyEditsAsync();
                                }
                            }
                            else if (resultLayer.Contains("Construccion"))
                            {
                                var editor = new PopupConstruccion(feature);
                                if (editor.ShowDialog() == true)
                                {
                                    await feature.FeatureTable.UpdateFeatureAsync(feature);
                                    await ((ServiceFeatureTable)feature.FeatureTable).ApplyEditsAsync();
                                }
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error");
            }
        }
    }
}
