using GymFlash.Model;
using System.Diagnostics;
using System.Windows;

namespace GymFlash.View
{
    /// <summary>
    /// Lógica de interacción para HomeWindow.xaml
    /// </summary>
    public partial class HomeWindow : Window
    {
        private UserModel usuario;
        public HomeWindow(UserModel usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
        }

        private void Membresia_Button(object sender, RoutedEventArgs e)
        {
            Membresia Membresia = new Membresia(usuario);
            Membresia.Show();
            this.Close();
        }

        private void Rutinas_Button(object sender, RoutedEventArgs e)
        {
            RutinasWindow RutinasWindow = new RutinasWindow(usuario);
            RutinasWindow.Show();
            this.Close();
        }

        private void Perfil_Button(object sender, RoutedEventArgs e)
        {
            PerfilUsuario ventanaPerfil = new PerfilUsuario(usuario);
            ventanaPerfil.Show();
            this.Close();
        }

        private void OpenGymLocation_Click(object sender, RoutedEventArgs e)
        {
            string gymUrl = "https://www.google.com/maps/place/GYM+Cardiofitness+Club/@22.758851,-102.573542,16z";
            Process.Start(new ProcessStartInfo
            {
                FileName = gymUrl,
                UseShellExecute = true
            });
        }

        private void Tienda_Button(object sender, RoutedEventArgs e)
        {
            TiendaWindow TiendaWindow = new TiendaWindow(usuario);
            TiendaWindow.Show();
            this.Close();
        }
    }
}
