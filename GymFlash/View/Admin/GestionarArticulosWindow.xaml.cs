using GymFlash.Model;
using GymFlash.Repositories;
using GymFlash.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace GymFlash.View.PantallaAdmin
{
    public partial class GestionarArticulosWindow : Window
    {
        private ArticuloViewModel viewModel;

        public GestionarArticulosWindow(UserModel usuario)
        {
            InitializeComponent();
            viewModel = new ArticuloViewModel(usuario); // Mantener referencia al ViewModel
            this.DataContext = viewModel; // Asignar el DataContext al ViewModel
        }

        private void Volver_Button(object sender, RoutedEventArgs e)
        {
            // Acción para volver a la pantalla anterior
        }

        private void EditarArticulo(object sender, RoutedEventArgs e)
        {
            if (sender is Button boton && boton.DataContext is ArticuloModel articulo)
            {
                var ventanaEditar = new EditarArticuloWindow(articulo);
                bool? resultado = ventanaEditar.ShowDialog(); // Se asegura de abrir la ventana emergente

                if (resultado == true)
                {
                    ArticuloRepository repository = new ArticuloRepository();
                    repository.ActualizarArticulo(articulo);  
                    viewModel.recargarArticulos(); // Recargar la lista de artículos
                }
            }
        }
    }
}