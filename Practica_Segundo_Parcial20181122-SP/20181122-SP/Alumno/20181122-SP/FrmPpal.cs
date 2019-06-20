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
using Archivos;
using System.Threading;
using Patentes;

namespace _20181122_SP
{
    public partial class FrmPpal : Form
    {
        Queue<Patente> cola;
        List<Thread> hilos;

        public FrmPpal()
        {
            InitializeComponent();

            this.cola = new Queue<Patente>();

            hilos = new List<Thread>();
        }

        private void FrmPpal_Load(object sender, EventArgs e)
        {
            vistaPatente1.MostrarSiguientePatente += this.ProximaPatente; // Se agrega al manejador de eventos
            vistaPatente2.MostrarSiguientePatente += this.ProximaPatente;
        }

        private void FrmPpal_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.FinalizarSimulacion();
        }

        public void ProximaPatente(object patente)
        {
            Thread hiloPatente = new Thread(Patentes.MostrarPatente());
        }

        private void btnXml_Click(object sender, EventArgs e)
        {
            Xml<Queue<Patente>> colaXml = new Xml<Queue<Patente>>();

            colaXml.Guardar("patentes.xml", cola);
        }

        private void btnTxt_Click(object sender, EventArgs e)
        {
            Texto colaTexto = new Texto();

            colaTexto.Guardar("patentes.txt", cola);
        }

        private void btnSql_Click(object sender, EventArgs e)
        {
            Sql colaSql = new Sql();

            colaSql.Guardar("patentes.bak", cola);
        }

        public void IniciarSimulacion()
        {
            this.FinalizarSimulacion();
            this.vistaPatente1.
            this.vistaPatente2
        }

        private void FinalizarSimulacion()
        {
            foreach(Thread hilo in this.hilos)
            {
                if(hilo.IsAlive)
                {
                    hilo.Abort();
                }
            }
        }
    }
}
