using GymFlash.Model;
using System;
using System.Windows;

namespace GymFlash.View
{
    public partial class EditarPerfil : Window
    {
        private UserModel usuario;

        public EditarPerfil(UserModel usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            DataContext = usuario;
        }

        private void Guardar_Click(object sender, RoutedEventArgs e)
        {
            // Aquí podrías guardar la información, por ahora solo mostramos un mensaje.
            MessageBox.Show("Perfil actualizado correctamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }

        private void Cancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
