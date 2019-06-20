namespace Hilos
{
    partial class Form1
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
            this.btnIniciar = new System.Windows.Forms.Button();
            this.barraProgresoUno = new System.Windows.Forms.ProgressBar();
            this.barraProgresoTres = new System.Windows.Forms.ProgressBar();
            this.barraProgresoDos = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // btnIniciar
            // 
            this.btnIniciar.Location = new System.Drawing.Point(264, 12);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(75, 23);
            this.btnIniciar.TabIndex = 0;
            this.btnIniciar.Text = "Iniciar";
            this.btnIniciar.UseVisualStyleBackColor = true;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // barraProgresoUno
            // 
            this.barraProgresoUno.Location = new System.Drawing.Point(12, 55);
            this.barraProgresoUno.Name = "barraProgresoUno";
            this.barraProgresoUno.Size = new System.Drawing.Size(582, 23);
            this.barraProgresoUno.TabIndex = 1;
            // 
            // barraProgresoTres
            // 
            this.barraProgresoTres.Location = new System.Drawing.Point(12, 113);
            this.barraProgresoTres.Name = "barraProgresoTres";
            this.barraProgresoTres.Size = new System.Drawing.Size(582, 23);
            this.barraProgresoTres.TabIndex = 2;
            // 
            // barraProgresoDos
            // 
            this.barraProgresoDos.Location = new System.Drawing.Point(12, 84);
            this.barraProgresoDos.Name = "barraProgresoDos";
            this.barraProgresoDos.Size = new System.Drawing.Size(582, 23);
            this.barraProgresoDos.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 222);
            this.Controls.Add(this.barraProgresoDos);
            this.Controls.Add(this.barraProgresoTres);
            this.Controls.Add(this.barraProgresoUno);
            this.Controls.Add(this.btnIniciar);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.ProgressBar barraProgresoUno;
        private System.Windows.Forms.ProgressBar barraProgresoTres;
        private System.Windows.Forms.ProgressBar barraProgresoDos;
    }
}

