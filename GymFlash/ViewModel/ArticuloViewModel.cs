using GymFlash.Model;
using GymFlash.Repositories;
using GymFlash.View;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace GymFlash.ViewModel
{
    public class ArticuloViewModel
    {
        public ObservableCollection<ArticuloModel> Articulos { get; set; }

        public ICommand ComprarCommand { get; }
        public ICommand ActualizarCommand { get; }
        public ICommand EliminarCommand { get; }
        public ICommand AddArticuloCommand { get; }

        private UserModel usuario;
        private ArticuloRepository articuloRepository;

        public ArticuloViewModel(UserModel usuario)
        {
            this.usuario = usuario;
            this.articuloRepository = new ArticuloRepository();

            Articulos = new ObservableCollection<ArticuloModel>();
            CargarArticulosDesdeBaseDeDatos();

            ComprarCommand = new RelayCommand(ComprarArticulo);
            ActualizarCommand = new RelayCommand(ActualizarArticulo);
            EliminarCommand = new RelayCommand(EliminarArticulo);
            AddArticuloCommand = new RelayCommand(AgregarArticulo);
        }

        private void CargarArticulosDesdeBaseDeDatos()
        {
            var articulosDesdeBD = articuloRepository.ObtenerArticulos();

            foreach (var articulo in articulosDesdeBD)
            {
                Articulos.Add(articulo);
            }
        }

        private void ComprarArticulo(object parametro)
        {
            if (parametro is ArticuloModel articulo && articulo.Cantidad > 0)
            {
                articulo.Cantidad--;
                articuloRepository.ActualizarCantidad(articulo.Id, 1);
                articuloRepository.RegistrarCompra(articulo.Id, usuario.Id, 1);

                var comprobante = new ComprobanteWindow(usuario.Name, articulo.Nombre, 1, DateTime.Now);
                comprobante.ShowDialog();
            }
        }

        private void ActualizarArticulo(object parametro)
        {
            if (parametro is ArticuloModel articulo)
            {
                // Actualiza el artículo en la base de datos
                articuloRepository.ActualizarArticulo(articulo);

                // Buscar el artículo en la lista actual
                var existente = Articulos.FirstOrDefault(a => a.Id == articulo.Id);
                if (existente != null)
                {
                    // Actualiza los atributos en la colección
                    existente.Nombre = articulo.Nombre;
                    existente.Precio = articulo.Precio;
                    existente.Cantidad = articulo.Cantidad;
                    existente.Imagen = articulo.Imagen;

                    CargarArticulosDesdeBaseDeDatos(); // Recargar la lista de artículos
                }
            }
        }

        public void recargarArticulos()
        {
            Articulos.Clear();
            CargarArticulosDesdeBaseDeDatos();
        }

        private void EliminarArticulo(object parametro)
        {
            if (parametro is ArticuloModel articulo)
            {
                articuloRepository.EliminarArticulo(articulo.Id);
                Articulos.Remove(articulo);
            }
        }

        private void AgregarArticulo(object parametro)
        {
            var nuevoArticulo = new ArticuloModel();
            var ventanaAgregar = new EditarArticuloWindow(nuevoArticulo);

            if (ventanaAgregar.ShowDialog() == true)
            {
                articuloRepository.CrearArticulo(nuevoArticulo);
                Articulos.Add(nuevoArticulo);
            }
        }

    }
}
