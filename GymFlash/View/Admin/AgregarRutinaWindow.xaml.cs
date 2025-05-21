using System;
using System.Windows;
using GymFlash.Model;
using GymFlash.Repositories;

namespace GymFlash.View.PantallaAdmin
{
    public partial class AgregarRutinaWindow : Window
    {
        private readonly RutinaRepository rutinaRepo = new RutinaRepository();

        public AgregarRutinaWindow()
        {
            InitializeComponent();
        }

        private void AgregarRutina_Click(object sender, RoutedEventArgs e)
        {
            // Validaciones
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtDescripcion.Text) ||
                string.IsNullOrWhiteSpace(txtIdEntrenador.Text))
            {
                MessageBox.Show("Por favor completa todos los campos obligatorios.", "Campos vacíos", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!Guid.TryParse(txtIdEntrenador.Text, out Guid idEntrenador))
            {
                MessageBox.Show("El ID del entrenador no tiene un formato válido.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var nuevaRutina = new RutinaModel
            {
                ID_Rutina = Guid.NewGuid(),
                Nombre = txtNombre.Text,
                Descripcion = txtDescripcion.Text,
                ID_Entrenador = idEntrenador,
                ImagenURL = string.IsNullOrWhiteSpace(txtImagenURL.Text) ? null : txtImagenURL.Text
            };

            try
            {
                rutinaRepo.AgregarRutina(nuevaRutina);
                MessageBox.Show("Rutina agregada exitosamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                this.DialogResult = true;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar rutina: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

