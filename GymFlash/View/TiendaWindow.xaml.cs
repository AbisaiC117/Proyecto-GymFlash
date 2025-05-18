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
    }
}
