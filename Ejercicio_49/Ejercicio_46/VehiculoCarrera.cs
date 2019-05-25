using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_36
{
	public class VehiculoCarrera
	{
		protected short cantidadCombustible;
		protected bool enCompetencia;
		protected string escuderia;
		protected short numero;
		protected short vueltasRestantes;

		#region Constructores

		public VehiculoCarrera(short numero, string escuderia)
		{
			this.Numero = numero;
			this.Escuderia = escuderia;
		}

		#endregion

		#region Propiedades

		public short CantidadCombustible
		{
			get
			{
				return this.cantidadCombustible;
			}
			set
			{
				this.cantidadCombustible = value;
			}
		}

		public bool EnCompetencia
		{
			get
			{
				return this.enCompetencia;
			}
			set
			{
				this.enCompetencia = value;
			}
		}

		public string Escuderia
		{
			get
			{
				return this.escuderia;
			}
			set
			{
				this.escuderia = value;
			}
		}

		public short Numero
		{
			get
			{
				return this.numero;
			}
			set
			{
				this.numero = value;
			}
		}

		public short VueltasRestantes
		{
			get
			{
				return this.vueltasRestantes;
			}
			set
			{
				this.vueltasRestantes = value;
			}
		}

		#endregion

		#region Métodos

		public string MostrarDatos()
		{
			string datos = "";

			datos += "\n" + this.Numero.ToString();
			datos += "\n" + this.Escuderia.ToString();
			datos += "\n" + this.CantidadCombustible.ToString();
			datos += "\n" + this.EnCompetencia.ToString();
			datos += "\n" + this.VueltasRestantes.ToString();

			return datos;
		}

		#endregion

		public static bool operator !=(VehiculoCarrera vehiculoUno, VehiculoCarrera vehiculoDos)
        {
            return !(vehiculoUno == vehiculoDos);
        }
        public static bool operator ==(VehiculoCarrera vehiculoUno, VehiculoCarrera vehiculoDos)
        {
            if(vehiculoUno.Numero == vehiculoDos.Numero && vehiculoUno.Escuderia == vehiculoDos.Escuderia)
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
            return Tuple.Create(cantidadCombustible, enCompetencia, escuderia, numero, vueltasRestantes).GetHashCode();
        }	
	}
}