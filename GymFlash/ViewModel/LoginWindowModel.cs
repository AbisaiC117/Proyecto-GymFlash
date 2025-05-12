using System.ComponentModel;

namespace GymFlash.ViewModel
{
    public class LoginWindowModel : INotifyPropertyChanged
    {
        private string usuario;
        private string contrasena;

        public string Usuario
        {
            get => usuario;
            set
            {
                usuario = value;
                OnPropertyChanged(nameof(Usuario));
            }
        }

        public string Contrasena
        {
            get => contrasena;
            set
            {
                contrasena = value;
                OnPropertyChanged(nameof(Contrasena));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
