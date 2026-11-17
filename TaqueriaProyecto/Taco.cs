using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaqueriaProyecto
{
    // Clase que representa un taco y hereda de Producto
    internal class Taco: Producto
    {
        // Tortilla y guiso del taco
        private string tortilla = "";
        private string guiso = "";

        // Propiedades para leer y cambiar los datos del taco
        public string Tortilla { get => tortilla; set => tortilla = value; }
        public string Guiso { get => guiso; set => guiso = value; }

        // Devuelve la descripcion completa del taco
        public override string ObtenerDescripcion()
        {
            return Nombre + ": " + Guiso + " " + Tortilla + " $" + Precio;
        }
    }
}
