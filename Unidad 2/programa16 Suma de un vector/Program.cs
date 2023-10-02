using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace programa16_Suma_de_un_vector
{    
    class Program
    {
        static void Main(string[] args)
        {
            var tiempo = new Stopwatch();
            tiempo.Start();

            long Memoria, Memoriaa, Memoriaaa;
            Memoria = GC.GetTotalMemory(true);

            int suma = 0;
            string opc;
            int vec = 0;
            int[] arregloaux = new int[vec];
            Arreglo arreglo = new Arreglo();
            do
            {
                Console.WriteLine("MENU FACTORIAL" +
                                "\na) Generar Vector Aleatoriamente." +
                                "\nb) Sumar Vector." +
                                "\nc) Desplegar Vector y Suma." +
                                "\nd) Salir del programa.");
                Console.Write("Opción: ");
                opc = Console.ReadLine();
                switch (opc)
                {
                    case "a":
                    case "A":
                        Console.Clear();
                        Random aleatorio = new Random();
                        Console.Write("Ingrese el tamaño del vector: ");
                        vec = int.Parse(Console.ReadLine());
                        arregloaux = new int[vec];
                        for (int i = 0; i < arregloaux.Length; i++)
                        {
                            arregloaux[i] = aleatorio.Next(10, 99);
                        }
                        Console.Write("\nIngrese cualquier tecla para continuar: ");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    //Salída del Programa
                    case "b":
                    case "B":
                        Console.Clear();
                        suma = arreglo.suma(arregloaux, vec);
                        Console.WriteLine("Presione una tecla para continuar:");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case "c":
                    case "C":
                        Console.Clear();
                        for (int i = 0; i < arregloaux.Length; i++)
                        {
                            Console.WriteLine(arregloaux[i]);
                        }
                        Console.WriteLine("Suma del arreglo: " + suma);
                        Console.WriteLine("Presione una tecla para continuar:");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    //Salída del Programa
                    case "d":
                    case "D":
                        break;

                    default:
                        Console.WriteLine("Ingrese una opcion valida");
                        Console.WriteLine("Presione una tecla para continuar . . . ");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }
            while (opc != "d" && opc != "D");

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
    public class Arreglo
    {
        public int suma(int[] A, int N)
        {
            if (N <= 0)
                return 0;
            return (suma(A, N - 1) + A[N - 1]);
        }
    }
}