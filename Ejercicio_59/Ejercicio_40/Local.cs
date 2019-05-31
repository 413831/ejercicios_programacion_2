using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Local : Llamada, IGuardar<Local>
    {
        protected float costoLlamada;

        #region Propiedades

        public override float CostoLlamada
        {
            get
            {
                return this.CalcularCosto();
            }
        }

        public string RutaArchivo { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        #endregion

        #region Métodos

        private float CalcularCosto()
        {
            return this.costoLlamada * this.Duracion;
        }

        public Local(Llamada llamada, float costo) : this(llamada.NroOrigen, llamada.Duracion, llamada.NroDestino, costo)
        {

        }

        public Local(string origen, float duracion, string destino, float costo)
        {
            this.duracion = duracion;
            this.nroDestino = destino;
            this.nroOrigen = origen;
            this.costoLlamada = costo;
        }

        protected override string Mostrar()
        {
            StringBuilder datos = new StringBuilder("");

            datos.AppendLine(base.Mostrar());
            datos.AppendFormat("Costo de llamada: ${0}", this.CostoLlamada.ToString());

            return datos.ToString();
        }

        #endregion

        public override bool Equals(object obj)
        {
            if (obj != null && obj is Local)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            return this.Mostrar();
        }

        /*
         * a. Los métodos de la implementación de IGuardar en Local deberán obtener los datos de un
        archivo dado, comprobar que estos sean del tipo Local y retornar un nuevo objeto de este
        tipo. En caso de que no sea del tipo Local, lanzará la excepción InvalidCastException.
        b. Los métodos de la implementación de IGuardar en Provincial deberán guardar y obtener los
        datos de un archivo dado, comprobar que estos sean del tipo Provincial y retornar un nuevo
        objeto de este tipo. En caso 
         */

        public bool Guardar()
        {
            throw new NotImplementedException();
        }

        public Local Leer()
        {
            throw new NotImplementedException();
        }
    }
}
