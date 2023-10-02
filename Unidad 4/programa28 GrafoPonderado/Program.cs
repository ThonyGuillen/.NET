using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace programa28_GrafoPonderado
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
            public Grafo(int nodos)
            {
                this.nodos = nodos;
                mAdyacencia = new int[nodos, nodos];
                vertices = new char[] { 'A', 'B', 'C', 'D', 'E' };
            }
            //métodos de la clase
            public void añadirPeso(int nodoInicio, int nodoFinal, int peso)
            {
                mAdyacencia[nodoInicio, nodoFinal] = peso;
            }
            
            public void muestraMatrizAdyacencia()
            {
                //desplegar la matriz de adyacencia
                //incluyendo nombre de los vertices y pesos
                Console.Write("  ");
                for (int x = 0; x < vertices.Length; x++) Console.Write("{0,-4}", vertices[x]);
                Console.WriteLine();
                for(int x = 0; x < nodos; x++)
                {
                    Console.Write("{0} ", vertices[x]);
                    for (int y = 0; y < vertices.Length; y++) Console.Write("{0,-4}", mAdyacencia[x,y]);
                    Console.WriteLine();
                }
            }
            //destructor de la clase
            ~Grafo()
            {
                Console.WriteLine("Clase Grafo Ponderado Liberada");
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
                Console.WriteLine("MENU GRAFO\n" +
                                  "\na) Creación del Grafo." +
                                  "\nb) Añadir Peso a las Aristas." +
                                  "\nc) Despliegue de Matriz de Adyacencia." +
                                  "\nd) Salir del Programa.");
                Console.Write("\nOpcion: ");
                opcion = Console.ReadLine();
                switch (opcion)
                {
                    case "a":
                    case "A":
                        grafo = new Grafo(5);
                        Console.Clear();
                        Console.WriteLine("Grafo creado con exito");
                        Console.WriteLine("Presione ENTER para continuar");
                        Console.ReadKey();
                        break;

                    case "b":
                    case "B":
                        grafo.añadirPeso(0, 1, 12);
                        grafo.añadirPeso(0, 3, 87);
                        grafo.añadirPeso(1, 4, 11);
                        grafo.añadirPeso(2, 0, 19);
                        grafo.añadirPeso(3, 1, 23);
                        grafo.añadirPeso(3, 2, 10);
                        grafo.añadirPeso(4, 3, 43);
                        Console.WriteLine("Aristas creadas con exito");
                        Console.WriteLine("\nPresione ENTER para continuar");
                        Console.ReadKey();
                        break;

                    case "c":
                    case "C":
                        Console.Clear();
                        Console.WriteLine("Despliegue de la Matriz Adyacente");
                        grafo.muestraMatrizAdyacencia();
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