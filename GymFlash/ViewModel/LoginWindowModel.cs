using System.ComponentModel;
using System.Net;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using GymFlash.Model;
using GymFlash.Repositories;
using GymFlash.View;

namespace GymFlash.ViewModel
{
    public class LoginWindowModel:ViewModelBase
    {
        private string _usuario;
        private string _contrasena;
        private readonly UserRepository _userRepository;

        public string Usuario
        {
            get => _usuario;
            set { _usuario = value; OnPropertyChanged(); }
        }

        public string Contrasena
        {
            get => _contrasena;
            set { _contrasena = value; OnPropertyChanged(); }
        }

        public ICommand EntrarCommand { get; }

        public LoginWindowModel()
        {
            EntrarCommand = new RelayCommand(Entrar);
        }

        private void Entrar(object parametro)
        {
            var credential = new NetworkCredential(Usuario, Contrasena);

            if (_userRepository.AuthenticateUser(credential))
            {
                UserModel usuario = _userRepository.GetByUsername(Usuario);

                HomeWindow home = new HomeWindow(usuario);
                home.Show();

                foreach (var win in System.Windows.Application.Current.Windows)
                {
                    if (win is MainWindow)
                        ((MainWindow)win).Close();
                }
            }
            else
            {
                MessageBox.Show("Credenciales incorrectas");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string nombre = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombre));
        }
    }
}
