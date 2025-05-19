using GymFlash.Model;
using GymFlash.Repositories;
using GymFlash.View;
using GymFlash.ViewModel;
using System.Net;
using System.Windows;
using System.Windows.Controls;

namespace GymFlash
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            DataContext = new LoginWindowModel();
        }

        private void Volver_Button(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Signup_Button(object sender, RoutedEventArgs e)
        {
            SignupWindow signupWindow = new SignupWindow();
            signupWindow.Show();
            this.Close();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is LoginWindowModel vm)
            {
                vm.Contrasena = ((PasswordBox)sender).Password;
            }
        }

        private void Iniciar_Sesion(object sender, RoutedEventArgs e)
        {
            if (DataContext is LoginWindowModel vm)
            {
                // Validación de campos vacíos
                if (string.IsNullOrWhiteSpace(vm.Usuario))
                {
                    MessageBox.Show("Por favor ingrese su nombre de usuario.", "Campo requerido", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(vm.Contrasena))
                {
                    MessageBox.Show("Por favor ingrese su contraseña.", "Campo requerido", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Validación de longitud mínima de contraseña
                if (vm.Contrasena.Length < 6)
                {
                    MessageBox.Show("La contraseña debe tener al menos 6 caracteres.", "Contraseña inválida", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                try
                {
                    var credenciales = new NetworkCredential(vm.Usuario, vm.Contrasena);
                    UserRepository userRepository = new UserRepository();

                    bool usuarioValido = userRepository.AuthenticateUser(credenciales);
                    if (usuarioValido)
                    {
                        UserModel usuario = userRepository.GetByUsername(vm.Usuario);

                        // Validación adicional por si el usuario existe pero tiene datos inconsistentes
                        if (usuario == null)
                        {
                            MessageBox.Show("Error al cargar los datos del usuario. Por favor contacte al administrador.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }

                        // Verificar el tipo de usuario
                        if (usuario.ID_TipoUsuario == 1) // Administrador
                        {
                            PantallaAdmin adminWindow = new PantallaAdmin(usuario);
                            adminWindow.Show();
                        }
                        else // Usuario normal
                        {
                            HomeWindow home = new HomeWindow(usuario);
                            home.Show();
                        }

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Usuario o contraseña incorrectos.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show($"Ocurrió un error al intentar iniciar sesión: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}