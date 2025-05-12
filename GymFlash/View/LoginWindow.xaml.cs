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
                var credenciales = new NetworkCredential(vm.Usuario, vm.Contrasena);
                IUserRepository userRepository = new UserRepository();

                bool usuarioValido = userRepository.AuthenticateUser(credenciales);

                if (usuarioValido)
                {
                    UserModel usuario = userRepository.GetByUsername(vm.Usuario);

                    HomeWindow home = new HomeWindow(usuario);
                    home.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
