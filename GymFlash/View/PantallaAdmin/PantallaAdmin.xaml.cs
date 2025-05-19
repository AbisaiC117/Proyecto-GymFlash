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
            
        }

        // Método para cerrar sesión
        private void CerrarSesion_Click(object sender, RoutedEventArgs e)
        {
            var MainWindow = new MainWindow();
            MainWindow.Show();
            this.Close();
        }
    }
}