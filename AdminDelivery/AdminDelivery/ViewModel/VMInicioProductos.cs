using AdminDelivery.Datos;
using AdminDelivery.Modelo;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AdminDelivery.ViewModel
{
    public class VMInicioProductos : BaseViewModel
    {
        #region Variables
        public List<MProductos> lcproductos;
        public string cantidadProductos;
        #endregion

        #region Objetos
        public List<MProductos> ListaProductos
        {
            get { return lcproductos; }
            set { SetValue(ref lcproductos, value); }
        }
        public string TxtCantidadProducto
        {
            get { return cantidadProductos; }
            set { SetValue(ref cantidadProductos, value); }
        }
        #endregion

        #region Procesos
        public async void ObtenerDatosProductos()
        {
            var funcion = new DProducto();
            lcproductos = await funcion.ListarProductos();

            // Llamar al método para contar los productos después de obtenerlos
            ContarProductos();
        }

        public void ContarProductos()
        {
            if (lcproductos != null)
            {
                // Contar los productos y asignar el valor a TxtCantidadProducto
                TxtCantidadProducto = lcproductos.Count.ToString();
            }
            else
            {
                TxtCantidadProducto = "0";
            }
        }
        #endregion


        #region Comandos
        #endregion

        #region Constructor
        public VMInicioProductos(INavigation navigation)
        {
            Navigation = navigation;
            ObtenerDatosProductos();
        }
        #endregion
    }
}
