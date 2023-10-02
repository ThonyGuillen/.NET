using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace programa13_Multiplicación_de_2_Numeros
{
    class Program
    {
        public int Multi(int a, int b)
        {
            if (b == 1)
            {
                return a;
            }
            else
            {
                return a + Multi(a, b - 1);
            }
        }

        static void Main(string[] args)
        {
            var tiempo = new Stopwatch();
            tiempo.Start();

            long Memoria, Memoriaa, Memoriaaa;
            Memoria = GC.GetTotalMemory(true);

            //variables auxiliares
            int opc;
            //menu de opciones
            do
            {
                Console.WriteLine("MULTIPLICACION");
                Console.WriteLine("1. Calcular Multiplicación..");
                Console.WriteLine("2. Salir del programa.");
                Console.Write("\nOpción: ");
                opc = Int16.Parse(Console.ReadLine());
                switch (opc)
                {
                    case 1:
                        Console.Clear();
                        Console.Write("Ingrese el primer valor: ");
                        int a = Int32.Parse(Console.ReadLine());
                        Console.Write("Ingrese el segundo valor ");
                        int b = Int32.Parse(Console.ReadLine());
                        Program p = new Program();
                        Console.WriteLine("Resultado: " + p.Multi(a, b));
                        Console.WriteLine("Presione una tecla para continuar . . . ");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    //Salída del Programa
                    case 2:
                        break;
                }
            }
            while (opc != 2);

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
    }
}