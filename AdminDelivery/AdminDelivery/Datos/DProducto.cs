using AdminDelivery.Conexion;
using AdminDelivery.Modelo;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminDelivery.Datos
{
    public class DProducto
    {
        public async Task<bool> InsertarProductos (MProductos productos)
        {
            await ConexionFirebase.ClientFirebase
                .Child("Productos")
                .PostAsync(new MProductos()
                {
                    Nombre = productos.Nombre,
                    Stock = productos.Stock,
                    FechaVencimiento = productos.FechaVencimiento,
                    FechaRegistro = productos.FechaRegistro,
                    PrecioCompra = productos.PrecioCompra,
                    PrecioVenta = productos.PrecioVenta,
                    Foto = productos.Foto
                });
            return true;
        }

        public async Task<List<MProductos>> ListarProductos()
        {
            return (await ConexionFirebase.ClientFirebase
                .Child("Productos")
                .OnceAsync<MProductos>()).Select(item => new MProductos
                {
                    Nombre = item.Object.Nombre,
                    Stock = item.Object.Stock,
                    FechaVencimiento = item.Object.FechaVencimiento,
                    FechaRegistro = item.Object.FechaRegistro,
                    PrecioCompra = item.Object.PrecioCompra,
                    PrecioVenta = item.Object.PrecioVenta,
                    Foto = item.Object.Foto
                }).ToList();
        }
    }
}
