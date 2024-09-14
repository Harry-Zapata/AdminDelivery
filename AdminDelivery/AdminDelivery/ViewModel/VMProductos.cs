using AdminDelivery.Datos;
using AdminDelivery.Modelo;
using AdminDelivery.Vistas;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AdminDelivery.ViewModel
{
    public class VMProductos : BaseViewModel
    {
        #region Variables
        string nombreProducto;
        int stock;
        DateTime fechaVencimiento;
        DateTime fechaRegistro;
        decimal precioCompra;
        decimal precioVenta;
        string urlFoto;
        #endregion

        #region Objetos
        public string TxtNombreProducto
        {
            get { return nombreProducto; }
            set { SetValue(ref nombreProducto, value); }
        }

        public int TxtStock
        {
            get { return stock; }
            set { SetValue(ref stock, value); }
        }

        public DateTime TxtFechaVencimiento
        {
            get { return fechaVencimiento; }
            set { SetValue(ref fechaVencimiento, value); }
        }

        public DateTime TxtFechaRegistro
        {
            get { return fechaRegistro; }
            set { SetValue(ref fechaRegistro, value); }
        }

        public decimal TxtPrecioCompra
        {
            get { return precioCompra; }
            set { SetValue(ref precioCompra, value); }
        }

        public decimal TxtPrecioVenta
        {
            get { return precioVenta; }
            set { SetValue(ref precioVenta, value); }
        }

        public string TxtUrlFoto
        {
            get { return urlFoto; }
            set { SetValue(ref urlFoto, value); }
        }
        #endregion

        #region Procesos
        private async Task InsertarProducto()
        {
            // Validar que todos los campos estén llenos
            if (string.IsNullOrWhiteSpace(TxtNombreProducto) ||
                string.IsNullOrWhiteSpace(TxtStock.ToString()) ||
                string.IsNullOrWhiteSpace(TxtFechaVencimiento.ToString()) ||
                string.IsNullOrWhiteSpace(TxtFechaRegistro.ToString()) ||
                string.IsNullOrWhiteSpace(TxtPrecioCompra.ToString()) ||
                string.IsNullOrWhiteSpace(TxtPrecioVenta.ToString()) ||
                string.IsNullOrWhiteSpace(TxtUrlFoto))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Debe llenar todos los campos.", "OK");
                return;
            }

            // Crear una instancia del servicio (Dproductos) que gestiona los productos
            var funcion = new DProducto();
            var producto = new MProductos
            {
                Nombre = TxtNombreProducto,
                Stock = TxtStock.ToString(),
                FechaVencimiento = TxtFechaVencimiento.ToString("dd/MM/yyyy HH:mm:ss"),
                FechaRegistro = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow,TimeZoneInfo.FindSystemTimeZoneById("EST")).ToString("dd/MM/yyyy HH:mm:ss"),
                PrecioCompra = TxtPrecioCompra.ToString(),
                PrecioVenta = TxtPrecioVenta.ToString(),
                Foto = TxtUrlFoto
            };

            // Intentar insertar el producto
            var estadoFuncion = await funcion.InsertarProductos(producto);
            if (!estadoFuncion)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Error al ingresar Producto.", "OK");
                return;
            }

            // Mostrar mensaje de éxito
            await Application.Current.MainPage.DisplayAlert("Registro", "Se registró el producto correctamente", "OK");

            // Limpiar los campos del formulario
            TxtNombreProducto = string.Empty;
            TxtStock = 0;
            TxtPrecioCompra = 0;
            TxtPrecioVenta = 0;
            TxtUrlFoto = string.Empty;

            // Navegar a la página de productos
            await Navigation.PushAsync(new VInicio());
        }
        #endregion

        #region Constructos
        public VMProductos(INavigation navigation)
        {
            navigation = navigation ?? throw new ArgumentNullException(nameof(navigation));
            ComandoInsertarProducto = new Command(async () => await InsertarProducto());
        }
        #endregion
        #region Comando
        public Command ComandoInsertarProducto { get; }
        #endregion

    }
}
