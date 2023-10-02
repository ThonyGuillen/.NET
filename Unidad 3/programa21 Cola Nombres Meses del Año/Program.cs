using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace programa21_Cola_Nombres_Meses_del_Año
{
    class Program
    {
        class Colas
        {
            //campos de la clase
            int Max, Frente, Final, Apuntador;
            string[] cola;
            //constructor
            public Colas(int tamaño)
            {
                Max = tamaño;
                Frente = -1;
                Final = -1;
                cola = new string[tamaño];
                Console.WriteLine("La cola ha sido creada con éxito.");
                Console.WriteLine("Presione <enter> para continuar.");
                Console.ReadKey();
            }
            //métodos de la clase
            public void Push(string elemento)
            {
                if (Frente == 0 && Final == Max - 1)
                {
                    Console.WriteLine("La Cola Esta Llena");
                    Console.ReadKey();
                }
                else
                {
                    if (Frente == -1)
                    {
                        Frente = 0;
                        Final = 0;
                    }
                    else
                    {
                        Final = Final + 1;
                    }
                    cola[Final] = elemento;
                }
            }
            public void Pop()
            {
                if (Frente != -1)
                {
                    Console.WriteLine("Eliminando el Dato... " + cola[Frente]);
                    cola[Frente] = "";

                    if (Frente == Final)
                    {
                        Frente = 1;
                        Final = 1;
                    }
                    else
                    {
                        Frente = Frente + 1;
                    }
                }
                else
                {
                    Console.WriteLine("La Cola Esta Vacia");
                    Console.ReadKey();
                }
            }
            public void Recorrido()
            {
                if (Frente != -1)
                {
                    Apuntador = Frente;
                    while (Apuntador <= Final)
                    {
                        Console.WriteLine("Elemento: " + cola[Apuntador] + "\tPosicion " + Apuntador);
                        Apuntador = Apuntador + 1;
                    }
                }
                else
                {
                    Console.WriteLine("La Cola Esta Vacia");
                    Console.ReadKey();
                }
            }
            public void Busqueda(string elemento)
            {
                if (Frente != -1)
                {
                    Apuntador = Frente;
                    while (Apuntador <= Final)
                    {
                        if (elemento == cola[Apuntador])
                        {
                            Console.WriteLine("Dato encontrado en la posición: " + Apuntador);
                            return;
                        }
                        Apuntador = Apuntador + 1;
                    }
                    Console.WriteLine("Dato: " + elemento + ", NO encontrado en la Cola");
                }
                else
                {
                    Console.WriteLine("La Cola Esta Vacia");
                    Console.ReadKey();
                }
            }
            //destructor de la clase
            ~Colas()
            {
                Console.WriteLine("Clase Colas Liberadas");
            }
        }
        static void Main(string[] args)
        {
            var tiempo = new Stopwatch();
            tiempo.Start();

            long Memoria, Memoriaa, Memoriaaa;
            Memoria = GC.GetTotalMemory(true);

            Colas c = null;
            string opcion;

            do
            {
                Console.Clear();
                Console.WriteLine("COLA MESES DEL AñO" +
                                "\na)Crear la Cola." +
                                "\nb)Insertar un Elemento." +
                                "\nc)Eliminar un Dato." +
                                "\nd)Recorrer la Cola." +
                                "\ne)Buscar un Elemento." +
                                "\nf)Salir del Programa.");
                Console.Write("Opcion: ");
                opcion = Console.ReadLine();
                switch (opcion)
                {
                    case "a":
                    case "A":
                        Console.Clear();
                        try
                        {
                            int c1;
                            Console.Write("Favor de ingresas el tamaño de la pila: ");
                            c1 = Convert.ToInt32(Console.ReadLine());
                            c = new Colas(c1);
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
                        if (c != null)
                        {
                            string e;
                            Console.Write("Ingrese El elemento que desea agregar a la pila: ");
                            e = Console.ReadLine();
                            c.Push(e);
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
                        c.Pop();
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case "d":
                    case "D":
                        Console.Clear();
                        c.Recorrido();
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case "e":
                    case "E":
                        Console.Clear();
                        Console.Write("Ingresa el mes a buscar: ");
                        string m = Console.ReadLine();
                        c.Busqueda(m);
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
            } 
            while (opcion != "f" && opcion != "F");

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