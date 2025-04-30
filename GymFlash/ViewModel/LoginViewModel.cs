using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using GymFlash.View;

namespace GymFlash.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private string _usuario;
        private string _contrasena;

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

        public LoginViewModel()
        {
            EntrarCommand = new RelayCommand(Entrar);
        }

        private void Entrar(object parametro)
        {
            if (Usuario == "admin" && Contrasena == "1234")
            {
                // Aquí puedes abrir una nueva ventana, por ejemplo HomeWindow
                var ventana = new HomeWindow();
                ventana.Show();

                // Cerrar la ventana actual
                foreach (var win in System.Windows.Application.Current.Windows)
                {
                    if (win is MainWindow)
                        ((MainWindow)win).Close();
                }
            }
            else
            {
                System.Windows.MessageBox.Show("Credenciales incorrectas");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string nombre = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombre));
        }
    }
}
