using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace programa31_Algoritmo_de_Dijkstra
{
    class Program
    {
        class Grafo
        {
            //campos de la clase
            string[] vertices;
            int[,] mAdyacencia;
            int[,] tabla;
            //variables auxiliares
            int nodos, distancia, actual, columna;
            //constructor de la clase
            public Grafo(int nodos)
            {
                this.nodos = nodos;
                mAdyacencia = new int[nodos, nodos];
                vertices = new string[] { "Ciudad de México", "Cuernavaca", "Puebla", "Toluca", "Tlaxcala" };
                tabla = new int[nodos, 3];
            }
            //métodos de la clase
            public void crearAristaPeso(int nodoInicio, int nodoFinal, int peso)
            { mAdyacencia[nodoInicio, nodoFinal] = peso; }
            public void muestraMatrizAdyacencia()
            {
                //desplegar la matriz incluyendo nombre de los vertices 
                Console.Write("              ");
                for (int x = 0; x < vertices.Length; x++) Console.Write("     {0,-4}", vertices[x]);
                Console.WriteLine();
                for (int x = 0; x < nodos; x++)
                {
                    Console.Write("{0}  ", vertices[x]);
                    for (int y = 0; y < vertices.Length; y++) Console.Write("         {0,-4}    ", mAdyacencia[x, y]);
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
                //codigo en video 
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

            Grafo grafo = new Grafo(5);
            int inicio = 0;
            int final = 5;
            string opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("MENU Algoritmo de Dijkstra\n" +
                                  "\na) Añadir Aristas con Peso al Grafo." +
                                  "\nb) Desplegar la Matriz de Adyacencia." +
                                  "\nc) Crear y Desplegar Tabla Distancia entre Nodos." +
                                  "\nd) Calcular Ruta Camino Más Corto Menor Costo." +
                                  "\ne) Salir del Programa.");
                Console.Write("\nOpcion: ");
                opcion = Console.ReadLine();
                switch (opcion)
                {
                    case "a":
                    case "A":
                        Console.Clear();
                        grafo.crearAristaPeso(0, 3, 100);
                        grafo.crearAristaPeso(3, 0, 100);
                        grafo.crearAristaPeso(0, 1, 90);
                        grafo.crearAristaPeso(1, 0, 90);
                        grafo.crearAristaPeso(3, 1, 150);
                        grafo.crearAristaPeso(1, 2, 100);
                        grafo.crearAristaPeso(3, 4, 340);
                        grafo.crearAristaPeso(3, 2, 350);
                        grafo.crearAristaPeso(2, 3, 350);
                        grafo.crearAristaPeso(2, 4, 20);

                        Console.WriteLine("Aristas creadas con exito");
                        Console.WriteLine("\nPresione ENTER para continuar");
                        Console.ReadKey();
                        break;

                    case "b":
                    case "B":
                        Console.Clear();
                        grafo.muestraMatrizAdyacencia();
                        Console.WriteLine("\nPresione <Enter> para continuar.");
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
                        Console.WriteLine("RUTA");
                        Console.WriteLine("Nodo inicial: {0}", inicio);
                        Console.Write("Nodo final: {0}\n", final);

                        grafo.rutaCaminoMasCorto(inicio, final);
                        Console.WriteLine("\nPresione <Enter> para continuar.");
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