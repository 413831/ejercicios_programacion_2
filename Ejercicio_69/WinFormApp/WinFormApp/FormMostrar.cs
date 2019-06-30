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
    public partial class FormMostrar : Form
    {
        public FormMostrar()
        {
            InitializeComponent();
        }

        public void ActualizarNombre(string dato)
        {
            this.lblEtiqueta.Text = dato;
        }

        private void FormMostrar_Load(object sender, EventArgs e)
        {

        }
    }
}
