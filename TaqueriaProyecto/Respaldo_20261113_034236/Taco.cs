using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaqueriaProyecto
{
    internal class Taco: Producto
    {
        private string tortilla = "";
        private string guiso = "";

        public string Tortilla { get => tortilla; set => tortilla = value; }
        public string Guiso { get => guiso; set => guiso = value; }

        public override string ObtenerDescripcion()
        {
            return Nombre + ": " + Guiso + " " + Tortilla + " $" + Precio;
        }
    }
}
