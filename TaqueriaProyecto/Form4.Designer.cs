namespace TaqueriaProyecto
{
    partial class Form4
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxNomEmpleado = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxPuesto = new System.Windows.Forms.TextBox();
            this.dataGridViewEmpleados = new System.Windows.Forms.DataGridView();
            this.buttonRegis = new System.Windows.Forms.Button();
            this.buttonActua = new System.Windows.Forms.Button();
            this.buttonElimi = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmpleados)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre";
            // 
            // textBoxNomEmpleado
            // 
            this.textBoxNomEmpleado.Location = new System.Drawing.Point(32, 42);
            this.textBoxNomEmpleado.Name = "textBoxNomEmpleado";
            this.textBoxNomEmpleado.Size = new System.Drawing.Size(100, 20);
            this.textBoxNomEmpleado.TabIndex = 1;
            this.textBoxNomEmpleado.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Puesto";
            // 
            // textBoxPuesto
            // 
            this.textBoxPuesto.Location = new System.Drawing.Point(32, 100);
            this.textBoxPuesto.Name = "textBoxPuesto";
            this.textBoxPuesto.Size = new System.Drawing.Size(100, 20);
            this.textBoxPuesto.TabIndex = 3;
            // 
            // dataGridViewEmpleados
            // 
            this.dataGridViewEmpleados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEmpleados.Location = new System.Drawing.Point(267, 43);
            this.dataGridViewEmpleados.Name = "dataGridViewEmpleados";
            this.dataGridViewEmpleados.Size = new System.Drawing.Size(511, 349);
            this.dataGridViewEmpleados.TabIndex = 4;
            this.dataGridViewEmpleados.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewEmpleados_CellContentClick);
            // 
            // buttonRegis
            // 
            this.buttonRegis.Location = new System.Drawing.Point(47, 177);
            this.buttonRegis.Name = "buttonRegis";
            this.buttonRegis.Size = new System.Drawing.Size(75, 23);
            this.buttonRegis.TabIndex = 5;
            this.buttonRegis.Text = "Registrar";
            this.buttonRegis.UseVisualStyleBackColor = true;
            this.buttonRegis.Click += new System.EventHandler(this.buttonRegis_Click);
            // 
            // buttonActua
            // 
            this.buttonActua.Location = new System.Drawing.Point(12, 148);
            this.buttonActua.Name = "buttonActua";
            this.buttonActua.Size = new System.Drawing.Size(75, 23);
            this.buttonActua.TabIndex = 6;
            this.buttonActua.Text = "Actualizar";
            this.buttonActua.UseVisualStyleBackColor = true;
            this.buttonActua.Click += new System.EventHandler(this.buttonActua_Click);
            // 
            // buttonElimi
            // 
            this.buttonElimi.Location = new System.Drawing.Point(93, 148);
            this.buttonElimi.Name = "buttonElimi";
            this.buttonElimi.Size = new System.Drawing.Size(75, 23);
            this.buttonElimi.TabIndex = 7;
            this.buttonElimi.Text = "Eliminar";
            this.buttonElimi.UseVisualStyleBackColor = true;
            this.buttonElimi.Click += new System.EventHandler(this.buttonElimi_Click);
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonElimi);
            this.Controls.Add(this.buttonActua);
            this.Controls.Add(this.buttonRegis);
            this.Controls.Add(this.dataGridViewEmpleados);
            this.Controls.Add(this.textBoxPuesto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxNomEmpleado);
            this.Controls.Add(this.label1);
            this.Name = "Form4";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmpleados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxNomEmpleado;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxPuesto;
        private System.Windows.Forms.DataGridView dataGridViewEmpleados;
        private System.Windows.Forms.Button buttonRegis;
        private System.Windows.Forms.Button buttonActua;
        private System.Windows.Forms.Button buttonElimi;
    }
}