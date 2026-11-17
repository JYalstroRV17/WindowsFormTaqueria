using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace TaqueriaProyecto
{
    public partial class Form2 : Form
    {
        DataTable detalle = new DataTable();
        public Form2()
        {
            InitializeComponent();

            Conexion nuevaConexion = new Conexion();
            comboBoxCliente.DataSource = nuevaConexion.ObservarClientes();
            comboBoxCliente.DisplayMember = "nombre";
            comboBoxCliente.ValueMember = "id_cliente";

            comboBoxEmpleado.DataSource = nuevaConexion.ObservarEmpleados();
            comboBoxEmpleado.DisplayMember = "nombre";
            comboBoxEmpleado.ValueMember = "id_empleado";

            comboBoxProducto.DataSource = nuevaConexion.ObservarProductos();
            comboBoxProducto.DisplayMember = "nombre";
            comboBoxProducto.ValueMember = "id_producto";

            comboBoxCliente.SelectedIndex = -1;
            comboBoxEmpleado.SelectedIndex = -1;
            comboBoxProducto.SelectedIndex = -1;


            dataGridView1.DataSource = detalle;

            detalle.Columns.Add("id_producto", typeof(int));
            detalle.Columns.Add("nombre", typeof(string));
            detalle.Columns.Add("precio", typeof(decimal));
            detalle.Columns.Add("cantidad", typeof(int));
            detalle.Columns.Add("subtotal", typeof(decimal));

            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(comboBoxProducto.SelectedValue);

            DataRowView producto = (DataRowView)comboBoxProducto.SelectedItem;

            string nombre = producto["nombre"].ToString();
            decimal precio = Convert.ToDecimal(producto["precio"]);
            int cantidad = Convert.ToInt32(textBoxCantidad.Text);

            decimal subtotal = precio * cantidad;

            detalle.Rows.Add(id, nombre, precio, cantidad, subtotal);

            decimal total = 0;

            foreach (DataRow fila in detalle.Rows)
            {
                total += Convert.ToDecimal(fila["subtotal"]);
            }

            textBoxTotal.Text = total.ToString("0.00");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonRegistrarOrden_Click(object sender, EventArgs e)
        {
            if (detalle.Rows.Count == 0)
            {
                MessageBox.Show("Agrega al menos un producto a la orden");
                return;
            }

            if (comboBoxCliente.SelectedIndex == -1 && (textBoxNomCliente.Text == "" || textBoxTelClien.Text == ""))
            {
                MessageBox.Show("Selecciona un cliente o registra uno nuevo");
                return;
            }

            if (comboBoxEmpleado.SelectedIndex == -1)
            {
                MessageBox.Show("Selecciona un empleado");
                return;
            }

            if (comboBoxProducto.SelectedIndex == -1)
            {
                MessageBox.Show("Selecciona un producto");
                return;
            }
            string nombre = textBoxNomCliente.Text;
            string telefono = textBoxTelClien.Text;

            Conexion nuevaConexion = new Conexion();

            int idCliente;

            if (nombre != "" || telefono != "")
            {
                if (nombre == "" || telefono == "")
                {
                    MessageBox.Show("Completa el nombre y teléfono del cliente");
                    return;
                }

                idCliente = nuevaConexion.RegistrarCliente(nombre, telefono);

                comboBoxCliente.DataSource = nuevaConexion.ObservarClientes();
                comboBoxCliente.DisplayMember = "nombre";
                comboBoxCliente.ValueMember = "id_cliente";

                comboBoxCliente.SelectedValue = idCliente;
            }
            else
            {
                idCliente = Convert.ToInt32(comboBoxCliente.SelectedValue);
            }

            int idEmpleado = Convert.ToInt32(comboBoxEmpleado.SelectedValue);

            decimal total = Convert.ToDecimal(textBoxTotal.Text);

            int idOrden = nuevaConexion.RegistrarOrden(idCliente, idEmpleado, total);

            foreach (DataRow fila in detalle.Rows)
            {
                int idProducto = Convert.ToInt32(fila["id_producto"]);
                int cantidad = Convert.ToInt32(fila["cantidad"]);
                decimal precio = Convert.ToDecimal(fila["precio"]);
                decimal subtotal = Convert.ToDecimal(fila["subtotal"]);

                nuevaConexion.RegistrarDetalleOrden(
                    idOrden, idProducto, cantidad, precio, subtotal
                );
            }

            MessageBox.Show("Orden registrada correctamente");

            detalle.Clear();

            textBoxTotal.Clear();

            textBoxNomCliente.Clear();
            textBoxTelClien.Clear();

            textBoxCantidad.Clear();

            comboBoxCliente.SelectedIndex = -1;
            comboBoxEmpleado.SelectedIndex = -1;
            comboBoxProducto.SelectedIndex = -1;
        }

        private void buttonProductos_Click(object sender, EventArgs e)
        {
            Form1 nuevaVentana = new Form1();
            nuevaVentana.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 nuevaVentana = new Form3();
            nuevaVentana.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 nuevaVentana = new Form4();
            nuevaVentana.Show();
        }
    }
}
