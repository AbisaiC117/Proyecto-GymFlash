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

        private void Perfil_Click(object sender, RoutedEventArgs e)
        {
            //Ya esta en la pantalla Perfil
        }

        private void Tienda_Click(object sender, RoutedEventArgs e)
        {
            TiendaWindow tiendaWindow = new TiendaWindow(_usuario);
            tiendaWindow.Show();
            this.Close();
        }
        private void CompartirPerfil_Click(object sender, RoutedEventArgs e)
        {
            CompartirPerfil compartirPerfil = new CompartirPerfil();
            compartirPerfil.ShowDialog();        }

        private void TextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

        
    }
}