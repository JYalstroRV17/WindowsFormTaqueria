using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaqueriaProyecto
{
    // Clase base que representa un producto
    internal class Producto
    {
        // Datos generales del producto
        private int idProducto;
        private string nombre = "";
        private decimal precio;
        private string tipo = "";
        private bool disponible;

        // Getter y setter de los datos del producto
        public int IdProducto { get => idProducto; set => idProducto = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public decimal Precio { get => precio; set => precio = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        public bool Disponible { get => disponible; set => disponible = value; }

        // Devuelve una descripcion basica del producto
        public virtual string ObtenerDescripcion()
        {
            return Nombre + " $" + Precio;
        }
    }
}
