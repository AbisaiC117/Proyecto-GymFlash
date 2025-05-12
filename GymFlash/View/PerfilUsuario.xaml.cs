using System.Windows;
using GymFlash.Model;

namespace GymFlash.View
{
    public partial class PerfilUsuario : Window
    {
        private UserModel usuario;
        public PerfilUsuario(UserModel usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            DataContext = usuario;
        }

        private void EditarPerfil_Click(object sender, RoutedEventArgs e)
        {
            EditarPerfil ventanaEditar = new EditarPerfil(usuario);
            ventanaEditar.ShowDialog();
        }
        private void CompartirPerfil_Click(object sender, RoutedEventArgs e)
        {
            CompartirPerfil ventanaCompartir = new CompartirPerfil();
            ventanaCompartir.ShowDialog();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

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
            // aqui me encuentro
        }

        private void Rutinas_Click(object sender, RoutedEventArgs e)
        {
            RutinasWindow ventanaRutinas = new RutinasWindow(usuario);
            ventanaRutinas.Show();
            this.Close();
        }
        private void Tienda_Click(object sender, RoutedEventArgs e)
        {
            //falta la ventana de tienda
        }
    }
}
