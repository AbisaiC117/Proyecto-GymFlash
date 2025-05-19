using GymFlash.Model;
using GymFlash.Repositories;
using System;
using System.Windows;

namespace GymFlash.View.Admin
{
    public partial class AddEditAdminWindow : Window
    {
        private readonly UserRepository _userRepository;
        public UserModel CurrentAdmin { get; set; }
        public string WindowTitle { get; set; }

        public AddEditAdminWindow(UserModel existingAdmin = null)
        {
            InitializeComponent();
            _userRepository = new UserRepository();

            CurrentAdmin = existingAdmin ?? new UserModel
            {
                // Valores por defecto explícitos
                ID_TipoMembresia = 1,  // Membresía por defecto
                ID_TipoUsuario = 1     // Rol de administrador
            };

            WindowTitle = existingAdmin != null ? "Editar Administrador" : "Nuevo Administrador";

            DataContext = this;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateFields()) return;

            // Manejar la contraseña
            if (!string.IsNullOrEmpty(txtPassword.Password))
            {
                CurrentAdmin.Password = txtPassword.Password;
            }

            try
            {
                bool result;
                if (CurrentAdmin.Id == null)
                {
                    // Nuevo administrador
                    CurrentAdmin.ID_TipoUsuario = 1; // Rol de administrador
                    _userRepository.Add(CurrentAdmin);
                    result = true;
                }
                else
                {
                    // Editar existente
                    result = _userRepository.ActualizarUsuario(CurrentAdmin);
                }

                if (result)
                {
                    DialogResult = true;
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}", "Error",
                              MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool ValidateFields()
        {
            if (string.IsNullOrWhiteSpace(CurrentAdmin.Username))
            {
                MessageBox.Show("El nombre de usuario es obligatorio", "Validación",
                              MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (CurrentAdmin.Id == null && string.IsNullOrEmpty(txtPassword.Password))
            {
                MessageBox.Show("La contraseña es obligatoria para nuevos usuarios", "Validación",
                              MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(CurrentAdmin.Name))
            {
                MessageBox.Show("El nombre es obligatorio", "Validación",
                              MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(CurrentAdmin.Email))
            {
                MessageBox.Show("El email es obligatorio", "Validación",
                              MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            return true;
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}