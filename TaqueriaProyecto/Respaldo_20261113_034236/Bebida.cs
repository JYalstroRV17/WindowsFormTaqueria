using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaqueriaProyecto
{
    internal class Bebida: Producto
    {
        private string tipoB = "";
        private string tamanio = "";

        public string TipoB { get => tipoB; set => tipoB = value; }
        public string Tamanio { get => tamanio; set => tamanio = value; }

        public override string ObtenerDescripcion()
        {
            return Nombre + ": " + TipoB + " " + Tamanio + " $" + Precio;
        }
    }
}
