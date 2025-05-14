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
using GymFlash.Model;
using GymFlash.Repositories;

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

        private void Signup_Button(object sender, RoutedEventArgs e)
        {
        }

        private void Volver_Button(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Registrarse_Click(object sender, RoutedEventArgs e)
        {
            string nombre = NombreTextBox.Text;
            string apellido = ApellidoTextBox.Text;
            string email = EmailTextBox.Text;
            string username = UsernameTextBox.Text;
            string edad = EdadTextBox.Text;
            string peso = PesoTextBox.Text;
            string altura = AlturaTextBox.Text;
            string password = PasswordBox.Password;
            string confirmarPassword = ConfirmarPasswordBox.Password;

            if (string.IsNullOrWhiteSpace(nombre) ||
                string.IsNullOrWhiteSpace(apellido) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(edad) ||
                string.IsNullOrWhiteSpace(peso) ||
                string.IsNullOrWhiteSpace(altura) ||
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

            // Calcular el IMC (Índice de Masa Corporal)
            double pesoVal, alturaVal, imcVal;
            if (!double.TryParse(peso, out pesoVal) || !double.TryParse(altura, out alturaVal) || alturaVal <= 0)
            {
                MessageBox.Show("Peso o altura inválidos.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            imcVal = pesoVal / (alturaVal * alturaVal);


                var userModel = new UserModel
                {
                    Username = username,
                    Password = password, // Idealmente deberías cifrar esta contraseña
                    Name = nombre,
                    Lastname = apellido,
                    Email = email,
                    Edad = edad,
                    Peso = peso,
                    Altura = altura,
                    IMC = imcVal.ToString("F2"),
                    ID_TipoMembresia = 1 // Asignar un ID de membresía por defecto


                };

                IUserRepository userRepository = new UserRepository();
                userRepository.Add(userModel);

                MessageBox.Show("Cuenta creada exitosamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close(); // o abrir LoginWindow

        }

        private void Login_Button(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }
    }
}