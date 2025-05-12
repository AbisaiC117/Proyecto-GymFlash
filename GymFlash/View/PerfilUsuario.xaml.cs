using System.Windows;

namespace GymFlash.View
{
    public partial class PerfilUsuario : Window
    {
        private Usuario usuario;
        public PerfilUsuario()
        {   
            
            InitializeComponent();
            usuario = new Usuario
            {
                Nombre = "Abisai",
                Paterno = "Cordova",
                Materno = "Devora",
                Edad = 19,
                Peso = 98.7,
                Altura = 1.75,
                IMC = "38%"
            };
            DataContext = usuario;


        }

        private void EditarPerfil_Click(object sender, RoutedEventArgs e)
        {
            EditarPerfil ventanaEditar = new EditarPerfil();
            ventanaEditar.ShowDialog();
        }
        private void CompartirPerfil_Click(object sender, RoutedEventArgs e)
        {
            CompartirPerfil ventanaCompartir = new CompartirPerfil();
            ventanaCompartir.ShowDialog();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
