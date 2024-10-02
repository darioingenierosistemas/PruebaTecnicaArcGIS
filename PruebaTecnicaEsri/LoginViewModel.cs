using Newtonsoft.Json;
using PruebaTecnicaEsri.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace PruebaTecnicaEsri
{
	public class LoginViewModel : INotifyPropertyChanged
    {
        private AuthService _authService;

        public LoginViewModel ()
		{
            _authService = new AuthService();
        }

        public async Task<bool> Login(string username, string password)
        {
            return await _authService.Login(username, password);
        }

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public event PropertyChangedEventHandler? PropertyChanged;
    }

}