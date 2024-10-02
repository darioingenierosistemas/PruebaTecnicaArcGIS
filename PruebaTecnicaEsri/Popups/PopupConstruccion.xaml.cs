using Esri.ArcGISRuntime.Data;
using PruebaTecnicaEsri.Repository;
using PruebaTecnicaEsri.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PruebaTecnicaEsri.Popups
{
    /// <summary>
    /// Lógica de interacción para PopupConstruccion.xaml
    /// </summary>
    public partial class PopupConstruccion : Window
    {
        private ArcGISFeature _feature;
        public PopupConstruccion(ArcGISFeature feature)
        {
            InitializeComponent();
            _feature = feature;

            TipoUnidadEspacialTextBox.Text = _feature.Attributes["TipoUnidadEspacial"]?.ToString();
            AreaCalculadaTextBox.Text = _feature.Attributes["AreaCalculada"]?.ToString();
            ValorUnitarioTextBox.Text = _feature.Attributes["ValorUnitario"]?.ToString();
            ValorNuevoTextBox.Text = _feature.Attributes["ValorNuevo"]?.ToString();
            CodConstruccionTextBox.Text = _feature.Attributes["CodConstruccion"]?.ToString();
            EstadoConstruccionTextBox.Text = _feature.Attributes["EstadoConstruccion"]?.ToString();
            UCTipoConstruccionTextBox.Text = _feature.Attributes["UCTipoConstruccion"]?.ToString();
            UCNumeroPisosTextBox.Text = _feature.Attributes["UCNumeroPisos"]?.ToString();
            UCAnioConstruccionTextBox.Text = _feature.Attributes["UCAnioConstruccion"]?.ToString();
            UCNumSalasTextBox.Text = _feature.Attributes["UCNumSalas"]?.ToString();
            UCNumLocalesTextBox.Text = _feature.Attributes["UCNumLocales"]?.ToString();
            UCNumHabitacionesTextBox.Text = _feature.Attributes["UCNumHabitaciones"]?.ToString();
            UCNumBaniosTextBox.Text = _feature.Attributes["UCNumBanios"]?.ToString();
            UCNumCocinasTextBox.Text = _feature.Attributes["UCNumCocinas"]?.ToString();
            UCNumOficinasTextBox.Text = _feature.Attributes["UCNumOficinas"]?.ToString();
            UCNumEstudiosTextBox.Text = _feature.Attributes["UCNumEstudios"]?.ToString();
            UCNumBodegasTextBox.Text = _feature.Attributes["UCNumBodegas"]?.ToString();
            UCRelacionSuperficieTextBox.Text = _feature.Attributes["UCRelacionSuperficie"]?.ToString();
            UCPisoTextBox.Text = _feature.Attributes["UCPiso"]?.ToString();
            UCEstadoConservacionTextBox.Text = _feature.Attributes["UCEstadoConservacion"]?.ToString();
            UCMaterialCubiertaTextBox.Text = _feature.Attributes["UCMaterialCubierta"]?.ToString();
            UCMaterialParedesTextBox.Text = _feature.Attributes["UCMaterialParedes"]?.ToString();
            UCMaterialPisoTextBox.Text = _feature.Attributes["UCMaterialPiso"]?.ToString();
            ObservacionesModificacionTextBox.Text = _feature.Attributes["ObservacionesModificacion"]?.ToString();
            ObservacionTextBox.Text = _feature.Attributes["Observacion"]?.ToString();
            CodigoNegocioUnidadEspacialTextBox.Text = _feature.Attributes["CodigoNegocioUnidadEspacial"]?.ToString();
            RelacionUnidadEspacialTextBox.Text = _feature.Attributes["Relacion_UnidadEspacial"]?.ToString();
            FechaSicronizacionTextBox.Text = _feature.Attributes["FechaSicronizacion"]?.ToString();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            // Actualizar los atributos con los nuevos valores
            _feature.Attributes["TipoUnidadEspacial"] = Convert.ToInt32(TipoUnidadEspacialTextBox.Text);
            _feature.Attributes["AreaCalculada"] = Convert.ToDouble(AreaCalculadaTextBox.Text);
            _feature.Attributes["ValorUnitario"] = Convert.ToDouble(ValorUnitarioTextBox.Text);
            _feature.Attributes["ValorNuevo"] = Convert.ToDouble(ValorNuevoTextBox.Text);
            _feature.Attributes["CodConstruccion"] = CodConstruccionTextBox.Text;
            _feature.Attributes["EstadoConstruccion"] = EstadoConstruccionTextBox.Text;
            _feature.Attributes["UCTipoConstruccion"] = UCTipoConstruccionTextBox.Text;
            _feature.Attributes["UCNumeroPisos"] = Convert.ToInt32(UCNumeroPisosTextBox.Text);
            _feature.Attributes["UCAnioConstruccion"] = Convert.ToInt32(UCAnioConstruccionTextBox.Text);
            _feature.Attributes["UCNumSalas"] = Convert.ToInt32(UCNumSalasTextBox.Text);
            _feature.Attributes["UCNumLocales"] = Convert.ToInt32(UCNumLocalesTextBox.Text);
            _feature.Attributes["UCNumHabitaciones"] = Convert.ToInt32(UCNumHabitacionesTextBox.Text);
            _feature.Attributes["UCNumBanios"] = Convert.ToInt32(UCNumBaniosTextBox.Text);
            _feature.Attributes["UCNumCocinas"] = Convert.ToInt32(UCNumCocinasTextBox.Text);
            _feature.Attributes["UCNumOficinas"] = Convert.ToInt32(UCNumOficinasTextBox.Text);
            _feature.Attributes["UCNumEstudios"] = Convert.ToInt32(UCNumEstudiosTextBox.Text);
            _feature.Attributes["UCNumBodegas"] = Convert.ToInt32(UCNumBodegasTextBox.Text);
            _feature.Attributes["UCRelacionSuperficie"] = UCRelacionSuperficieTextBox.Text;
            _feature.Attributes["UCPiso"] = UCPisoTextBox.Text;
            _feature.Attributes["UCEstadoConservacion"] = UCEstadoConservacionTextBox.Text;
            _feature.Attributes["UCMaterialCubierta"] = UCMaterialCubiertaTextBox.Text;
            _feature.Attributes["UCMaterialParedes"] = UCMaterialParedesTextBox.Text;
            _feature.Attributes["UCMaterialPiso"] = UCMaterialPisoTextBox.Text;
            _feature.Attributes["ObservacionesModificacion"] = ObservacionesModificacionTextBox.Text;
            _feature.Attributes["Observacion"] = ObservacionTextBox.Text;
            _feature.Attributes["CodigoNegocioUnidadEspacial"] = CodigoNegocioUnidadEspacialTextBox.Text;
            _feature.Attributes["Relacion_UnidadEspacial"] = RelacionUnidadEspacialTextBox.Text;
            _feature.Attributes["FechaSicronizacion"] = DateTime.TryParse(FechaSicronizacionTextBox.Text, out DateTime fecha) ? (DateTime?)fecha : null;


            DialogResult = true;
            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private async void Borrar_Click(object sender, RoutedEventArgs e)
        {
            var service = new ConstruccionService(new HttpClient());
            var token = TokenStorage.Token;
            var result = await service.DeleteConstruccion(CodConstruccionTextBox.Text, token);

            if (result)
            {
                MessageBox.Show("Mejora actualizada exitosamente.");
                DialogResult = true;
                Close();
            }
            else
            {
                MessageBox.Show("Error al actualizar la mejora.");
            }
            DialogResult = false;
            Close();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !int.TryParse(e.Text, out _);
        }

        private void DecimalValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !double.TryParse(e.Text, out _);
        }
    }
}
