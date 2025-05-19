using GymFlash.Model;
using GymFlash.Repositories;
using System;
using System.Windows;

namespace GymFlash.View
{
    public partial class EditarPerfil : Window
    {
        private readonly UserModel _usuario;

        public EditarPerfil(UserModel usuario)
        {
            InitializeComponent();

            _usuario = usuario;
            DataContext = _usuario; // Enlaza los datos del usuario a la vista
        }

        private void Guardar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Validar y convertir valores
                if (float.TryParse(_usuario.Altura, out float altura) && altura > 0 &&
                    float.TryParse(_usuario.Peso, out float peso))
                {
                    // Calcular IMC con formato controlado
                    float imcCalculado = peso / (altura * altura);
                    _usuario.IMC = imcCalculado.ToString("0.00"); // Formato con 2 decimales
                }
                else
                {
                    MessageBox.Show("Altura y peso deben ser valores numéricos positivos");
                    return;
                }

                // Crear repositorio (sin argumentos)
                var userRepository = new UserRepository();
                bool actualizado = userRepository.ActualizarUsuario(_usuario);

                if (actualizado)
                {
                    MessageBox.Show("Perfil actualizado correctamente.", "Éxito",
                                  MessageBoxButton.OK, MessageBoxImage.Information);
                    this.DialogResult = true;
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar el perfil.", "Error",
                                  MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}", "Error",
                              MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                this.Close();
            }
        }

        private void Cancelar_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
