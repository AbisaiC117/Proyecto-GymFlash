using System.Windows;
using System.Windows.Controls;
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

        private void Rutinas_Click(object sender, RoutedEventArgs e)
        {
            // Ya estás en esta ventana
        }

        private void Perfil_Click(object sender, RoutedEventArgs e)
        {
            PerfilUsuario ventanaPerfil = new PerfilUsuario(usuario);
            ventanaPerfil.Show();
            this.Close();
        }

        private void Tienda_Click(object sender, RoutedEventArgs e)
        {
            TiendaWindow tiendaWindow = new TiendaWindow(usuario);
            tiendaWindow.Show();
            this.Close();
        }

        private void GenerarPDF_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.Tag != null)
            {
                string rutinaId = btn.Tag.ToString();
                // TODO: Lógica para generar el PDF basado en el ID
                MessageBox.Show($"Generar PDF para la rutina con ID: {rutinaId}", "PDF", MessageBoxButton.OK, MessageBoxImage.Information);

               
            }
        }
    }
}
