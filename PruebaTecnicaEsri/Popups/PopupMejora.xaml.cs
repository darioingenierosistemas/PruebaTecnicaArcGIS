using Esri.ArcGISRuntime.Data;
using PruebaTecnicaEsri.DTO;
using PruebaTecnicaEsri.Repository;
using PruebaTecnicaEsri.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
    /// Lógica de interacción para PopupMejora.xaml
    /// </summary>
    public partial class PopupMejora : Window
    {
        private ArcGISFeature _feature;
        public PopupMejora(ArcGISFeature feature)
        {
            InitializeComponent();
            _feature = feature;

            CodigoMejoraTextBox.Text = _feature.Attributes["CodigoMejora"]?.ToString();
            InvasionTextBox.Text = _feature.Attributes["Invasion"]?.ToString();
            TipoMejoraTextBox.Text = _feature.Attributes["TipoMejora"]?.ToString();
            EstadoConservacionTextBox.Text = _feature.Attributes["EstadoConservacion"]?.ToString();
            AreaMejoraTextBox.Text = _feature.Attributes["AreaMejora"]?.ToString();
            EdadTextBox.Text = _feature.Attributes["Edad"]?.ToString();
            EdadAniosTextBox.Text = _feature.Attributes["EdadAnios"]?.ToString();
            CantidadTextBox.Text = _feature.Attributes["Cantidad"]?.ToString();
            UnidadTextBox.Text = _feature.Attributes["Unidad"]?.ToString();
            ValorAnuevoTextBox.Text = _feature.Attributes["ValorAnuevo"]?.ToString();
            ValorMejoraTextBox.Text = _feature.Attributes["ValorMejora"]?.ToString();
            ValorUnitarioTextBox.Text = _feature.Attributes["ValorUnitario"]?.ToString();
            CalidadDatoTextBox.Text = _feature.Attributes["CalidadDato"]?.ToString();
            FuenteDatoTextBox.Text = _feature.Attributes["FuenteDato"]?.ToString();
            DescripcionTextBox.Text = _feature.Attributes["Descripcion"]?.ToString();
            FKIDTramoPredialTextBox.Text = _feature.Attributes["FKIDTramoPredial"]?.ToString();
            CodigoNegocioMejoraTextBox.Text = _feature.Attributes["CodigoNegocioMejora"]?.ToString();
            FechaCreacionTextBox.Text = _feature.Attributes["FechaCreacion"]?.ToString();
            UsuarioCreadorTextBox.Text = _feature.Attributes["UsuarioCreador"]?.ToString();
            FechaModificacionTextBox.Text = _feature.Attributes["FechaModificacion"]?.ToString();
            UsuarioModificaTextBox.Text = _feature.Attributes["UsuarioModifica"]?.ToString();
            ObjectIdTextBox.Text = _feature.Attributes["OBJECTID"]?.ToString();
            IdMejoraTextBox.Text = _feature.Attributes["IDMejora"]?.ToString();
            RelacionMejoraTextBox.Text = _feature.Attributes["Relacion_Mejora"]?.ToString();
            RelacionMigracionTextBox.Text = _feature.Attributes["Relacion_Migracion"]?.ToString();
            FechaSincronizacionTextBox.Text = _feature.Attributes["FechaSicronizacion"]?.ToString();
        }

        private async void Save_Click(object sender, RoutedEventArgs e)
        {
            var mejoraDto = new MejoraDTO
            {
                CodigoMejora = CodigoMejoraTextBox.Text,
                Invasion = int.TryParse(InvasionTextBox.Text, out var invasion) ? invasion : (int?)null,
                TipoMejora = TipoMejoraTextBox.Text,
                EstadoConservacion = EstadoConservacionTextBox.Text,
                AreaMejora = double.TryParse(AreaMejoraTextBox.Text, out var areaMejora) ? areaMejora : (double?)null,
                Edad = EdadTextBox.Text,
                EdadAnios = int.TryParse(EdadAniosTextBox.Text, out var edadAnios) ? edadAnios : (int?)null,
                Cantidad = int.TryParse(CantidadTextBox.Text, out var cantidad) ? cantidad : (int?)null,
                Unidad = UnidadTextBox.Text,
                ValorAnuevo = double.TryParse(ValorAnuevoTextBox.Text, out var valorAnuevo) ? valorAnuevo : (double?)null,
                ValorMejora = double.TryParse(ValorMejoraTextBox.Text, out var valorMejora) ? valorMejora : (double?)null,
                ValorUnitario = double.TryParse(ValorUnitarioTextBox.Text, out var valorUnitario) ? valorUnitario : (double?)null,
                CalidadDato = int.TryParse(CalidadDatoTextBox.Text, out var calidadDato) ? calidadDato : (int?)null,
                FuenteDato = int.TryParse(FuenteDatoTextBox.Text, out var fuenteDato) ? fuenteDato : (int?)null,
                Descripcion = DescripcionTextBox.Text,
                FKIDTramoPredial = Guid.TryParse(FKIDTramoPredialTextBox.Text, out var fkidTramoPredial) ? fkidTramoPredial : (Guid?)null,
                CodigoNegocioMejora = CodigoNegocioMejoraTextBox.Text,
                FechaCreacion = DateTime.TryParse(FechaCreacionTextBox.Text, out var fechaCreacion) ? fechaCreacion : (DateTime?)null,
                UsuarioCreador = UsuarioCreadorTextBox.Text,
                FechaModificacion = DateTime.TryParse(FechaModificacionTextBox.Text, out var fechaModificacion) ? fechaModificacion : (DateTime?)null,
                UsuarioModifica = UsuarioModificaTextBox.Text,
                OBJECTID = int.TryParse(ObjectIdTextBox.Text, out var objectId) ? objectId : 0,
                IDMejora = Guid.TryParse(IdMejoraTextBox.Text, out var idMejora) ? idMejora : Guid.Empty,
                RelacionMejora = RelacionMejoraTextBox.Text,
                RelacionMigracion = Guid.TryParse(RelacionMigracionTextBox.Text, out var relacionMigracion) ? relacionMigracion : (Guid?)null,
                FechaSicronizacion = DateTime.TryParse(FechaSincronizacionTextBox.Text, out var fechaSicronizacion) ? fechaSicronizacion : (DateTime?)null
            };


            var service = new MejoraService(new HttpClient());
            var token = TokenStorage.Token;
            var result = await service.UpdateMejora(ObjectIdTextBox.Text, mejoraDto, token);

            if (result)
            {
                MessageBox.Show("Mejora actualizada exitosamente.");
                DialogResult = true;
                Close();
            }
            else
            {
                MessageBox.Show("Error al actualizar la mejora.");
                DialogResult = true;
                Close();
            }
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private async void Borrar_Click(object sender, RoutedEventArgs e)
        {
            var service = new MejoraService(new HttpClient());
            var token = TokenStorage.Token;
            var result = await service.DeleteMejora(ObjectIdTextBox.Text, token);

            if (result)
            {
                MessageBox.Show("Mejora actualizada exitosamente.");
                DialogResult = true;
                Close();
            }
            else
            {
                MessageBox.Show("Error al actualizar la mejora.");
                DialogResult = false;
                Close();
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
