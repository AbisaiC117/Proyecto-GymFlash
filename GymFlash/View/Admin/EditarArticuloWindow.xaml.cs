using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using GymFlash.Model;
using GymFlash.Repositories;

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
            // 🔹 Validación: Asegurar que los datos sean correctos 🔹
            if (string.IsNullOrWhiteSpace(Articulo.Nombre) ||
                Articulo.Precio <= 0 ||
                Articulo.Cantidad < 0 ||
                string.IsNullOrWhiteSpace(Articulo.Imagen))
            {
                MessageBox.Show("Todos los campos son obligatorios y deben contener valores válidos.",
                                "Error de Validación", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Actualizar artículo en la base de datos
            articuloRepository.ActualizarArticulo(Articulo);
            SeRealizaronCambios = true;
            DialogResult = true;
            Close();
        }

        // 🔹 Validación: Solo permitir números en los campos de Precio y Cantidad 🔹
        private void NumericOnlyInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, "^[0-9]*$");
        }

        private void NumericOnlyPaste(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(string)))
            {
                string text = (string)e.DataObject.GetData(typeof(string));
                if (!Regex.IsMatch(text, "^[0-9]*$"))
                {
                    e.CancelCommand();
                }
            }
            else
            {
                e.CancelCommand();
            }
        }
    }
}