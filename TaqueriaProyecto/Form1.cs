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
    // Formulario para registrar consultar actualizar y eliminar productos
    public partial class Form1 : Form
    {
        // Constructor del formulario
        public Form1()
        {
            InitializeComponent();

            // Se crea la conexion y se cargan los productos en la tabla
            Conexion nuevaConexion = new Conexion();
            dataGridView1.DataSource = nuevaConexion.Observar();

           

            // Se prueba la conexion con MySQL al iniciar
            try
            {
                nuevaConexion.AbrirConexion();
                MessageBox.Show("Conexión exitosa con MySQL");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                nuevaConexion.CerrarConexion();
            }
        }

        // Al cargar el formulario se llenan los tipos de producto
        private void Form1_Load(object sender, EventArgs e)
        {
            comboBoxTipo.Items.Clear();
            comboBoxTipo.Items.Add("Taco");
            comboBoxTipo.Items.Add("Bebida");


        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        // Al hacer clic en una fila se copian sus datos en los campos del formulario
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dataGridView1.Rows[e.RowIndex];

                textNombre.Text = fila.Cells["nombre"].Value.ToString();
                textPrecio.Text = fila.Cells["precio"].Value.ToString();
                comboBoxTipo.Text = fila.Cells["tipo"].Value.ToString();
                Disponible.Checked = Convert.ToBoolean(fila.Cells["disponible"].Value);

                textBoxGuiso.Text = fila.Cells["guiso"].Value.ToString();
                textBoxTortilla.Text = fila.Cells["tortilla"].Value.ToString();
                textBoxTipBebida.Text = fila.Cells["tipo_bebida"].Value.ToString();
                textBoxTamanio.Text = fila.Cells["tamanio"].Value.ToString();
            }
        }

        // Actualiza el producto seleccionado con los datos de los campos
        private void Actualizar_Click(object sender, EventArgs e)
        {
            // Se valida que exista una fila seleccionada
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Selecciona un producto primero");
                return;
            }

            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id_producto"].Value);


            // Se guardan los datos de los campos en variables
            string nombre = textNombre.Text;
            decimal precio = Convert.ToDecimal(textPrecio.Text);
            string tipo = comboBoxTipo.Text;
            bool disponible = Disponible.Checked;
            string guiso = textBoxGuiso.Text;
            string tortilla = textBoxTortilla.Text;
            string tipoBebida = textBoxTipBebida.Text;
            string tamanio = textBoxTamanio.Text;

            // Se ejecuta la actualizacion en la base de datos
            Conexion nuevaConexion = new Conexion();

            try
            {
                bool resultado = nuevaConexion.Actualizar(id, nombre, precio, tipo, 
                    disponible,guiso, tortilla, tipoBebida, tamanio);
                if (resultado)
                {
                    MessageBox.Show("Producto actualizado correctamente");
                    dataGridView1.DataSource = nuevaConexion.Observar();
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar el producto");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Elimina el producto seleccionado en la tabla
        private void Eliminar_Click(object sender, EventArgs e)
        {
            // Se valida que exista una fila seleccionada
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Selecciona un producto primero");
                return;
            }

            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id_producto"].Value);

            Conexion nuevaConexion = new Conexion();

            try
            {
                bool resultado = nuevaConexion.Eliminar(id);

                if (resultado)
                {
                    MessageBox.Show("Producto eliminado correctamente");
                    dataGridView1.DataSource = nuevaConexion.Observar();
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el producto");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBoxTortilla_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        // Inserta un producto nuevo con los datos escritos en el formulario
        private void Insertar_Click(object sender, EventArgs e)
        {
            // Se leen los datos de los campos
            string nombre = textNombre.Text;
            decimal precio = Convert.ToDecimal(textPrecio.Text);
            string tipo = comboBoxTipo.Text;
            bool disponible = Disponible.Checked;

            string guiso = textBoxGuiso.Text;
            string tortilla = textBoxTortilla.Text;
            string tipoBebida = textBoxTipBebida.Text;
            string tamanio = textBoxTamanio.Text;

            Conexion nuevaConexion = new Conexion();

            try
            {
                bool resultado = nuevaConexion.Insertar(nombre, precio, tipo, disponible,guiso, tortilla, tipoBebida, tamanio);


                if (resultado)
                {
                    MessageBox.Show("Producto registrado correctamente");
                    dataGridView1.DataSource = nuevaConexion.Observar();
                }
                else
                {
                    MessageBox.Show("No se pudo registrar el producto");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        // Abre el formulario de ordenes
        private void buttonOrdenes_Click(object sender, EventArgs e)
        {
            Form2 nuevaVentana = new Form2();
            nuevaVentana.Show();
        }

        // Abre el formulario de consulta de ordenes
        private void button1_Click_1(object sender, EventArgs e)
        {
            Form3 nuevaVentana = new Form3();
            nuevaVentana.Show();
        }

        // Abre el formulario de empleados
        private void button2_Click(object sender, EventArgs e)
        {
            Form4 nuevaVentana = new Form4();
            nuevaVentana.Show();
        }
    }
}
