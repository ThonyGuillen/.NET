using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace programa30_Camino_Más_Corto
{
    class Program
    {
        class Grafo
        {
            //campos de la clase
            char[] vertices;
            int[,] mAdyacencia;
            int[,] tabla;
            int nodos, distancia;
            //constructor de la clase
            public Grafo(int nodos)
            {
                this.nodos = nodos;
                mAdyacencia = new int[nodos, nodos];
                vertices = new char[] { 'A', 'B', 'C', 'D', 'E', 'F' };
                tabla = new int[nodos, 3];
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
            public int obtenAdyacencia(int fila, int columna)
            {
                //codigo en video 
                return mAdyacencia[fila, columna];
            }
            public void crearTabla(int inicio)
            {
                //codigo en video 
                for (int x = 0; x < nodos; x++)
                {
                    tabla[x, 0] = 0;
                    tabla[x, 1] = int.MaxValue;
                    tabla[x, 2] = 0;
                }
                tabla[inicio, 1] = 0;
            }
            public void mostrarTabla()
            {
                for (int x = 0; x < tabla.GetLength(0); x++)
                {
                    Console.WriteLine("{0}->{1}\t{2}\t{3}", x, tabla[x, 0], tabla[x, 1], tabla[x, 2]);
                }
                Console.WriteLine("--------");
            }
            public void rutaCaminoMasCorto(int inicio, int final)
            {
                //codigo en video 
                for (distancia = 0; distancia < nodos; distancia++)
                {
                    for (int n = 0; n < nodos; n++)
                    {
                        if ((tabla[n, 0] == 0) && (tabla[n, 1] == distancia))
                        {
                            tabla[n, 0] = 1;
                            for (int m = 0; m < nodos; m++)
                            {
                                if (obtenAdyacencia(n, m) == 1)
                                {
                                    if (tabla[m, 1] == int.MaxValue)
                                    {
                                        tabla[m, 1] = distancia + 1;
                                        tabla[m, 2] = n;
                                    }
                                }
                            }
                        }

                    }
                }
                mostrarTabla();

                List<int> ruta = new List<int>();
                int nodo = final;

                while (nodo != inicio)
                {
                    ruta.Add(nodo);
                    nodo = tabla[nodo, 2];
                }
                ruta.Add(inicio);

                ruta.Reverse();

                foreach (int posicion in ruta)
                {
                    Console.Write("{0}->", posicion);
                }
                Console.WriteLine();
            }
            //destructor de la clase
            ~Grafo()
            {
                Console.WriteLine("Clase Grafo Liberada");
            }
        }
        static void Main(string[] args)
        {
            var tiempo = new Stopwatch();
            tiempo.Start();

            long Memoria, Memoriaa, Memoriaaa;
            Memoria = GC.GetTotalMemory(true);

            int inicio = 0; 
            int final = 5;
            Grafo grafo = new Grafo(6);

            string opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("MENU CAMINO MAS CORTO\n" +
                                  "\na) Añadir Aristas al Grafo." +
                                  "\nb) Desplegar la Matriz de Adyacencia." +
                                  "\nc) Crear y Desplegar Tabla Distancia entre Nodos." +
                                  "\nd) Calcular Ruta Camino Más Corto." +
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
                        grafo.crearArista(2, 4);
                        grafo.crearArista(4, 5);
                        grafo.crearArista(4, 3);
                        grafo.crearArista(3, 1);
                        Console.WriteLine("Aristas creadas con exito");
                        Console.WriteLine("Presione ENTER para continuar");
                        Console.ReadKey();
                        break;

                    case "b":
                    case "B":
                        Console.Clear();
                        Console.WriteLine("Despliegue de la matriz adyacencia");
                        grafo.muestraMatrizAdyacencia();
                        Console.WriteLine("Presione ENTER para continuar");
                        Console.ReadKey();
                        break;

                    case "c":
                    case "C":
                        
                        Console.Clear();
                        Console.WriteLine("Creacion y despliegue de tabla de distancia entre nodos");                     
                        grafo.crearTabla(inicio);
                        grafo.mostrarTabla();
                        Console.WriteLine("Presione ENTER para continuar");
                        Console.ReadKey();
                        break;

                    case "d":
                    case "D":
                        Console.Clear();
                        Console.WriteLine("Calcular la ruta mas corta del grafo");                     
                        grafo.rutaCaminoMasCorto(inicio, final);
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