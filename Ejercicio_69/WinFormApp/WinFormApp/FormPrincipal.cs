using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormApp
{
    public partial class FormPrincipal : Form
    {
        FormTestDelegados formDelegados;
        FormMostrar formMostrar;

        public FormPrincipal()
        {
            InitializeComponent();
            this.IsMdiContainer = true; // Establezco que el formulario actual es contenedor
        }

        private void testDelegadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formDelegados.MdiParent = this; // Establezco que el nuevo formulario está contenido por el formulario actual
            this.mostrarToolStripMenuItem.Enabled = true;
            formDelegados.EventoActualizar += formMostrar.ActualizarNombre;

            formDelegados.Show();
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            this.mostrarToolStripMenuItem.Enabled = false;
            formDelegados = new FormTestDelegados();
            formMostrar = new FormMostrar();
        }

        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formMostrar.MdiParent = this;
            // Enlazo el evento que me trae el nuevo texto para el label con el método que cambia el texto del label
            
            formMostrar.Show();
        }
    }
}
