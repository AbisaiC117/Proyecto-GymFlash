using GymFlash.Model;
using GymFlash.ViewModel;
using System.Windows;

namespace GymFlash.View
{
    public partial class TiendaWindow : Window
    {
        private UserModel usuario;

        public TiendaWindow(UserModel usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            this.DataContext = new ArticuloViewModel(usuario);
        }

        private void Inicio_Button(object sender, RoutedEventArgs e)
        {
            HomeWindow ventanaInicio = new HomeWindow(usuario);
            ventanaInicio.Show();
            this.Close();
        }

        private void Membresias_Button(object sender, RoutedEventArgs e)
        {
            Membresia ventanaMembresia = new Membresia(usuario);
            ventanaMembresia.Show();
            this.Close();
        }



        private void Tienda_Button(object sender, RoutedEventArgs e)
        {
            //Ya esta en la pantalla
        }

        private void Rutinas_Button(object sender, RoutedEventArgs e)
        {
            RutinasWindow ventanaRutinas = new RutinasWindow(usuario);
            ventanaRutinas.Show();
            this.Close();
        }

        private void Perfil_Button(object sender, RoutedEventArgs e)
        {
            PerfilUsuario ventanaPerfil = new PerfilUsuario(usuario);
            ventanaPerfil.Show();
            this.Close();
        }
    }
}
