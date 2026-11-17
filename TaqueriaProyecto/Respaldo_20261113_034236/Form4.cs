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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();

            Conexion nuevaConexion = new Conexion();

            dataGridViewEmpleados.DataSource = nuevaConexion.ObservarEmpleados();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonRegis_Click(object sender, EventArgs e)
        {
            if (textBoxNomEmpleado.Text == "" || textBoxPuesto.Text == "")
            {
                MessageBox.Show("Completa todos los campos");
                return;
            }

            Conexion nuevaConexion = new Conexion();

            nuevaConexion.RegistrarEmpleado(
                textBoxNomEmpleado.Text,
                textBoxPuesto.Text
            );

            dataGridViewEmpleados.DataSource = nuevaConexion.ObservarEmpleados();

            textBoxNomEmpleado.Clear();
            textBoxPuesto.Clear();

            MessageBox.Show("Empleado registrado correctamente");
        }

        private void buttonActua_Click(object sender, EventArgs e)
        {
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

            nuevaConexion.ActualizarEmpleado(id, textBoxNomEmpleado.Text,textBoxPuesto.Text
            );

            dataGridViewEmpleados.DataSource = nuevaConexion.ObservarEmpleados();

            textBoxNomEmpleado.Clear();
            textBoxPuesto.Clear();

            MessageBox.Show("Empleado actualizado correctamente");
        }

        private void dataGridViewEmpleados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dataGridViewEmpleados.Rows[e.RowIndex];

                textBoxNomEmpleado.Text = fila.Cells["nombre"].Value.ToString();
                textBoxPuesto.Text = fila.Cells["puesto"].Value.ToString();
            }

        }

        private void buttonElimi_Click(object sender, EventArgs e)
        {
            if (dataGridViewEmpleados.CurrentRow == null)
            {
                MessageBox.Show("Selecciona un empleado primero");
                return;
            }

            int id = Convert.ToInt32(
                dataGridViewEmpleados.CurrentRow.Cells["id_empleado"].Value
            );

            Conexion nuevaConexion = new Conexion();

            nuevaConexion.EliminarEmpleado(id);

            dataGridViewEmpleados.DataSource = nuevaConexion.ObservarEmpleados();

            textBoxNomEmpleado.Clear();
            textBoxPuesto.Clear();

            MessageBox.Show("Empleado eliminado correctamente");
        }
    }
    
}
