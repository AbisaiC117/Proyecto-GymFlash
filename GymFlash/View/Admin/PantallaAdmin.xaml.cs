using GymFlash.Model;
using GymFlash.View.PantallaAdmin;
using System.Windows;

namespace GymFlash.View
{
    public partial class AdminPanelWindow : Window
    {
        private UserModel _currentUser;

        public AdminPanelWindow(UserModel user)
        {
            InitializeComponent();
            _currentUser = user;
            this.Title = $"Panel de Administrador - {user.Name} {user.Lastname}";

            // Configuración inicial
            Loaded += PantallaAdmin_Loaded;
        }

        private void PantallaAdmin_Loaded(object sender, RoutedEventArgs e)
        {
            // Puedes agregar aquí cualquier inicialización adicional
            lblBienvenida.Content = $"Bienvenido, {_currentUser.Name}";
        }

        // Método para el botón "Administrar Rutinas"
        private void Button_AdministrarRutinas_Click(object sender, RoutedEventArgs e)
        {
            //var rutinasAdminWindow = new AdministrarRutinasWindow(_currentUser);
            //rutinasAdminWindow.Show();
            //this.Close();
        }

        // Método para el botón "Gestionar Administradores"
        private void Button_GestionarAdministradores_Click(object sender, RoutedEventArgs e)
        {

        }

        // Método para cerrar sesión
        private void CerrarSesion_Click(object sender, RoutedEventArgs e)
        {
            var MainWindow = new MainWindow();
            MainWindow.Show();
            this.Close();
        }

        private void Button_GestionarArticulos_Click(object sender, RoutedEventArgs e)
        {
            GestionarArticulosWindow articulosWindow = new GestionarArticulosWindow(_currentUser);
            articulosWindow.Show();
            this.Close(); 
        }
    }
}