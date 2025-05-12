using System.Windows;

namespace GymFlash.View
{
    public partial class PerfilUsuario : Window
    {
        public PerfilUsuario()
        {
            InitializeComponent();
        }

        private void EditarPerfil_Click(object sender, RoutedEventArgs e)
        {
            EditarPerfil ventanaEditar = new EditarPerfil();
            ventanaEditar.ShowDialog();
        }
        private void CompartirPerfil_Click(object sender, RoutedEventArgs e)
        {
            CompartirPerfil ventanaCompartir = new CompartirPerfil();
            ventanaCompartir.ShowDialog();
        }

    }
}
