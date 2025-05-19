using System;
using System.Windows;
using GymFlash.Model;
using GymFlash.View;

namespace GymFlash.View
{
    public partial class PantallaAdmin : Window
    {
        private UserModel _currentUser;

        public PantallaAdmin(UserModel user)
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
            //var gestionAdminWindow = new GestionarAdministradoresWindow(_currentUser);
            //gestionAdminWindow.Show();
            //this.Close();
        }

        // Método para cerrar sesión
        private void CerrarSesion_Click(object sender, RoutedEventArgs e)
        {
            var loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }

        // Métodos para navegación (si los mantienes)
        private void Button_Inicio_Click(object sender, RoutedEventArgs e)
        {
            // Si quieres que el admin también pueda ir al inicio
            var homeWindow = new HomeWindow(_currentUser);
            homeWindow.Show();
            this.Close();
        }

        private void Button_Membresia_Click(object sender, RoutedEventArgs e)
        {
            var membresiaWindow = new Membresia(_currentUser);
            membresiaWindow.Show();
            this.Close();
        }

        private void Button_Rutinas_Click(object sender, RoutedEventArgs e)
        {
            var rutinasWindow = new RutinasWindow(_currentUser);
            rutinasWindow.Show();
            this.Close();
        }

        private void Button_Perfil_Click(object sender, RoutedEventArgs e)
        {
            var perfilWindow = new PerfilUsuario(_currentUser);
            perfilWindow.Show();
            this.Close();
        }

        private void Button_Tienda_Click(object sender, RoutedEventArgs e)
        {
            var tiendaWindow = new TiendaWindow(_currentUser);
            tiendaWindow.Show();
            this.Close();
        }
    }
}