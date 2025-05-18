using GymFlash.Model;
using System.Windows;
using GymFlash.Repositories;
using System;

namespace GymFlash.View
{
    public partial class Membresia : Window
    {
        private UserModel usuario;

        public Membresia(UserModel usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
        }

        private void Button_Inicio(object sender, RoutedEventArgs e)
        {
            HomeWindow ventanaInicio = new HomeWindow(usuario);
            ventanaInicio.Show();
            this.Close();
        }

        private void Button_Membresia(object sender, RoutedEventArgs e)
        {
            // Ya estás en Membresía. Puedes mostrar mensaje o ignorar.
        }

        private void Button_Rutinas(object sender, RoutedEventArgs e)
        {
            RutinasWindow ventanaRutinas = new RutinasWindow(usuario);
            ventanaRutinas.Show();
            this.Close();
        }

        private void Button_Perfil(object sender, RoutedEventArgs e)
        {
            PerfilUsuario ventanaPerfil = new PerfilUsuario(usuario);
            ventanaPerfil.Show();
            this.Close();
        }
        private void Button_Tienda(object sender, RoutedEventArgs e)
        {
            TiendaWindow tiendaWindow = new TiendaWindow(usuario); 
            tiendaWindow.Show();
            this.Close();
        }

        private void Button_MembresiaBasica(object sender, RoutedEventArgs e)
        {
            // Mensaje de confirmación
            MessageBoxResult result = MessageBox.Show(
                "¿Estás seguro de comprar la Membresía Básica por $250.00?",
                "Confirmar Compra",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    var userRepository = new UserRepository();

                    // Verificar si ya tiene una membresía igual o superior
                    if (usuario.ID_TipoMembresia >= 2)
                    {
                        MessageBox.Show("Ya tienes una membresía igual o superior activa.",
                                      "Advertencia",
                                      MessageBoxButton.OK,
                                      MessageBoxImage.Warning);
                        return;
                    }

                    // Actualizar en base de datos
                    userRepository.UpdateMembership(usuario.Id, 2);

                    // Actualizar localmente
                    usuario.ID_TipoMembresia = 2;

                    // Abrir ventana de compra realizada
                    MembresiaComprada ventana = new MembresiaComprada();
                    ventana.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al actualizar membresía: {ex.Message}",
                                   "Error",
                                   MessageBoxButton.OK,
                                   MessageBoxImage.Error);
                }
            }
        }

        private void Button_MembresiaPremium(object sender, RoutedEventArgs e)
        {
            // Mensaje de confirmación con precio
            MessageBoxResult result = MessageBox.Show(
                "¿Estás seguro de comprar la Membresía Premium por $700.00?",
                "Confirmar Compra",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    var userRepository = new UserRepository();

                    // Verificar si ya tiene Premium
                    if (usuario.ID_TipoMembresia == 3)
                    {
                        MessageBox.Show("Ya tienes la Membresía Premium activa.",
                                       "Advertencia",
                                       MessageBoxButton.OK,
                                       MessageBoxImage.Information);
                        return;
                    }

                    // Actualizar en base de datos
                    userRepository.UpdateMembership(usuario.Id, 3);

                    // Actualizar localmente
                    usuario.ID_TipoMembresia = 3;

                    // Abrir ventana de compra realizada
                    MembresiaComprada ventana = new MembresiaComprada();
                    ventana.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al actualizar membresía: {ex.Message}",
                                  "Error",
                                  MessageBoxButton.OK,
                                  MessageBoxImage.Error);
                }
            }
        }
    }
}

