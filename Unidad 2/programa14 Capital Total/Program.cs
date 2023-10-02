using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace programa14_Capital_Total
{
    class Program
    {          
        static void Main(string[] args)
        {
            var tiempo = new Stopwatch();
            tiempo.Start();

            long Memoria, Memoriaa, Memoriaaa;
            Memoria = GC.GetTotalMemory(true);

            int m, a;
            int n, opc = 0;
            Capital capital = new Capital();

            do
            {
                Console.Clear();
                Console.WriteLine("CAPITAL TOTAL" +
                                    "\n1- Calcular." +
                                    "\n2- Salir del programa");
                Console.Write("Opcion: ");
                opc = int.Parse(Console.ReadLine());
                switch (opc)
                {
                    case 1:
                        Console.Clear();
                        Console.Write("Ingrese la cantidad de la inversion: ");
                        m = int.Parse(Console.ReadLine());
                        Console.Write("Ingrese el interes anual: ");
                        a = int.Parse(Console.ReadLine());
                        float floaux = Convert.ToSingle(a) / 100;
                        Console.Write("Ingrese la cantidad de años: ");
                        n = int.Parse(Console.ReadLine());
                        Console.WriteLine("Resultado: " + capital.CapitalTotal(m, floaux, n));
                        Console.WriteLine("Presione un tecla para continuar");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 2:
                        break;

                    default:
                        
                        Console.WriteLine("Ingrese una opcion valida");
                        Console.WriteLine("Ingrese cualquier tecla para continuar...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }           
            while (opc != 2) ;

            Console.Clear();
            tiempo.Stop();
            Memoriaa = GC.GetTotalMemory(true);
            Memoriaaa = Memoriaa - Memoria;

            Console.WriteLine("Memoria Inicial: " + Memoria + " bytes");
            Console.WriteLine("Memoria Final: " + Memoriaa + " bytes");
            Console.WriteLine("Memoria Total: " + Memoriaaa + " bytes");

            Console.WriteLine("\nEl tiempo fue de " + tiempo.Elapsed.TotalSeconds + " segundos");
            Console.WriteLine("\n\nPresione una tecla para continuar . . . ");
            Console.ReadKey();
        }
        public class Capital
        {
            public float CapitalTotal(float m, float x, int n)
            {
                if (n == 0)
                {
                    return m;
                }
                else
                {
                    return CapitalTotal(m, x, n - 1) + CapitalTotal(m, x, n - 1) * x; //Llamada recursiva
                }
            }
        }
    }
}