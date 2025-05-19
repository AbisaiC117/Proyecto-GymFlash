using System.Windows;
using GymFlash.Model;
using GymFlash.Repositories;
using GymFlash.View.PantallaAdmin;

namespace GymFlash.View
{
    public partial class EditarArticuloWindow : Window
    {
        private ArticuloRepository articuloRepository;
        public bool SeRealizaronCambios { get; private set; }

        public ArticuloModel Articulo { get; set; }

        public EditarArticuloWindow(ArticuloModel articulo)
        {
            InitializeComponent();
            articuloRepository = new ArticuloRepository();
            Articulo = articulo;
            DataContext = Articulo;
        }

        private void GuardarCambios_Button(object sender, RoutedEventArgs e)
        {
            articuloRepository.ActualizarArticulo(Articulo);
            SeRealizaronCambios = true;
            DialogResult = true;
            Close();
        }
    }
}