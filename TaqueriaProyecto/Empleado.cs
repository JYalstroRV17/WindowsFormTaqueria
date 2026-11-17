using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaqueriaProyecto
{
    // Clase que representa a un empleado
    internal class Empleado
    {
        // Datos del empleado
        private int idEmpleado;
        private string nombre="";
        private string puesto="";

        // Propiedades para leer y cambiar los datos del empleado
        public int IdEmpleado { get => idEmpleado; set => idEmpleado = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Puesto { get => puesto; set => puesto = value; }
    }
}
