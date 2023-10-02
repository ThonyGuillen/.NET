using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuillenMartinez_U3
{
    class Program
    {
        public class Pilas
        {
            //campos de la clase
            int Max, Top, Apuntador;
            public float[] Pila;
            //constructor
            public Pilas(int tamaño)
            {
                Max = tamaño;
                Top = -1;
                Pila = new float[tamaño];
                Console.WriteLine("El tamaño de la pila es: " + tamaño);
                Console.WriteLine("La pila ha sido creada con exito.");
                Console.WriteLine("Presione <Enter> para continuar.");
                Console.ReadKey();
                return;
            }
            //métodos de la clase
            public void Push(float elemento)//metodo de insertar
            {
                if (Top != Max - 1)
                {
                    Top = Top + 1;
                    Pila[Top] = elemento;
                }
                else
                {
                    Console.WriteLine("La pila esta llena");
                    Console.ReadKey();
                }


            }
            public void Pop()//metodo de eliminar
            {
                if (Top != -1)
                {
                    Console.WriteLine("Dato a eliminar: " + Pila[Top]);
                    Pila[Top] = 0;
                    Top = Top - 1;
                }
                else
                {
                    Console.WriteLine("La pila esta vacia");
                    Console.ReadKey();
                }
            }
            public void Recorrido()//metodo de recorrido
            {
                if (Top != -1)
                {
                    Apuntador = Top;
                    while (Apuntador != -1)
                    {
                        Console.WriteLine("Elemento: {0}\tPosicion: {1}", Pila[Apuntador], Apuntador);
                        Apuntador = Apuntador - 1;
                    }
                }
                else
                {
                    Console.WriteLine("La pila Esta vacia");
                    Console.ReadKey();
                }
            }
            public void Busqueda(float elemento)//metodo buscar
            {
                if (Top != -1)
                {
                    Apuntador = Top;
                    while (Apuntador != -1)
                    {
                        if (Pila[Apuntador] == elemento)
                        {
                            Console.WriteLine("El dato: {0} fue encontrado en la posicion {1}", elemento, Apuntador);
                            return;
                        }
                        else
                        {
                            Apuntador = Apuntador - 1;
                        }
                    }
                    Console.WriteLine("El dato {0} no se encontro en la pila", elemento);
                }
                else
                {
                    Console.WriteLine("La pila esta vacia");
                    Console.ReadKey();
                }
            }
            //destructor de la clase
            ~Pilas()
            {
                Console.WriteLine("Clase Pilas Liberada");
            }
        }
        static void Main(string[] args)
        {
            var tiempo = new Stopwatch();
            tiempo.Start();

            long Memoria, Memoriaa, Memoriaaa;
            Memoria = GC.GetTotalMemory(true);

            Pilas P = null;
            int opcion;
            int[] arregloaux = new int[10];

            do
            {
                //menu de opciones
                Console.Clear();
                Console.WriteLine("PILA NUMEROS ENTEROS" +
                                "\n1)Crear Pila" +
                                "\n2)Insertar un elemento" +
                                "\n3)Eliminar un dato" +
                                "\n4)Recorrer la pila" +
                                "\n5)Buscar un elemento" +
                                "\n6)Salir del programa");
                Console.Write("Opcion: ");
                opcion = Int32.Parse(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        Console.Clear();
                        try
                        {
                            int T = 5;//tamaño 5 enviado como paramatero al constructor

                            P = new Pilas(T);
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Favor de solo ingresar numeros");
                            Console.Clear();
                        }
                        break;

                    case 2:
                        Console.Clear();
                        Random aleatorio = new Random();
                        Console.WriteLine("Numeros aleatorios.\n");
                        int a, i;

                        for (i = 1; i <= 5; i++)
                        {
                            a = aleatorio.Next(10, 99);
                            P.Push(a);
                            Console.WriteLine(a);
                        }
                        Console.WriteLine("\nPresione <Enter> para continuar.");
                        Console.ReadKey();
                        break;

                    case 3:
                        Console.Clear();
                        P.Pop();
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 4:
                        Console.Clear();
                        P.Recorrido();
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 5:
                        Console.Clear();
                        Console.Write("Ingresa el numero a buscar: ");
                        float n = float.Parse(Console.ReadLine());
                        P.Busqueda(n);
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    //Salida del programa
                    case 6:
                        break;

                    default:
                        Console.WriteLine("\nIntroduzca una opcion valida");
                        Console.WriteLine("\nPresione una tecla para continuar. . . ");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            } while (opcion != 6);

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