using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Hilos
{
    public partial class Form1 : Form
    {
        Thread hilo;
        delegate void delegado(int valor);

        public Form1()
        {
            InitializeComponent();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            hilo = new Thread(ProcesoUno);
            hilo.Start();
            hilo = new Thread(ProcesoDos);
            hilo.Start();
            hilo = new Thread(ProcesoTres);
            hilo.Start();
        }

        public void ProcesoUno()
        {
            for (int i = 0; i < 101; i++)
            {
                delegado metodoDelegado = new delegado(ActualizarUno);
                this.Invoke(metodoDelegado, new object[] { i });
                Thread.Sleep(70);
            }
        }

        public void ActualizarUno(int valor) // Modelo del delegado
        {
            barraProgresoUno.Value = valor;
        }

        public void ProcesoDos()
        {
            for (int i = 0; i < 101; i++)
            {
                delegado metodoDelegado = new delegado(ActualizarDos);
                this.Invoke(metodoDelegado, new object[] { i });
                Thread.Sleep(30);
            }
        }

        public void ActualizarDos(int valor) // Modelo del delegado
        {
            barraProgresoDos.Value = valor;
        }

        public void ProcesoTres()
        {
            for (int i = 0; i < 101; i++)
            {
                delegado metodoDelegado = new delegado(ActualizarTres);
                this.Invoke(metodoDelegado, new object[] { i });
                Thread.Sleep(40);
            }
        }

        public void ActualizarTres(int valor) // Modelo del delegado
        {
            barraProgresoTres.Value = valor;
        }
    }
}
