using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace programa23_Lista_Enlazada_Nombres_Meses_del_Año
{
    class Program
    {
        class Nodo
        {
            //campos clase nodo
            public string elemento;
            public int siguiente;
            //constructor clase nodo
            public Nodo(string e, int s)
            {
                elemento = e;
                siguiente = s;
            }
            //destructor clase nodo
            ~Nodo()
            {
                Console.WriteLine("Recursos del Nodo Liberados.");
            }
        }
        class ListaEnlazada
        {
            // campos clase lista enlazada
            int inicio, disponible, Max, encontrado = 0;
            Nodo[] Lista;
            // variables auxiliares
            int tamaño, auxiliar, posición, temporal;
            char otra;
            // constructor clase lista enlazada
            public ListaEnlazada(int capacidad)
            {
                Max = capacidad;
                inicio = 0;
                disponible = 0;
                tamaño = 0;
                Lista = new Nodo[Max];
                for (int c = 0; c < Max - 1; c++)
                {
                    Lista[c] = new Nodo("", c + 1);
                }
                Lista[Max - 1] = new Nodo("", -1);
                Console.WriteLine("La lista enlazada ha sido creada con éxito.");
                Console.WriteLine("Presione <enter> para continuar.");
                Console.ReadKey();
            }
            // métodos clase lista enlazada
            public void Insertar()
            {
                string dato;
                do
                {
                    if (tamaño == Max)
                    {
                        Console.WriteLine("La Lista está Llena");
                        Console.ReadKey();
                        return;
                    }
                    else
                    {
                        Console.Write("Ingrese un valor: ");
                        dato = Console.ReadLine();
                        temporal = Lista[disponible].siguiente;
                        Lista[disponible].elemento = dato;
                        lugar_insertar(dato);

                        if (posición == inicio)
                        {
                            Lista[disponible].siguiente = inicio;
                            inicio = disponible;
                        }
                        else
                        {
                            Lista[disponible].siguiente = Lista[auxiliar].siguiente;
                            Lista[auxiliar].siguiente = disponible;
                        }
                        disponible = temporal;
                        tamaño = tamaño + 1;
                    }
                    Console.Write("Desea otra inserción(S / N) ?: ");
                    otra = char.Parse(Console.ReadLine());
                    otra = char.ToUpper(otra);
                } while (otra == 'S');
            }
            public void lugar_insertar(string dato)
            {
                int encontrado = 0;
                posición = inicio;
                auxiliar = 0;
                while (posición != -1 && encontrado != 1)
                {
                    if (String.Compare(Lista[posición].elemento, dato) > 0)
                    {
                        encontrado = 1;
                    }
                    else
                    {
                        auxiliar = posición;
                        posición = Lista[posición].siguiente;
                    }
                }
            }
            public void Eliminar()
            {
                string dato;
                do
                {
                    if (tamaño == 0)
                    {
                        Console.WriteLine("La Lista está Vacía");
                        Console.ReadKey();
                        return;
                    }
                    else
                    {
                        Console.Write("Ingrese un valor a eliminar: ");
                        dato = Console.ReadLine();
                        busca_eliminar(dato);

                        if (encontrado == 1)
                        {
                            if (auxiliar != -1)
                            {

                                Lista[auxiliar].siguiente = Lista[posición].siguiente;
                            }
                            else
                            {
                                inicio = Lista[posición].siguiente;
                            }
                            Lista[posición].elemento = "";
                            Lista[posición].siguiente = -1;
                            temporal = disponible;
                            while (temporal != -1)
                            {
                                if (Lista[temporal].siguiente != 0)
                                {
                                    temporal = Lista[temporal].siguiente;
                                }
                                else
                                {
                                    Lista[temporal].siguiente = posición;
                                }
                            }
                            tamaño = tamaño - 1;
                        }
                    }
                    Console.Write("Desea otra eliminacion(S / N) ?: ");
                    otra = char.Parse(Console.ReadLine());
                    otra = char.ToUpper(otra);
                } while (otra == 'S');
            }
            public int busca_eliminar(string dato)
            {
                posición = inicio;
                auxiliar = -1;

                while (posición != -1 && encontrado != 1)
                {
                    if (Lista[posición].elemento.Equals(dato))
                    {
                        Console.WriteLine("encontrado = 1");
                        encontrado = 1;
                    }
                    else
                    {
                        auxiliar = posición;
                        posición = Lista[posición].siguiente;
                    }
                }
                if (encontrado == 0)
                {
                    Console.WriteLine("El Elemento " + dato + " NO está en la Lista");
                }
                else
                {
                    Console.WriteLine("El Elemento " + dato + " sera Eliminado de la Lista");
                }
                return encontrado;
            }
            public void Desplegar()
            {
                posición = inicio;
                if (tamaño == 0)
                {
                    Console.WriteLine("La Lista esta Vacia");
                    Console.ReadKey();
                    return;
                }
                else
                {
                    while (posición != -1 && Lista[posición].elemento != "")
                    {
                        Console.WriteLine("Elemento: " + Lista[posición].elemento + "\tPosición: " + posición);
                        posición = Lista[posición].siguiente;
                    }
                }
            }
            public void Contar()
            {
                int contador = 0;
                posición = inicio;

                if (tamaño == 0)
                {
                    Console.WriteLine("La Lista está Vacía");
                    Console.ReadKey();
                    return;
                }
                else
                {
                    while (posición != -1 && Lista[posición].elemento != "")
                    {
                        contador = contador + 1;
                        posición = Lista[posición].siguiente;
                    }
                    Console.WriteLine("El Total de Elementos en la Lista es: " + contador);
                    Console.ReadKey();
                }
            }
            public void Buscar()
            {
                string dato;
                int encontrado;
                if (tamaño == 0)
                {
                    Console.WriteLine("La Lista está Vacía");
                    Console.ReadKey();
                    return;
                }
                else
                {
                    do
                    {
                        encontrado = 0;
                        posición = inicio;
                        Console.Write("Ingrese el nombre que desea buscar: ");
                        dato = Console.ReadLine();

                        while (posición != -1 && encontrado != 1)
                        {
                            if (Lista[posición].elemento == dato)
                            {
                                encontrado = 1;
                            }
                            else
                            {
                                posición = Lista[posición].siguiente;
                            }
                        }
                        if (encontrado == 0)
                        {
                            Console.WriteLine("El Elemento " + dato + " No está en la Lista");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("El Elemento " + dato + " esta en la posicion " + posición);
                            Console.ReadKey();
                        }
                        Console.Write("Desea otra búsqueda(S / N) ? ");
                        otra = char.Parse(Console.ReadLine());
                        otra = char.ToUpper(otra);
                    } while (otra == 'S');
                }
            }
            // destructor clase lista enlazada
            ~ListaEnlazada()
            {
                Console.WriteLine("Recursos de Lista Enlazada Liberados.");
            }
        }
        static void Main(string[] args)
        {
            var tiempo = new Stopwatch();
            tiempo.Start();

            long Memoria, Memoriaa, Memoriaaa;
            Memoria = GC.GetTotalMemory(true);

            ListaEnlazada L = null;
            string opcion;

            do
            {
                Console.Clear();
                Console.WriteLine("LISTA NOMBRES PERSONAS" +
                                "\na)Crear la Lista" +
                                "\nb)Insertar un Elemento en la Lista" +
                                "\nc)Eliminar un Dato de la Lista" +
                                "\nd)Recorrer la Lista" +
                                "\ne)Determinar el Número de Elementos en la Lista" +
                                "\nf)Localizar un Elemento en Particular de la Lista." +
                                "\ng)Salir del Programa.");
                Console.Write("\nOpcion: ");
                opcion = Console.ReadLine();
                switch (opcion)
                {
                    case "a":
                    case "A":
                        Console.Clear();
                        int T;
                        Console.Write("Favor de ingresas el tamaño de la lista: ");
                        T = Convert.ToInt32(Console.ReadLine());
                        L = new ListaEnlazada(T);
                        break;

                    case "b":
                    case "B":
                        Console.Clear();
                        L.Insertar();
                        Console.ReadKey();
                        break;

                    case "c":
                    case "C":
                        Console.Clear();
                        L.Eliminar();
                        Console.ReadKey();
                        break;

                    case "d":
                    case "D":
                        Console.Clear();
                        L.Desplegar();
                        Console.ReadKey();
                        break;

                    case "e":
                    case "E":
                        Console.Clear();
                        L.Contar();
                        Console.ReadKey();
                        break;

                    case "f":
                    case "F":
                        Console.Clear();
                        L.Buscar();
                        Console.ReadKey();
                        break;

                    //Salida del programa
                    case "g":
                    case "G":
                        break;

                    default:
                        Console.WriteLine("\nIngrese una opcion valida");
                        Console.ReadKey();
                        break;
                }
            } 
            while (opcion != "g" && opcion != "G");

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