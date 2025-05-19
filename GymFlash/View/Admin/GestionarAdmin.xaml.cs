using GymFlash.Model;
using GymFlash.Repositories;
using System.Collections.Generic;
using System.Windows;
using System.Linq;
using System.Windows.Controls;
using System;

namespace GymFlash.View.Admin
{
    public partial class GestionarAdmin : Window
    {
        private readonly UserRepository _userRepository;
        private List<UserModel> _admins;

        public GestionarAdmin()
        {
            InitializeComponent();
            _userRepository = new UserRepository();
            LoadAdmins();
        }

        private void LoadAdmins()
        {
            // Obtener solo usuarios con rol de administrador (ID_TipoUsuario = 1)
            _admins = _userRepository.GetAllUsers()
                .Where(u => u.ID_TipoUsuario == 1)
                .ToList();

            dgAdmins.ItemsSource = _admins;
        }

        private void BtnAddAdmin_Click(object sender, RoutedEventArgs e)
        {
            var addAdminWindow = new AddEditAdminWindow();
            if (addAdminWindow.ShowDialog() == true)
            {
                LoadAdmins(); // Recargar la lista después de añadir
            }
        }

        private void BtnEditAdmin_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var userId = button?.Tag?.ToString();

            if (!string.IsNullOrEmpty(userId))
            {
                var adminToEdit = _admins.FirstOrDefault(a => a.Id == userId);
                if (adminToEdit != null)
                {
                    var editWindow = new AddEditAdminWindow(adminToEdit);
                    if (editWindow.ShowDialog() == true)
                    {
                        LoadAdmins(); // Recargar después de editar
                    }
                }
            }
        }

        private void BtnDeleteAdmin_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var userId = button?.Tag?.ToString();

            if (!string.IsNullOrEmpty(userId))
            {
                var result = MessageBox.Show("¿Está seguro de eliminar este administrador?",
                    "Confirmar eliminación",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    if (_userRepository.DeleteAdmin(Guid.Parse(userId)))
                    {
                        MessageBox.Show("Administrador eliminado correctamente");
                        LoadAdmins();
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar el administrador");
                    }
                }
            }
        }

        private void BtnRefresh_Click(object sender, RoutedEventArgs e)
        {
            LoadAdmins();
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}