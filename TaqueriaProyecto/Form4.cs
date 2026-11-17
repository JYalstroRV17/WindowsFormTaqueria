using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaqueriaProyecto
{
    // Formulario para registrar consultar actualizar y eliminar empleados
    public partial class Form4 : Form
    {
        // Constructor del formulario
        public Form4()
        {
            InitializeComponent();

            // Se cargan los empleados en la tabla
            Conexion nuevaConexion = new Conexion();

            dataGridViewEmpleados.DataSource = nuevaConexion.ObservarEmpleados();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        // Registra un empleado nuevo con los datos escritos
        private void buttonRegis_Click(object sender, EventArgs e)
        {
            // Se validan los campos obligatorios
            if (textBoxNomEmpleado.Text == "" || textBoxPuesto.Text == "")
            {
                MessageBox.Show("Completa todos los campos");
                return;
            }

            Conexion nuevaConexion = new Conexion();

            // Se guarda el empleado en la base de datos
            nuevaConexion.RegistrarEmpleado(
                textBoxNomEmpleado.Text,
                textBoxPuesto.Text
            );

            // Se recarga la tabla y se limpian los campos
            dataGridViewEmpleados.DataSource = nuevaConexion.ObservarEmpleados();

            textBoxNomEmpleado.Clear();
            textBoxPuesto.Clear();

            MessageBox.Show("Empleado registrado correctamente");
        }

        // Actualiza el empleado seleccionado con los datos de los campos
        private void buttonActua_Click(object sender, EventArgs e)
        {
            // Se valida que exista una fila seleccionada
            if (dataGridViewEmpleados.CurrentRow == null)
            {
                MessageBox.Show("Selecciona un empleado primero");
                return;
            }

            int id = Convert.ToInt32(
                dataGridViewEmpleados.CurrentRow.Cells["id_empleado"].Value
            );

            if (textBoxNomEmpleado.Text == "" || textBoxPuesto.Text == "")
            {
                MessageBox.Show("Completa todos los campos");
                return;
            }

            Conexion nuevaConexion = new Conexion();

            // Se actualiza el empleado en la base de datos
            nuevaConexion.ActualizarEmpleado(id, textBoxNomEmpleado.Text,textBoxPuesto.Text
            );

            // Se recarga la tabla de empleados y se limpian los campos
            dataGridViewEmpleados.DataSource = nuevaConexion.ObservarEmpleados();

            textBoxNomEmpleado.Clear();
            textBoxPuesto.Clear();

            MessageBox.Show("Empleado actualizado correctamente");
        }

        // Al hacer clic en una fila se copian sus datos en los campos
        private void dataGridViewEmpleados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dataGridViewEmpleados.Rows[e.RowIndex];

                textBoxNomEmpleado.Text = fila.Cells["nombre"].Value.ToString();
                textBoxPuesto.Text = fila.Cells["puesto"].Value.ToString();
            }

        }

        // Elimina el empleado seleccionado en la tabla
        private void buttonElimi_Click(object sender, EventArgs e)
        {
            // Se valida que exista una fila seleccionada
            if (dataGridViewEmpleados.CurrentRow == null)
            {
                MessageBox.Show("Selecciona un empleado primero");
                return;
            }

            int id = Convert.ToInt32(
                dataGridViewEmpleados.CurrentRow.Cells["id_empleado"].Value
            );

            Conexion nuevaConexion = new Conexion();

            // Se elimina el empleado por su id
            nuevaConexion.EliminarEmpleado(id);

            // Se recarga la tabla y se limpian los campos
            dataGridViewEmpleados.DataSource = nuevaConexion.ObservarEmpleados();

            textBoxNomEmpleado.Clear();
            textBoxPuesto.Clear();

            MessageBox.Show("Empleado eliminado correctamente");
        }
    }
    
}
