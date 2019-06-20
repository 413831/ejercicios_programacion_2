using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace Ejercicio_61
{
    public partial class Form1 : Form
    {
        PersonaDAO baseDeDatos;
        public int contador = 0;

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            baseDeDatos = new PersonaDAO();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnLeer_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(baseDeDatos.Leer());
        }
    }
}
