using System.Collections.ObjectModel;
using GymFlash.Model;

namespace GymFlash.ViewModel
{
    public class MainViewModel
    {
        public ObservableCollection<Entrenador> Entrenadores { get; set; }
        public ObservableCollection<Resenia> Reseñas { get; set; }

        public MainViewModel()
        {
            Entrenadores = new ObservableCollection<Entrenador>
            {
                new Entrenador { Nombre = "Anastase Margos", Descripcion = "Zona Mx. Olympian", Imagen = "Imagenes/entrenador1.jpg" },
                new Entrenador { Nombre = "Karla Souza", Descripcion = "Fitness League México 2014", Imagen = "Imagenes/entrenador2.jpg" },
                new Entrenador { Nombre = "Hayley Kim", Descripcion = "Base de Fuerza Internacional", Imagen = "Imagenes/entrenador3.jpg" }
            };

            Reseñas = new ObservableCollection<Resenia>
            {
                new Resenia { Comentario = "¡Todas las máquinas están en excelente estado!", Autor = "Flavio Uriel", Estrellas = 5 },
                new Resenia { Comentario = "Me encanta la música y el espacio", Autor = "Emiliano DSM", Estrellas = 5 },
                new Resenia { Comentario = "Excelente servicio, muy completo", Autor = "Abisai Cordova", Estrellas = 5 }
            };
        }
    }
}
