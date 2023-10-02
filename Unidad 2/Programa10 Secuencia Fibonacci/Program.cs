using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa10_Secuencia_Fibonacci
{
    class Program
    {
        static int Fibo(int n)
        {
            if (n == 1 || n == 0)
                return n;
            else
                return Fibo(n - 1) + Fibo(n - 2);
        }
        static void Main(string[] args)
        {
            var tiempo = new Stopwatch();
            tiempo.Start();

            long Memoria, Memoriaa, Memoriaaa;
            Memoria = GC.GetTotalMemory(true);

            int num;
            int Opc;

            do
            {
                Console.WriteLine("MENU FIBONACCI");
                Console.WriteLine("(1) Calcular serie");
                Console.WriteLine("(2) Salir del programa");
                Console.Write("Opción: ");
                Opc = Int32.Parse(Console.ReadLine());
                switch (Opc)
                {
                    case 1:
                        Console.Clear();
                        Console.Write("Ingresa la cantidad de numeros: ");
                        num = int.Parse(Console.ReadLine());
                        for (int i = 0; i <= num - 1; i++)
                            Console.WriteLine("Fibonacci: " + (i + 1) + " es: " + Fibo(i) + ("\n"));

                        Console.WriteLine("\nPresione cualquier tecla para continuar...");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 2:
                        //Salida del programa
                        break;

                    default:
                        Console.WriteLine("\nIntroduzca una opcion valida");
                        Console.WriteLine("\nPresione una tecla para continuar. . . ");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            } while (Opc != 2);
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