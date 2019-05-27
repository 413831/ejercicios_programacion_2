using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Notepad
{
    public partial class FormEditor : Form
    {
        string nombreArchivo;

        public FormEditor()
        {
            InitializeComponent();
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ventana = new OpenFileDialog();
            StreamReader textoArchivo;

            if(ventana.ShowDialog() == DialogResult.OK)
            {
                textoArchivo = new StreamReader(ventana.FileName);
                nombreArchivo = ventana.FileName;
                richTextBox1.Text = textoArchivo.ReadToEnd();
                textoArchivo.Close();
            }
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StreamWriter textoArchivo;

            if(File.Exists(nombreArchivo))
            {
                textoArchivo = new StreamWriter(nombreArchivo);
                textoArchivo.Write(richTextBox1.Text);
                textoArchivo.Close();
            }
            else
            {
                this.guardarComoToolStripMenuItem1_Click(sender, e);
            }
        }

        private void guardarComoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SaveFileDialog ventana = new SaveFileDialog();
            StreamWriter textoArchivo;

            if (ventana.ShowDialog() == DialogResult.OK)
            {
                textoArchivo = new StreamWriter(ventana.FileName);
                textoArchivo.Write(richTextBox1.Text);
                textoArchivo.Close();
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Caracteres: " + richTextBox1.TextLength.ToString();
        }
    }
}
