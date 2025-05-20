using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using GymFlash.Model;
using GymFlash.Repositories;
using GymFlash.View;

namespace GymFlash
{
    public partial class RutinasWindow : Window
    {
        private UserModel usuario;
        private RutinaRepository rutinaRepo;

        public List<RutinaModel> Rutina { get; set; }

        public RutinasWindow(UserModel usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            this.rutinaRepo = new RutinaRepository();
            CargarRutinas();
            DataContext = this;
        }

        private void CargarRutinas()
        {
            Rutina = rutinaRepo.GetAllRutinas();
        }

        private void Inicio_Click(object sender, RoutedEventArgs e)
        {
            new HomeWindow(usuario).Show();
            this.Close();
        }

        private void Membresias_Click(object sender, RoutedEventArgs e)
        {
            new Membresia(usuario).Show();
            this.Close();
        }

        private void Rutinas_Click(object sender, RoutedEventArgs e) { }

        private void Perfil_Click(object sender, RoutedEventArgs e)
        {
            new PerfilUsuario(usuario).Show();
            this.Close();
        }

        private void Tienda_Click(object sender, RoutedEventArgs e)
        {
            new TiendaWindow(usuario).Show();
            this.Close();
        }

        public RelayCommand GenerarTXTCommand => new RelayCommand((obj) =>
        {
            if (obj is RutinaModel rutina)
            {
                var entrenador = rutinaRepo.GetEntrenadorInfo(rutina.IdEntrenador);

                string nombreArchivo = $"Rutina_{rutina.Nombre.Replace(" ", "_")}_{DateTime.Now:yyyyMMdd_HHmmss}.txt";
                string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), nombreArchivo);

                using (StreamWriter writer = new StreamWriter(path))
                {
                    writer.WriteLine("GYMFLASH - RUTINA PERSONALIZADA");
                    writer.WriteLine("--------------------------------------");
                    writer.WriteLine($"Nombre de la Rutina: {rutina.Nombre}");
                    writer.WriteLine($"Descripción: {rutina.Descripcion}");
                    writer.WriteLine();
                    writer.WriteLine("Entrenador Asignado:");
                    writer.WriteLine($"Nombre: {entrenador.nombreEntrenador}");
                    writer.WriteLine($"Especialidad: {entrenador.especialidad}");
                    writer.WriteLine($"Años de Experiencia: {entrenador.aniosExperiencia}");
                    writer.WriteLine();
                    writer.WriteLine($"Fecha de Generación: {DateTime.Now:dd/MM/yyyy HH:mm}");
                }

                MessageBox.Show("Archivo generado correctamente:\n" + path, "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        });
    }
}
