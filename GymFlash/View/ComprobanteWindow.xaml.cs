using System;
using System.Windows;

namespace GymFlash.View
{
    public partial class ComprobanteWindow : Window
    {
        public string UsuarioNombre { get; set; }
        public string ArticuloNombre { get; set; }
        public int Cantidad { get; set; }
        public DateTime FechaCompra { get; set; }

        public ComprobanteWindow(string usuarioNombre, string articuloNombre, int cantidad, DateTime fechaCompra)
        {
            InitializeComponent();
            UsuarioNombre = usuarioNombre;
            ArticuloNombre = articuloNombre;
            Cantidad = cantidad;
            FechaCompra = fechaCompra;

            DataContext = this; // Enlaza los datos con la UI
        }

        private void CerrarVentana(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}