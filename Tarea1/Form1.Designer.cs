namespace Tarea1
{
    partial class MainForm
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnLoadText = new System.Windows.Forms.Button();
            this.txtBoxFirst = new System.Windows.Forms.TextBox();
            this.txtBoxSecond = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.brnLoad = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLoadText
            // 
            this.btnLoadText.Location = new System.Drawing.Point(338, 81);
            this.btnLoadText.Name = "btnLoadText";
            this.btnLoadText.Size = new System.Drawing.Size(114, 38);
            this.btnLoadText.TabIndex = 0;
            this.btnLoadText.Text = "Cargar texto";
            this.btnLoadText.UseVisualStyleBackColor = true;
            this.btnLoadText.Click += new System.EventHandler(this.btnLoadText_Click);
            // 
            // txtBoxFirst
            // 
            this.txtBoxFirst.Location = new System.Drawing.Point(52, 30);
            this.txtBoxFirst.Multiline = true;
            this.txtBoxFirst.Name = "txtBoxFirst";
            this.txtBoxFirst.Size = new System.Drawing.Size(189, 153);
            this.txtBoxFirst.TabIndex = 1;
            // 
            // txtBoxSecond
            // 
            this.txtBoxSecond.Location = new System.Drawing.Point(547, 30);
            this.txtBoxSecond.Multiline = true;
            this.txtBoxSecond.Name = "txtBoxSecond";
            this.txtBoxSecond.ReadOnly = true;
            this.txtBoxSecond.Size = new System.Drawing.Size(189, 153);
            this.txtBoxSecond.TabIndex = 2;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(184, 254);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(459, 150);
            this.dataGridView1.TabIndex = 3;
            // 
            // brnLoad
            // 
            this.brnLoad.Location = new System.Drawing.Point(338, 166);
            this.brnLoad.Name = "brnLoad";
            this.brnLoad.Size = new System.Drawing.Size(114, 41);
            this.brnLoad.TabIndex = 4;
            this.brnLoad.Text = "Cargar";
            this.brnLoad.UseVisualStyleBackColor = true;
            this.brnLoad.Click += new System.EventHandler(this.brnLoad_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.brnLoad);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtBoxSecond);
            this.Controls.Add(this.txtBoxFirst);
            this.Controls.Add(this.btnLoadText);
            this.Name = "MainForm";
            this.Text = "Main";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoadText;
        private System.Windows.Forms.TextBox txtBoxFirst;
        private System.Windows.Forms.TextBox txtBoxSecond;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button brnLoad;
    }
}

