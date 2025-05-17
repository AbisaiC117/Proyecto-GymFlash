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
using System.Text.RegularExpressions;

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
            string nombre = NombreTextBox.Text.Trim();
            string apellido = ApellidoTextBox.Text.Trim();
            string email = EmailTextBox.Text.Trim();
            string username = UsernameTextBox.Text.Trim();
            string edad = EdadTextBox.Text.Trim();
            string peso = PesoTextBox.Text.Trim();
            string altura = AlturaTextBox.Text.Trim();
            string password = PasswordBox.Password;
            string confirmarPassword = ConfirmarPasswordBox.Password;

            // Validación de campos vacíos
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

            // Validación de formato de email
            if (!IsValidEmail(email))
            {
                MessageBox.Show("Por favor, ingresa un email válido.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Validación de nombre y apellido (solo letras)
            if (!IsValidName(nombre) || !IsValidName(apellido))
            {
                MessageBox.Show("Nombre y apellido solo deben contener letras.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Validación de contraseñas coincidentes
            if (password != confirmarPassword)
            {
                MessageBox.Show("Las contraseñas no coinciden.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Validación de fortaleza de contraseña
            if (password.Length < 8)
            {
                MessageBox.Show("La contraseña debe tener al menos 8 caracteres.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Validación de edad
            int edadVal;
            if (!int.TryParse(edad, out edadVal) || edadVal < 12 || edadVal > 120)
            {
                MessageBox.Show("Por favor, ingresa una edad válida (entre 12 y 120 años).", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Calcular el IMC (Índice de Masa Corporal)
            double pesoVal, alturaVal, imcVal;
            if (!double.TryParse(peso, out pesoVal) || pesoVal <= 0 || pesoVal > 300)
            {
                MessageBox.Show("Por favor, ingresa un peso válido (entre 0 y 300 kg).", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!double.TryParse(altura, out alturaVal) || alturaVal <= 0 || alturaVal > 3)
            {
                MessageBox.Show("Por favor, ingresa una altura válida (en metros, entre 0 y 3 m).", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
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

            try
            {
                IUserRepository userRepository = new UserRepository();
                userRepository.Add(userModel);

                MessageBox.Show("Cuenta creada exitosamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
               //para que abra la ventana de login despues de crear la cuneta 
                LoginWindow loginWindow = new LoginWindow();
                loginWindow.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear la cuenta: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private bool IsValidName(string name)
        {
            return !string.IsNullOrWhiteSpace(name) && name.All(c => char.IsLetter(c) || char.IsWhiteSpace(c));
        }

        private void Login_Button(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }
    }
}