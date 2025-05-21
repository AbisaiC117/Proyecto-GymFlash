using System;

namespace GymFlash.Model
{
    public class RutinaModel
    {
        public Guid ID_Rutina { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string ImagenURL { get; set; }
        public Guid ID_Entrenador { get; set; }
    }
}


