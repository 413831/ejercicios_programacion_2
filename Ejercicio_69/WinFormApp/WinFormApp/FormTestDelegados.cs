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
    public partial class FormTestDelegados : Form
    {
        public delegate void DelegadoActualizar(string dato);
        public event DelegadoActualizar EventoActualizar;

        public FormTestDelegados()
        {
            InitializeComponent();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(this.textBox1.Text))
            {
                this.EventoActualizar(this.textBox1.Text);
            }
        }
    }
}
