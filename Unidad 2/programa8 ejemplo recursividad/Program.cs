using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa8_recursividad
{
    class Program
    {
        public static void Main(string[] args)
        {
            var tiempo = new Stopwatch();
            tiempo.Start();

            long inicialmemoria, finalmemoria, totalmemoria;
            inicialmemoria = GC.GetTotalMemory(true);



            Console.WriteLine("Ingresa un numero: ");
            int numero = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\nA la potencia: ");
            int potencia = Convert.ToInt32(Console.ReadLine());

            Console.Write("\nEl resultado de " + numero + "^" + potencia + " es: ");
            Console.WriteLine(Potencia(numero, potencia));
            
            Console.ReadKey();
            Console.Clear();


            finalmemoria = GC.GetTotalMemory(true);
            totalmemoria = finalmemoria - inicialmemoria;
            Console.WriteLine("Memoria Inicial: " + inicialmemoria + " bytes");
            Console.WriteLine("Memoria Final: " + finalmemoria + " bytes");
            Console.WriteLine("Memoria Total: " + totalmemoria + " bytes");

            tiempo.Stop();
            Console.WriteLine("\nTiempo: " + tiempo.Elapsed.TotalSeconds + " segundos");

            Console.WriteLine("Presione una tecla para continuar . . .");
            Console.ReadKey();
        }

        public static int Potencia(int numero, int potencia)
        {
            if (potencia == 0)
            {
                return 1;
            }
            else
            {
                return numero * Potencia(numero, potencia - 1);
            }
        }
    }
}