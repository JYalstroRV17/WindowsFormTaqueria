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
    // Formulario para consultar las ordenes registradas
    public partial class Form3 : Form
    {
        // Constructor del formulario
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        // Consulta las ordenes y las muestra en la tabla
        private void buttonConsultarOrdenes_Click(object sender, EventArgs e)
        {
            Conexion nuevaConexion = new Conexion();

            dataGridView2.DataSource = nuevaConexion.ObservarOrdenes();
        }
    }
}
