using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GymFlash.View
{
    /// <summary>
    /// Lógica de interacción para Membresia.xaml
    /// </summary>
    public partial class Membresia : Window
    {
        public Membresia()
        {
            InitializeComponent();
        }

        private void Button_Inicio(object sender, RoutedEventArgs e)
        {
            HomeWindow HomeWindow = new HomeWindow();
            HomeWindow.Show();
            this.Close();
        }

        private void Button_Membresia(object sender, RoutedEventArgs e)
        {
            HomeWindow HomeWindow = new HomeWindow();
            HomeWindow.Show();
            this.Close();
        }

        private void Button_Rutinas(object sender, RoutedEventArgs e)
        {
            RutinasWindow ventanaRutinas = new RutinasWindow();
            ventanaRutinas.Show();
            this.Close();
        }
        private void Button_Perfil(object sender, RoutedEventArgs e)
        {
            PerfilUsuario ventanaPerfil = new PerfilUsuario();
            ventanaPerfil.Show();
            this.Close();
        }

        private void Button_Tienda(object sender, RoutedEventArgs e)
        {

        }
    }
}
