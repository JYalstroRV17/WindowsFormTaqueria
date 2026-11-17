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
    // Formulario para armar y registrar una orden
    public partial class Form2 : Form
    {
        // Tabla en memoria que guarda los productos agregados a la orden
        DataTable detalle = new DataTable();
        // Constructor del formulario
        public Form2()
        {
            InitializeComponent();

            // Se cargan los clientes en el combo
            Conexion nuevaConexion = new Conexion();
            comboBoxCliente.DataSource = nuevaConexion.ObservarClientes();
            comboBoxCliente.DisplayMember = "nombre";
            comboBoxCliente.ValueMember = "id_cliente";

            // Se cargan los empleados en el combo
            comboBoxEmpleado.DataSource = nuevaConexion.ObservarEmpleados();
            comboBoxEmpleado.DisplayMember = "nombre";
            comboBoxEmpleado.ValueMember = "id_empleado";

            // Se cargan los productos disponibles en el combo
            comboBoxProducto.DataSource = nuevaConexion.ObservarProductos();
            comboBoxProducto.DisplayMember = "nombre";
            comboBoxProducto.ValueMember = "id_producto";

            // Se dejan los combos sin seleccion
            comboBoxCliente.SelectedIndex = -1;
            comboBoxEmpleado.SelectedIndex = -1;
            comboBoxProducto.SelectedIndex = -1;

            // Se muestra el detalle en la tabla
            dataGridView1.DataSource = detalle;

            // Se definen las columnas que tendra el detalle
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

        // Agrega el producto elegido al detalle de la orden
        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            // Se toman el id el nombre y el precio del producto seleccionado
            int id = Convert.ToInt32(comboBoxProducto.SelectedValue);

            DataRowView producto = (DataRowView)comboBoxProducto.SelectedItem;

            string nombre = producto["nombre"].ToString();
            decimal precio = Convert.ToDecimal(producto["precio"]);
            int cantidad = Convert.ToInt32(textBoxCantidad.Text);

            // Se calcula el subtotal de la linea
            decimal subtotal = precio * cantidad;

            // Se agrega la fila al detalle
            detalle.Rows.Add(id, nombre, precio, cantidad, subtotal);

            // Se recorre el detalle para calcular el total de la orden
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

        // Registra la orden completa en la base de datos
        private void buttonRegistrarOrden_Click(object sender, EventArgs e)
        {
            // Se valida que el detalle tenga al menos un producto
            if (detalle.Rows.Count == 0)
            {
                MessageBox.Show("Agrega al menos un producto a la orden");
                return;
            }

            // Se validan los datos del cliente el empleado y el producto
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
            // Datos del cliente nuevo escritos en los campos
            string nombre = textBoxNomCliente.Text;
            string telefono = textBoxTelClien.Text;

            Conexion nuevaConexion = new Conexion();

            int idCliente;

            // Si se escribieron datos se registra un cliente nuevo
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

            // Se toma el empleado y el total de la orden
            int idEmpleado = Convert.ToInt32(comboBoxEmpleado.SelectedValue);

            decimal total = Convert.ToDecimal(textBoxTotal.Text);

            // Se guarda la orden y se obtiene su id
            int idOrden = nuevaConexion.RegistrarOrden(idCliente, idEmpleado, total);

            // Se guarda cada linea del detalle de la orden
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

            // Se limpian el detalle y los campos del formulario
            detalle.Clear();

            textBoxTotal.Clear();

            textBoxNomCliente.Clear();
            textBoxTelClien.Clear();

            textBoxCantidad.Clear();

            comboBoxCliente.SelectedIndex = -1;
            comboBoxEmpleado.SelectedIndex = -1;
            comboBoxProducto.SelectedIndex = -1;
        }

        // Abre el formulario de productos
        private void buttonProductos_Click(object sender, EventArgs e)
        {
            Form1 nuevaVentana = new Form1();
            nuevaVentana.Show();
        }

        // Abre el formulario de consulta de ordenes
        private void button2_Click(object sender, EventArgs e)
        {
            Form3 nuevaVentana = new Form3();
            nuevaVentana.Show();
        }

        // Abre el formulario de empleados
        private void button3_Click(object sender, EventArgs e)
        {
            Form4 nuevaVentana = new Form4();
            nuevaVentana.Show();
        }
    }
}
