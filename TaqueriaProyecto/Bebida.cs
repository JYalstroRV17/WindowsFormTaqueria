using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaqueriaProyecto
{
    // Clase que representa una bebida y hereda de Producto
    internal class Bebida: Producto
    {
        // Tipo y tamanio de la bebida
        private string tipoB = "";
        private string tamanio = "";

        // Propiedades para leer y cambiar los datos de la bebida
        public string TipoB { get => tipoB; set => tipoB = value; }
        public string Tamanio { get => tamanio; set => tamanio = value; }

        // Devuelve la descripcion completa de la bebida
        public override string ObtenerDescripcion()
        {
            return Nombre + ": " + TipoB + " " + Tamanio + " $" + Precio;
        }
    }
}
