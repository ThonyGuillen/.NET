using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa27_Creación_Grafo_Matriz_Adyacencia
{
    class Program
    {
        class Grafo
        {
            //campos de la clase
            char[] vertices;
            int[,] mAdyacencia;
            int nodos;
            //constructor de la clase
            public Grafo(int numNodos)
            {
                nodos = numNodos;
                //creación matriz de adyacencia
                mAdyacencia = new int[nodos, nodos];
                vertices = new char[] {'A', 'B', 'C', 'D', 'E' };
            }
            //métodos de la clase
            public void crearArista(int nodoInicio, int nodoFinal)
            {
                mAdyacencia[nodoInicio, nodoFinal] = 1;
            }
            public void muestraMatrizAdyacencia()
            {
                for (int r = 0; r < nodos; r++)
                {
                    Console.Write("  " + vertices[r]);                   
                }
                Console.WriteLine();
                for (int i = 0; i < nodos; i++)
                {
                    Console.Write(vertices[i]);
                    for (int x = 0; x < nodos; x++)
                    {
                        Console.Write(" {0} ", mAdyacencia[i, x]);
                    }
                    Console.WriteLine();
                }
                //desplegar la matriz

            }
            //destructor de la clase
            ~Grafo()
            {
                Console.WriteLine("Clase Grafo Matriz Adyacencua Liberada");
            }
        }
        static void Main(string[] args)
        {
            var tiempo = new Stopwatch();
            tiempo.Start();

            long Memoria, Memoriaa, Memoriaaa;
            Memoria = GC.GetTotalMemory(true);

            Grafo grafo = null;
            string opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("MENU GRAFO MATRIZ\n" +
                                  "\na) Creación del Grafo.." +
                                  "\nb) Añadir Aristas al Grafo." +
                                  "\nc) Desplegar la Matriz de Adyacencia." +
                                  "\nd) Salir del Programa.");
                Console.Write("\nOpcion: ");
                opcion = Console.ReadLine();
                switch (opcion)
                {
                    case "a":
                    case "A":
                        grafo = new Grafo(5);
                        Console.Clear();
                        Console.WriteLine("El grafo se ha creado con exito");
                        Console.WriteLine("Presione ENTER para continuar");
                        Console.ReadKey();
                        break;

                    case "b":
                    case "B":
                        Console.Clear();
                        grafo.crearArista(0, 1);
                        grafo.crearArista(0, 4);
                        grafo.crearArista(1, 2);
                        grafo.crearArista(1, 3);
                        grafo.crearArista(2, 3);
                        grafo.crearArista(3, 0);
                        Console.WriteLine("Aristas añadidas al grafo");
                        Console.WriteLine("Presione ENTER para continuar");
                        Console.ReadKey();
                        break;

                    case "c":
                    case "C":
                        Console.Clear();
                        Console.WriteLine("Despliegue de la Matriz Adyacente");
                        grafo.muestraMatrizAdyacencia();
                        Console.WriteLine("\nPresione ENTER para continuar");
                        Console.ReadKey();
                        break;

                    //Salida del programa
                    case "d":
                    case "D":
                        Console.WriteLine("Saliendo del programa...");
                        Console.ReadKey();

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
                        break;

                    default:
                        Console.WriteLine("\nIngrese una opcion valida");
                        Console.ReadKey();
                        break;
                }
            } while (opcion != "d" && opcion != "D");          
        }
    }
}