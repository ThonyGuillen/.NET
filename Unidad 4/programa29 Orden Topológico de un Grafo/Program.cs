using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace programa29_Orden_Topológico_de_un_Grafo
{
    class Program
    {
        class Grafo
        {
            //campos de la clase
            char[] vertices;
            int[,] mAdyacencia;
            int[] indegree;
            int nodos;
            //constructor de la clase
            public Grafo(int nodos)
            {
                this.nodos = nodos;
                mAdyacencia = new int[nodos, nodos];
                indegree = new int[nodos];
                vertices = new char[] { 'A', 'B', 'C', 'D' };
            }
            //métodos de la clase
            public void crearArista(int nodoInicio, int nodoFinal)
            {
                mAdyacencia[nodoInicio, nodoFinal] = 1;
            }
            public void muestraMatrizAdyacencia()
            {
                //desplegar la matriz incluyendo nombre de los vertices 
                Console.Write("  ");
                for (int x = 0; x < vertices.Length; x++) Console.Write("{0,-4}", vertices[x]);
                Console.WriteLine();
                for (int x = 0; x < nodos; x++)
                {
                    Console.Write("{0} ", vertices[x]);
                    for (int y = 0; y < vertices.Length; y++) Console.Write("{0,-4}", mAdyacencia[x, y]);
                    Console.WriteLine();
                }
            }
            public void calcularIndegree()
            {
                //codigo en video 
                for (int x = 0; x < nodos; x++)
                    for (int y = 0; y < nodos; y++)
                        if (mAdyacencia[y, x] == 1) indegree[x]++;
            }
            public void muestraIndegree()
            {
                //codigo en video 
                for (int x = 0; x < indegree.Length; x++)
                    Console.WriteLine("Nodo:{0},{1}", x, indegree[x]);
            }
            public int encuentraIndegree0()
            {
                //codigo en video 
                for (int x = 0; x < indegree.Length; x++)
                    if (indegree[x] == 0) return x;
                return -1;//Codigo que indica que no se ah encontrado
            }
            public void decrementaIndegree(int nodo)
            {
                //codigo en video 
                indegree[nodo] = -1;
                for (int x = 0; x < nodos; x++)
                    if (mAdyacencia[nodo, x] == 1) indegree[x]--;
            }
            public void ordenamientoTopológico()
            {
                //codigo en video 
                int nodo = 0;
                do
                {
                    nodo = encuentraIndegree0();
                    if (nodo != -1)
                    {
                        Console.Write("{0}-->", nodo);
                        decrementaIndegree(nodo);
                    }
                } while (nodo != -1);
                Console.WriteLine();
            }
            //destructor de la clase
            ~Grafo()
            {
                Console.WriteLine("Clase Grafo Orden Topológico Liberada");
            }
        }
        static void Main(string[] args)
        {
            var tiempo = new Stopwatch();
            tiempo.Start();

            long Memoria, Memoriaa, Memoriaaa;
            Memoria = GC.GetTotalMemory(true);

            Grafo grafo = new Grafo(4);

            string opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("MENU Orden Topológico\n" +
                                  "\na) Añadir Aristas al Grafo." +
                                  "\nb) Desplegar la Matriz de Adyacencia." +
                                  "\nc) Calcular y Desplegar el Indegree." +
                                  "\nd) Realizar Ordenamiento Topológico." +
                                  "\ne) Salir del Programa.");
                Console.Write("\nOpcion: ");
                opcion = Console.ReadLine();
                switch (opcion)
                {
                    case "a":
                    case "A":
                        
                        Console.Clear();
                        
                        grafo.crearArista(0, 1);
                        grafo.crearArista(1, 2);
                        grafo.crearArista(2, 3);
                        grafo.crearArista(0, 2);
                        grafo.crearArista(1, 3);    
                        Console.WriteLine("Presione ENTER para continuar");
                        Console.ReadKey();
                        break;

                    case "b":
                    case "B":
                        Console.Clear();
                        grafo.muestraMatrizAdyacencia();
                        Console.WriteLine("Presione ENTER para continuar");
                        Console.ReadKey();
                        break;

                    case "c":
                    case "C":
                        Console.Clear();
                        grafo.calcularIndegree();
                        grafo.muestraIndegree();
                        Console.WriteLine("Presione ENTER para continuar");
                        Console.ReadKey();
                        break;

                    case "d":
                    case "D":
                        Console.Clear();
                        grafo.ordenamientoTopológico();
                        Console.WriteLine("Presione ENTER para continuar");
                        Console.ReadKey();
                        break;

                    //Salida del programa
                    case "e":
                    case "E":
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
            } while (opcion != "e" && opcion != "E");
        }
    }
}