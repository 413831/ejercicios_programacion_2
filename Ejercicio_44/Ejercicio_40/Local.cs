using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
  public class Local : Llamada
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
  }
}
