using GymFlash.View;
using System.Windows;

namespace GymFlash
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close(); // Cierra la ventana actual si es necesario
        }

        private void Signup_Click(object sender, RoutedEventArgs e)
        {
            SignupWindow signupWindow = new SignupWindow();
            signupWindow.Show();
            this.Close(); // Cierra la ventana actual si es necesario
        }
    }
}