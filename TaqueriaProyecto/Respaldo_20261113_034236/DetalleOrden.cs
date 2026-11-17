using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaqueriaProyecto
{
    internal class DetalleOrden
    {
        private int idDetalle;
        private int idOrden;
        private int idProducto;
        private int cantidad;
        private decimal precioUnitario;
        private decimal subtotal;

        public int IdDetalle { get => idDetalle; set => idDetalle = value; }
        public int IdOrden { get => idOrden; set => idOrden = value; }
        public int IdProducto { get => idProducto; set => idProducto = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public decimal PrecioUnitario { get => precioUnitario; set => precioUnitario = value; }
        public decimal Subtotal { get => subtotal; set => subtotal = value; }
    }
}
