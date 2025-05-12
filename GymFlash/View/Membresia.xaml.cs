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
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }
    }
}
