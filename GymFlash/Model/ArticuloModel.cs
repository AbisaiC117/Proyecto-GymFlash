using System.ComponentModel;

namespace GymFlash.Model
{
    public class ArticuloModel : INotifyPropertyChanged
    {
        private int cantidad;

        public int Id { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public string Imagen { get; set; } // Ruta relativa o absoluta

        public int Cantidad
        {
            get { return cantidad; }
            set
            {
                if (cantidad != value)
                {
                    cantidad = value;
                    OnPropertyChanged(nameof(Cantidad));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}