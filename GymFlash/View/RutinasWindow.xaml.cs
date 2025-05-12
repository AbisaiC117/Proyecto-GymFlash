using System.Windows;
using GymFlash.Model;
using GymFlash.View;

namespace GymFlash
{
    public partial class RutinasWindow : Window
    {
        private UserModel usuario;
        public RutinasWindow(UserModel usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
        }

        private void Inicio_Click(object sender, RoutedEventArgs e)
        {
            HomeWindow ventanaInicio = new HomeWindow(usuario);
            ventanaInicio.Show();
            this.Close();
        }

        private void Membresias_Click(object sender, RoutedEventArgs e)
        {
            Membresia ventanaMembresias = new Membresia(usuario);
            ventanaMembresias.Show();
            this.Close();
        }

        private void Perfil_Click(object sender, RoutedEventArgs e)
        {
            PerfilUsuario ventanaPerfil = new PerfilUsuario(usuario);
            ventanaPerfil.Show();
            this.Close();
        }

        private void Rutinas_Click(object sender, RoutedEventArgs e)
        {
            // Ya estás en Rutinas, podrías recargar o simplemente no hacer nada
        }

        private void Tienda_Click(object sender, RoutedEventArgs e)
        {
            //falta la ventana de tienda
        }
    }
}
