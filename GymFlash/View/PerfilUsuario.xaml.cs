using System.Windows;
using GymFlash.Model;

namespace GymFlash.View
{
    public partial class PerfilUsuario : Window
    {
        private readonly UserModel _usuario;

        public PerfilUsuario(UserModel usuario)
        {
            InitializeComponent();
            _usuario = usuario;

            // Asignamos el usuario como DataContext para los bindings
            DataContext = _usuario;
        }

        private void EditarPerfil_Click(object sender, RoutedEventArgs e)
        {
            // Solo muestra la ventana de edición sin esperar actualización
            EditarPerfil ventanaEditar = new EditarPerfil(_usuario);
            ventanaEditar.ShowDialog();
        }

        private void Inicio_Click(object sender, RoutedEventArgs e)
        {
            HomeWindow home = new HomeWindow(_usuario);
            home.Show();
            this.Close();
        }

        private void Membresias_Click(object sender, RoutedEventArgs e)
        {
            Membresia ventanaMembresias = new Membresia(_usuario);
            ventanaMembresias.Show();
            this.Close();
        }

        private void Rutinas_Click(object sender, RoutedEventArgs e)
        {
            RutinasWindow ventanaRutinas = new RutinasWindow(_usuario);
            ventanaRutinas.Show();
            this.Close();
        }

        private void Tienda_Click(object sender, RoutedEventArgs e)
        {
            // Implementar lógica para la tienda
        }7
        private void Perfil_Click(object sender, RoutedEventArgs e)
        {
            // Lógica cuando se hace clic en el botón Perfil
            // Puedes dejarlo vacío si no necesita hacer nada
            // o implementar la navegación que necesites
        }
        private void CompartirPerfil_Click(object sender, RoutedEventArgs e)
        {
            // Lógica para compartir el perfil
            // Por ejemplo:
            MessageBox.Show("Función de compartir perfil en desarrollo", "Información",
                          MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}