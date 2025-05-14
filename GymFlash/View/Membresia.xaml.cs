using GymFlash.Model;
using System.Windows;
using GymFlash.Repositories;

namespace GymFlash.View
{
    public partial class Membresia : Window
    {
        private UserModel usuario;

        public Membresia(UserModel usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
        }

        private void Button_Inicio(object sender, RoutedEventArgs e)
        {
            HomeWindow ventanaInicio = new HomeWindow(usuario);
            ventanaInicio.Show();
            this.Close();
        }

        private void Button_Membresia(object sender, RoutedEventArgs e)
        {
            // Ya estás en Membresía. Puedes mostrar mensaje o ignorar.
        }

        private void Button_Rutinas(object sender, RoutedEventArgs e)
        {
            RutinasWindow ventanaRutinas = new RutinasWindow(usuario);
            ventanaRutinas.Show();
            this.Close();
        }

        private void Button_Perfil(object sender, RoutedEventArgs e)
        {
            PerfilUsuario ventanaPerfil = new PerfilUsuario(usuario);
            ventanaPerfil.Show();
            this.Close();
        }
        private void Button_Tienda(object sender, RoutedEventArgs e)
        {
            // Puedes agregar ventana de tienda aquí si existe.
        }

        private void Button_MembresiaBasica(object sender, RoutedEventArgs e)
        {
            MembresiaComprada ventanaBasica = new MembresiaComprada();
            ventanaBasica.Show();
            
        }

        private void Button_MembresiaPremium(object sender, RoutedEventArgs e)
        {
            MembresiaComprada ventanaBasica = new MembresiaComprada();
            ventanaBasica.Show();
        }
    }
}

