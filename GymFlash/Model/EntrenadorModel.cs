using System;

namespace GymFlash.Model
{
    public class EntrenadorModel
    {
        public Guid ID_Entrenador { get; set; }
        public string nombreEntrenador { get; set; }
        public string especialidad { get; set; }
        public int aniosExperiencia { get; set; }
    }
}

