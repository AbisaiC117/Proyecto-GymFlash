using System.Diagnostics;
using System.Windows;

namespace GymFlash.View
{
    public partial class CompartirPerfil : Window
    {
        public CompartirPerfil()
        {
            InitializeComponent();
        }

        private void Cerrar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void CompartirWhatsApp_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://api.whatsapp.com/send?text=¡Hola! Mira mi perfil en GYM Flash.") { UseShellExecute = true });
        }

        private void CompartirMessenger_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://www.messenger.com/t") { UseShellExecute = true });
        }

        private void CompartirGmail_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("mailto:?subject=Mi perfil en GYM Flash&body=¡Hola! Mira mi perfil en GYM Flash.") { UseShellExecute = true });
        }
    }
}
