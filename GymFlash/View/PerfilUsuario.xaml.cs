using GymFlash.Model;
using System.Windows;

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
            // Aquí podrías implementar un botón adicional
        }
    }
}
