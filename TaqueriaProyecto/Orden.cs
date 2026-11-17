using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaqueriaProyecto
{
    // Clase que representa una orden
    internal class Orden
    {
        // Datos de la orden
        private int idOrden;
        private int idCliente;
        private int idEmpleado;
        private DateTime fecha;
        private decimal total;

        // Propiedades para leer y cambiar los datos de la orden
        public int IdOrden { get => idOrden; set => idOrden = value; }
        public int IdCliente { get => idCliente; set => idCliente = value; }
        public int IdEmpleado { get => idEmpleado; set => idEmpleado = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public decimal Total { get => total; set => total = value; }
    }
}
