using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_36
{
    public class AutoF1 : VehiculoCarrera
    {
        private short caballosDeFuerza;

        #region Constructores

        public AutoF1(short numero,string escuderia) : base(numero,escuderia)
        {
            this.EnCompetencia = false;
            this.CantidadCombustible = 0;
            this.VueltasRestantes = 0;
        }

        public AutoF1(short numero,string escuderia, short caballosDeFuerza) : this(numero,escuderia)
        {
            this.CaballosDeFuerza = caballosDeFuerza;
        }

        #endregion

        #region Propiedades

        public short CaballosDeFuerza
        {
            get
            {
                return this.caballosDeFuerza;
            }
            set
            {   
                this.caballosDeFuerza = value;
            }
        }

        #endregion

        #region Métodos

        public new string MostrarDatos()
        {
            String datosAuto = "";

            datosAuto += "\n" + base.MostrarDatos();
            datosAuto += "\n" + this.CaballosDeFuerza.ToString(); 

            return datosAuto;
        }

        #endregion
        //CORREGIR SOBRECARGA DE OPERADORES SEGUN ENUNCIADO
        public static bool operator !=(AutoF1 autoUno, AutoF1 autoDos)
        {
            return !(autoUno == autoDos);
        }
        public static bool operator ==(AutoF1 autoUno, AutoF1 autoDos)
        {
            if(autoUno == autoDos && autoUno.CaballosDeFuerza == autoDos.CaballosDeFuerza)
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
            return Tuple.Create(caballosDeFuerza).GetHashCode();
        }
    }
}