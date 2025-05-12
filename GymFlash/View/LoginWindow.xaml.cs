using GymFlash.View;
using GymFlash.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace GymFlash
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            DataContext = new LoginViewModel();
        }

        private void Entrar_Click(object sender, RoutedEventArgs e)
        {
            string usuario = txtUsuario.Text;
            string contraseña = txtContraseña.Password;

            if (usuario == "admin" && contraseña == "1234")
            {
                var ventana = new View.HomeWindow(); // Asegúrate de tener el using correcto o namespace completo
                ventana.Show();
                this.Close(); // Cierra ventana actual si quieres
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
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
    }
}
