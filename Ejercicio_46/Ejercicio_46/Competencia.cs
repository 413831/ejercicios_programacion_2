using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_36
{
    public enum TipoCompetencia
    {
        F1,
        MotoCross,
    }

    public class Competencia
    {
        private short cantidadCompetidores;
        private short cantidadVueltas;
        private List<VehiculoCarrera> competidores;
        private TipoCompetencia tipo;

        #region Constructores

        private Competencia()
        {
            competidores = new List<VehiculoCarrera>();
        }
        public Competencia(short cantidadVueltas, short cantidadCompetidores, TipoCompetencia tipo) : this()
        {
            this.cantidadVueltas = cantidadVueltas;
            this.cantidadCompetidores = cantidadCompetidores;
            this.tipo = tipo;
        }

        #endregion

        #region Propiedades

        public short CantidadCompetidores
        {
            get
            {
                return this.cantidadCompetidores;
            }
            set
            {
                this.cantidadCompetidores = value;
            }
        }

        public short CantidadVueltas
        {
            get
            {
                return this.cantidadVueltas;
            }
            set
            {
                this.cantidadVueltas = value;
            }
        }

        public TipoCompetencia Tipo
        {
            get
            {
                return this.tipo;
            }
            set
            {
                this.tipo = value;
            }
        }

        public VehiculoCarrera this[int i] //TESTEAR
        {
            get
            {
                if (i < this.competidores.Count)
                {
                    return competidores[i];
                }
                else
                {
                    return null;
                }
            }
        }

        public List<VehiculoCarrera> ListaVehiculos
        {
            get
            {
                return this.competidores;
            }
        }

        #endregion

        #region Métodos

        public string MostrarDatos()
        {
            string datos = "";
            datos += "\n" + this.CantidadCompetidores.ToString();
            datos += "\n" + this.CantidadVueltas.ToString();
            datos += "\n" + this.Tipo.ToString();
        
            foreach (VehiculoCarrera vehiculo in this.competidores)
            {
                datos += "\nCOMPETIDORES\n" + vehiculo.MostrarDatos(); 
            }
            return datos;
        }

        #endregion

        #region Operadores

        public static bool operator -(Competencia competencia, VehiculoCarrera vehiculo)
        {
            if (competencia == vehiculo)
            {
                competencia.competidores.Remove(vehiculo);
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator +(Competencia competencia, VehiculoCarrera vehiculo)
        {   
            Random numeroRandom = new Random();
            try
            {
                if(competencia != vehiculo && competencia.competidores.Count < competencia.CantidadCompetidores)
                {
                    vehiculo.EnCompetencia = true;
                    vehiculo.VueltasRestantes = competencia.CantidadVueltas;
                    vehiculo.CantidadCombustible = (short)numeroRandom.Next(15,100);;
                    competencia.competidores.Add(vehiculo);
                    return true;
                }
            }
            catch(CompetenciaNoDisponibleException exception)
            {
                throw new CompetenciaNoDisponibleException("Competencia incorrecta", typeof(Competencia).ToString(), "Operador +", exception);
            }
            return false;
        }

        public static bool operator ==(Competencia competencia, VehiculoCarrera vehiculo)
        {
            bool returnValue = false;

            //TESTEAR
            if(competencia.Tipo == TipoCompetencia.F1 && vehiculo is AutoF1 || 
                competencia.Tipo == TipoCompetencia.MotoCross && vehiculo is MotoCross)
            {
                foreach (VehiculoCarrera auxiliar in competencia.competidores)
                {
                    if (auxiliar == vehiculo)
                    {
                        returnValue = true;
                        break;
                    }
                }
            }
            else
            {
                throw new CompetenciaNoDisponibleException("El vehiculo no corresponde a la competencia", typeof(Competencia).ToString(), "Operador ==");
            }
            return returnValue;
        }
        public static bool operator !=(Competencia competencia, VehiculoCarrera vehiculo)
        {
            return !(competencia == vehiculo);
        }

        #endregion

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
            return Tuple.Create(cantidadCompetidores, cantidadVueltas, competidores, tipo).GetHashCode();
        }

    }
}