using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaqueriaProyecto
{
    // Clase que representa a un cliente
    internal class Cliente
    {
        // Datos del cliente
        private int idCliente;
        private string nombre = "";
        private string telefono = "";

        // Propiedades para leer y cambiar los datos del cliente
        public int IdCliente { get => idCliente; set => idCliente = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Telefono { get => telefono; set => telefono = value; }
    }
}
