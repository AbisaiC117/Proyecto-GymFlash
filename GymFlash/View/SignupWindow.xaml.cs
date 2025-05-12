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
using System.Windows.Shapes;

namespace GymFlash.View
{
    /// <summary>
    /// Lógica de interacción para SignupWindow.xaml
    /// </summary>
    public partial class SignupWindow : Window
    {
        public SignupWindow()
        {
            InitializeComponent();
        }

        private void Registrarse_Click(object sender, RoutedEventArgs e)
        {
            string nombre = NombreTextBox.Text;
            string email = EmailTextBox.Text;
            string password = PasswordBox.Password;
            string confirmarPassword = ConfirmarPasswordBox.Password;

            if (string.IsNullOrWhiteSpace(nombre) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(confirmarPassword))
            {
                MessageBox.Show("Por favor, completa todos los campos.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (password != confirmarPassword)
            {
                MessageBox.Show("Las contraseñas no coinciden.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Aquí podrías agregar lógica para guardar el usuario en la base de datos
            MessageBox.Show("Cuenta creada exitosamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close(); // o redirigir a otra ventana
        }
    }
}