using System;
using System.Collections.ObjectModel;
using System.Windows;
using GymFlash.Model;
using GymFlash.Repositories;
using GymFlash.View.PantallaAdmin;

namespace GymFlash.View
{
    public partial class RutinasAdminWindow : Window
    {
        private RutinaRepository rutinaRepo = new RutinaRepository();
        public ObservableCollection<RutinaModel> Rutinas { get; set; } = new ObservableCollection<RutinaModel>();

        private RutinaModel _rutinaSeleccionada;
        public RutinaModel RutinaSeleccionada
        {
            get => _rutinaSeleccionada;
            set
            {
                if (_rutinaSeleccionada != value)
                {
                    _rutinaSeleccionada = value;
                    if (lvRutinas != null)
                        lvRutinas.SelectedItem = value;
                }
            }
        }
        public RutinasAdminWindow()
        {
            InitializeComponent();
            DataContext = this;
            CargarRutinas();
        }

        private void CargarRutinas()
        {
            try
            {
                Rutinas.Clear();
                var lista = rutinaRepo.GetAllRutinas();
                foreach (var r in lista)
                    Rutinas.Add(r);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar rutinas: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AgregarRutina_Click(object sender, RoutedEventArgs e)
        {
            var ventanaAgregar = new AgregarRutinaWindow();
            bool? resultado = ventanaAgregar.ShowDialog();

            if (resultado == true)
                CargarRutinas(); // Recargar lista si se agregó
        }
        private void Volver_Button(object sender, RoutedEventArgs e)
        {

            UserModel currentUser = ObtenerUsuarioActual();
            AdminPanelWindow adminPanelWindow = new AdminPanelWindow(currentUser);
            adminPanelWindow.Show();
            this.Close();
        }


        private UserModel ObtenerUsuarioActual()
        {
            return new UserModel();
        }
        private void EliminarRutina_Click(object sender, RoutedEventArgs e)
        {
            if (RutinaSeleccionada == null)
            {
                MessageBox.Show("Selecciona una rutina para eliminar.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var confirm = MessageBox.Show("¿Estás seguro de eliminar esta rutina?", "Confirmar", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (confirm == MessageBoxResult.Yes)
            {
                try
                {
                    rutinaRepo.EliminarRutina(RutinaSeleccionada.ID_Rutina);
                    CargarRutinas();
                    MessageBox.Show("Rutina eliminada correctamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar rutina: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}

