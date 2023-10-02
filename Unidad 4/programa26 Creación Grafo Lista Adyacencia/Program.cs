using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace programa26_Creación_Grafo_Lista_Adyacencia
{
    class Program
    {
        class Grafo
        {
            //campos de la clase
            public char vertice;
            public List<Grafo> Aristas;
            //constructor de la clase
            public Grafo(char vertice)
            {
                this.vertice = vertice;
                //creación lista de adyacencia
                Aristas = new List<Grafo>();
            }
            //métodos de la clase
            public void crearArista(Grafo g1, Grafo g2)
            {
                g1.Aristas.Add(g2);
            }
            public void muestraListaAdyacencia(Grafo g, string sangria = "")
            {
                //desplegar la lista de adyacencia
                if(g != null)
                {
                    Console.WriteLine(sangria + g.vertice);
                    foreach (var n in g.Aristas)
                    {
                        muestraListaAdyacencia(n, sangria + "\t");
                    }
                }
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

            Grafo verticeA = new Grafo('A');
            Grafo verticeB = new Grafo('B');
            Grafo verticeC = new Grafo('C');
            Grafo verticeD = new Grafo('D');

            string opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("MENU GRAFO\n" +
                                  "\na) Creación de Aristas." +
                                  "\nb) Despliegue de Lista de Adyacencia." +
                                  "\nc) Salir del Programa.");
                Console.Write("\nOpcion: ");
                opcion = Console.ReadLine();
                switch (opcion)
                {
                    case "a":
                    case "A":
                        Console.Clear();
                        verticeA.crearArista(verticeA, verticeB);
                        verticeA.crearArista(verticeA, verticeC);
                        verticeB.crearArista(verticeB, verticeC);
                        verticeB.crearArista(verticeB, verticeD);
                        verticeC.crearArista(verticeC, verticeD);
                        Console.WriteLine("Creacion de arista realizada con exito");
                        Console.WriteLine("Presione ENTER para continuar");
                        Console.ReadKey();
                        break;

                    case "b":
                    case "B":
                        Console.Clear();
                        verticeA.muestraListaAdyacencia(verticeA);
                        Console.WriteLine("Presione ENTER para continuar");
                        Console.ReadKey();
                        break;

                    //Salida del programa
                    case "c":
                    case "C":
                        Console.WriteLine("Saliendo del programa...");
                        Console.ReadKey();
                        break;

                    default:
                        Console.WriteLine("\nIngrese una opcion valida");
                        Console.ReadKey();
                        break;
                }
            } while (opcion != "c" && opcion != "C");

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