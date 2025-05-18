using GymFlash.Model;
using GymFlash.Repositories;
using GymFlash.View;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace GymFlash.ViewModel
{
    public class ArticuloViewModel
    {
        public ObservableCollection<ArticuloModel> Articulos { get; set; }

        public ICommand ComprarCommand { get; }

        private UserModel usuario;
        private ArticuloRepository articuloRepository;

        public ArticuloViewModel(UserModel usuario)
        {
            this.usuario = usuario;
            this.articuloRepository = new ArticuloRepository();

            Articulos = new ObservableCollection<ArticuloModel>();
            CargarArticulosDesdeBaseDeDatos();

            ComprarCommand = new RelayCommand(ComprarArticulo);
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
                articuloRepository.RegistrarCompra(articulo.Id, usuario.Id,1);

                var comprobante = new ComprobanteWindow(usuario.Name, articulo.Nombre, 1, DateTime.Now);
                comprobante.ShowDialog();
            }
        }
    }
}
