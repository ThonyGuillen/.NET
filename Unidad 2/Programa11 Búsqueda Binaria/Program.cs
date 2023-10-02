using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa11_Búsqueda_Binaria
{
    class Program
    {
        public int BusquedaBinaria(int[] arreglo, int low, int high, int num)//tres parametros, arreglo, numero a buscar, posicion del arreglo
        {
            if (low > high) //Condicion para que el indice no exceda el tamaño del arreglo
            {
                return -1;
            }

            int mid = (low + high) / 2;

            if (num == arreglo[mid])
            {
                return mid;
            }
            if (num < arreglo[mid])
            {
                return BusquedaBinaria(arreglo, low, mid - 1, num);
            }
            else
            {
                return BusquedaBinaria(arreglo, mid + 1, high, num);
            }
        }
        static void Main(string[] args)
        {
            var tiempo = new Stopwatch();
            tiempo.Start();

            long Memoria, Memoriaa, Memoriaaa;
            Memoria = GC.GetTotalMemory(true);

            int opc;
            int[] arreglo = new int[10];
            Program BI = new Program();
            do
            {
                Console.WriteLine("1.-Generar un Arreglo de 10 numeros." +
                              "\n2.-Buscar un Elemento en particular." +
                              "\n3.-Salir del programa.");
                Console.Write("Opcion: ");
                opc = Convert.ToInt32(Console.ReadLine());

                switch (opc)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Generando y Desplegando Arreglo...");
                        Random aleatorio = new Random();

                        for (int i = 0; i < 10; i++)
                        {
                            arreglo[i] = aleatorio.Next(1, 40);
                        }
                        Array.Sort(arreglo);
                        for (int i = 0; i < 10; i++)
                        {
                            Console.WriteLine("El arreglo es " + arreglo[i]);
                        }
                        Console.WriteLine("\nIngrese cualquier tecla para continuar:");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 2:
                        Console.Clear();
                        Console.Write("Ingrese el numero a buscar: ");
                        int num = Convert.ToInt32(Console.ReadLine());
                        var numero = BI.BusquedaBinaria(arreglo, 0, 10, num) + 1;

                        for (int i = 0; i < 10; i++)
                        {
                            Console.WriteLine("El arreglo es " + arreglo[i]);
                        }

                        Console.WriteLine("Numero encontrado en la posicion del arreglo numero: " + numero);
                        Console.WriteLine("\nIngrese cualquier tecla para continuar:");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    //Salida del programa
                    case 3:
                        break;

                    default:
                        Console.WriteLine("\nIntroduzca una opcion valida");
                        Console.WriteLine("\nPresione una tecla para continuar. . . ");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            } while (opc != 3);
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