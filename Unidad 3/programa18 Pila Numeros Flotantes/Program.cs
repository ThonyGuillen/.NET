using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace programa18_Pila_Numeros_Flotantes
{
    class Program
    {
        public class Pilas
        {
            int Max, Top, Apuntador;
            public float[] Pila;

            public Pilas(int tamaño)
            {
                Max = tamaño;
                Top = -1;
                Pila = new float[tamaño];
                Console.WriteLine("La pila ha sido creada con exito.");
                Console.WriteLine("Presione <Enter> para continuar.");
                Console.ReadKey();
                return;
            }
            //métodos de la clase
            public void Push(float elemento)
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
            public void Pop()
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
            public void Recorrido()
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
            public void Busqueda(float elemento)
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
            string opcion;

            do
            {
                Console.Clear();
                Console.WriteLine("PILA NUMEROS FLOTANTES" +
                                "\na)Crear Pila" +
                                "\nb)Insertar un elemento" +
                                "\nc)Eliminar un dato" +
                                "\nd)Recorrer la pila" +
                                "\ne)Buscar un elemento" +
                                "\nf)Salir del programa");
                Console.Write("Opcion: ");
                opcion = Console.ReadLine();
                switch (opcion)
                {
                    case "a":
                    case "A":
                        Console.Clear();
                        try
                        {
                            int T;
                            Console.Write("Favor de ingresas el tamaño de la pila: ");
                            T = Convert.ToInt32(Console.ReadLine());
                            P = new Pilas(T);
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Favor de solo ingresar numeros");
                            Console.Clear();
                        }
                        break;

                    case "b":
                    case "B":
                        Console.Clear();
                        if (P != null)
                        {
                            float e;
                            Console.Write("Ingrese El elemento que desea agregar a la pila: ");
                            e = float.Parse(Console.ReadLine());
                            P.Push(e);
                        }
                        else
                        {
                            Console.WriteLine("Favor de crear tu pila Primero");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        break;

                    case "c":
                    case "C":
                        Console.Clear();
                        P.Pop();
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case "d":
                    case "D":
                        Console.Clear();
                        P.Recorrido();
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case "e":
                    case "E":
                        Console.Clear();
                        Console.Write("Ingresa el numero a buscar: ");
                        float n = float.Parse(Console.ReadLine());
                        P.Busqueda(n);
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    //Salida del programa
                    case "f":
                    case "F":
                        break;

                    default:
                        Console.WriteLine("\nIntroduzca una opcion valida");
                        Console.WriteLine("\nPresione una tecla para continuar. . . ");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            } while (opcion != "f");

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