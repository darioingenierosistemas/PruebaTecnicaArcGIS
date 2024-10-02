using Esri.ArcGISRuntime.Data;
using PruebaTecnicaEsri.Repository;
using PruebaTecnicaEsri.Services;
using PruebaTecnicaEsri.DTO;
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

        private async void Save_Click(object sender, RoutedEventArgs e)
        {
            var constuccionDTO = new ConstruccionDTO
            {
                TipoUnidadEspacial = Convert.ToInt32(TipoUnidadEspacialTextBox.Text),
                AreaCalculada = Convert.ToDouble(AreaCalculadaTextBox.Text),
                ValorUnitario = Convert.ToDouble(ValorUnitarioTextBox.Text),
                ValorNuevo = Convert.ToDouble(ValorNuevoTextBox.Text),
                CodConstruccion = CodConstruccionTextBox.Text,
                EstadoConstruccion = EstadoConstruccionTextBox.Text,
                UCTipoConstruccion = UCTipoConstruccionTextBox.Text,
                UCNumeroPisos = Convert.ToInt32(UCNumeroPisosTextBox.Text),
                UCAnioConstruccion = Convert.ToInt32(UCAnioConstruccionTextBox.Text),
                UCNumSalas = Convert.ToInt32(UCNumSalasTextBox.Text),
                UCNumLocales = Convert.ToInt32(UCNumLocalesTextBox.Text),
                UCNumHabitaciones = Convert.ToInt32(UCNumHabitacionesTextBox.Text),
                UCNumBanios = Convert.ToInt32(UCNumBaniosTextBox.Text),
                UCNumCocinas = Convert.ToInt32(UCNumCocinasTextBox.Text),
                UCNumOficinas = Convert.ToInt32(UCNumOficinasTextBox.Text),
                UCNumEstudios = Convert.ToInt32(UCNumEstudiosTextBox.Text),
                UCNumBodegas = Convert.ToInt32(UCNumBodegasTextBox.Text),
                UCRelacionSuperficie = UCRelacionSuperficieTextBox.Text,
                UCPiso = UCPisoTextBox.Text,
                UCEstadoConservacion = UCEstadoConservacionTextBox.Text,
                UCMaterialCubierta = UCMaterialCubiertaTextBox.Text,
                UCMaterialParedes = UCMaterialParedesTextBox.Text,
                UCMaterialPiso = UCMaterialPisoTextBox.Text,
                ObservacionesModificacion = ObservacionesModificacionTextBox.Text,
                Observacion = ObservacionTextBox.Text,
                CodigoNegocioUnidadEspacial = CodigoNegocioUnidadEspacialTextBox.Text,
                RelacionUnidadEspacial = RelacionUnidadEspacialTextBox.Text,
                FechaSicronizacion = DateTime.TryParse(FechaSicronizacionTextBox.Text, out DateTime fecha) ? (DateTime?)fecha : null
            };

            var service = new ConstruccionService(new HttpClient());
            var token = TokenStorage.Token;
            var result = await service.UpdateConstruccion(CodConstruccionTextBox.Text, constuccionDTO, token);

            if (result)
            {
                MessageBox.Show("Construccion actualizada exitosamente.");
                DialogResult = true;
                Close();
            }
            else
            {
                DialogResult = false;
                Close();
                MessageBox.Show("Error al actualizar la construccion.");
            }
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
                MessageBox.Show("Construccioneliminada exitosamente.");
                DialogResult = true;
                Close();
            }
            else
            {
                DialogResult = false;
                Close();
                MessageBox.Show("Error al eliminar la construccion.");
               
            }
            
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
