using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaqueriaProyecto
{
    internal class Producto
    {
        private int idProducto;
        private string nombre = "";
        private decimal precio;
        private string tipo = "";
        private bool disponible;

        public int IdProducto { get => idProducto; set => idProducto = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public decimal Precio { get => precio; set => precio = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        public bool Disponible { get => disponible; set => disponible = value; }

        public virtual string ObtenerDescripcion()
        {
            return Nombre + " $" + Precio;
        }
    }
}
