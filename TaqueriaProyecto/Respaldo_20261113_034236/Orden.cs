using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaqueriaProyecto
{
    internal class Orden
    {
        private int idOrden;
        private int idCliente;
        private int idEmpleado;
        private DateTime fecha;
        private decimal total;

        public int IdOrden { get => idOrden; set => idOrden = value; }
        public int IdCliente { get => idCliente; set => idCliente = value; }
        public int IdEmpleado { get => idEmpleado; set => idEmpleado = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public decimal Total { get => total; set => total = value; }
    }
}
