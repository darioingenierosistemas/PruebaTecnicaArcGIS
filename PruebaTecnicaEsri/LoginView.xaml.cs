using Esri.ArcGISRuntime.UI.Controls;
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
using System.Windows.Shapes;

namespace PruebaTecnicaEsri
{
    /// <summary>
    /// Lógica de interacción para LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        LoginViewModel viewModel = new LoginViewModel();
        public LoginView()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            bool response = await viewModel.Login(txtUser.Text, txtPass.Password);

            if (response)
            {
                var mainAppWindow = new MapView(); 
                mainAppWindow.Show();

                Application.Current.MainWindow = mainAppWindow;

                this.Close();
            }
            else
            {
                MessageBox.Show("Usuario o Contraseña son invalidos.", "Login Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
