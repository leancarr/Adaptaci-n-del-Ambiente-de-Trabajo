using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej2
{
    internal class Cronometro
    {
        public int Segundos { get; set; }
        public int Minutos { get; set; }

        public void Reiniciar()
        {
            Segundos = 0;
            Minutos = 0;
        }
        public void PasaraMins()
        {
            if (Segundos == 60)
            {
                Minutos++;
                Segundos = 0;
            }
        }
        public void IncrementarTiempo()
        {
            Segundos++;
            PasaraMins();
        }
        public void MostrarTiempo()
        {
            Console.WriteLine($"Tiempo: {Minutos} minutos y {Segundos} segundos");
        }
    }
}
