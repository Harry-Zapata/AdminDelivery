using System;
using System.Collections.Generic;
using System.Text;

namespace AdminDelivery.Modelo
{
    public class MProductos
    {
        public string Nombre { get; set; }
        public string Stock{ get; set; }
        public string FechaVencimiento { get; set; }
        public string FechaRegistro { get; set; }
        public string PrecioCompra { get; set; }
        public string PrecioVenta{ get; set; }
        public string Foto { get; set; }
        public string IdProducto { get; set; }
    }
}
