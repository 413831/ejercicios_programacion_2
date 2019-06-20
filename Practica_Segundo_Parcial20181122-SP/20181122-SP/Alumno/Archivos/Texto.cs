using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Entidades;

namespace Archivos
{
    public class Texto : IArchivo<Queue<Patente>>
    {
        public void Guardar(string archivo, Queue<Patente> datos)
        {
            StreamWriter escritor = new StreamWriter(archivo);

            foreach(Patente patente in datos)
            {
                escritor.Write(patente.CodigoPatente); // REVISAR
            }
            escritor.Close();
        }

        public void Leer(string archivo, out Queue<Patente> datos)
        {
            StreamReader lector = new StreamReader(archivo);
            datos = new Queue<Patente>();

            while(!lector.EndOfStream)
            {
                datos.Enqueue(lector.ReadLine().ValidarPatente()); // REVISAR
            }
        }

    }
}
