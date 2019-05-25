using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_36
{
    public class MotoCross : VehiculoCarrera
    {
        private short cilindrada;

        #region Constructores

        public MotoCross(short numero,string escuderia) : base(numero,escuderia)
        {
            this.EnCompetencia = false;
            this.CantidadCombustible = 0;
            this.VueltasRestantes = 0;
        }

        public MotoCross(short numero,string escuderia, short cilindrada) : this(numero,escuderia)
        {
            this.Cilindrada = cilindrada;
        }

        #endregion

        #region Propiedades

        public short Cilindrada
        {
            get
            {
                return this.cilindrada;
            }
            set
            {   
                this.cilindrada = value;
            }
        }

        #endregion

        #region Métodos

        public new string MostrarDatos()
        {
            String datosAuto = "";

            datosAuto += "\n" + base.MostrarDatos();
            datosAuto += "\n" + this.Cilindrada.ToString(); 

            return datosAuto;
        }

        #endregion
        //CORREGIR SOBRECARGA DE OPERADORES SEGUN ENUNCIADO
        public static bool operator !=(MotoCross motoUno, MotoCross motoDos)
        {
            return !(motoUno == motoDos);
        }
        public static bool operator ==(MotoCross motoUno, MotoCross motoDos)
        {
            if(motoUno == motoDos && motoUno.Cilindrada == motoDos.Cilindrada)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //
        //OVERRIDE EQUALS
        //
        public override bool Equals(object obj)
        {
            if (obj != null || this.GetType() != obj.GetType())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return Tuple.Create(cilindrada).GetHashCode();
        }
    }
}