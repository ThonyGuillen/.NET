using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace programa25_Árbol_Binario_de_Nombres_de_Colores
{
    class Program
    {
        class Arbol
        {
            //campos de la clase
            string info;
            Arbol izq, der;
            //constructor de la clase
            public Arbol()
            {
                info = "";
                izq = null;
                der = null;
            }
            public Arbol raiz = null;
            //métodos de la clase
            public void Insertar(string elemento)
            {
                int bandera = 0;
                Arbol hoja = new Arbol();
                hoja.info = elemento;
                if (raiz == null)
                {
                    raiz = hoja; //inserta la raíz
                }
                else
                {
                    Arbol temp = raiz;
                    while (bandera != 1)
                    {
                        if (String.Compare(hoja.info, temp.info) < 0)
                        {
                            if (temp.izq == null)
                            {
                                temp.izq = hoja; //inserta subárbol izquierdo
                                bandera = 1;
                            }
                            else
                            {
                                temp = temp.izq;
                            }
                        }
                        else
                        {
                            if (temp.der == null)
                            {
                                temp.der = hoja; //inserta subárbol derecho
                                bandera = 1;
                            }
                            else
                            {
                                temp = temp.der;
                            }
                        }
                    }
                }
            }
            public void Preorden(Arbol temp)
            {
                if (temp != null)
                {
                    Console.WriteLine(temp.info);
                    if (temp.izq != null)
                    {
                        Preorden(temp.izq); //llamada recursiva
                    }
                    if (temp.der != null)
                    {
                        Preorden(temp.der); //llamada recursiva
                    }
                }
                else
                {
                    Console.WriteLine("El Árbol Binario esta Vacío");
                }
            }
            public void Inorden(Arbol temp)
            {
                if (temp != null)
                {
                    if (temp.izq != null)
                    {
                        Inorden(temp.izq); //llamada recursiva
                    }
                    Console.WriteLine(temp.info);
                    if (temp.der != null)
                    {
                        Inorden(temp.der); //llamada recursiva
                    }
                }
                else
                {
                    Console.WriteLine("El Árbol Binario esta Vacío");
                }
            }
            public void Posorden(Arbol temp)
            {
                if (temp != null)
                {
                    if (temp.izq != null)
                    {
                        Posorden(temp.izq); //llamada recursiva
                    }
                    if (temp.der != null)
                    {
                        Posorden(temp.der); //llamada recursiva
                    }
                    Console.WriteLine(temp.info);
                }
                else
                {
                    Console.WriteLine("El Árbol Binario esta Vacío");
                }
            }
            public void BusquedaRecursiva(Arbol temp, string key)
            {
                if (temp == null)
                {
                    Console.WriteLine("NO esta el nodo " + key + " en el Árbol Binario");
                }
                else
                {
                    if (key == temp.info)
                    {
                        Console.WriteLine("El nodo " + key + " SI esta en el Árbol Binario");
                    }
                    else
                    {
                        if (String.Compare(key, temp.info) < 0)
                        {
                            BusquedaRecursiva(temp.izq, key); //llamada recursiva
                        }
                        else
                        {
                            BusquedaRecursiva(temp.der, key); //llamada recursiva
                        }
                    }
                }
            }
            public void BusquedaIterativa(Arbol temp, string key)
            {
                bool encontrado = false;

                while (temp != null && encontrado == false)
                {
                    if (key == temp.info)
                    {
                        encontrado = true;
                    }
                    else
                    {
                        if (String.Compare(key, temp.info) < 0)
                        {
                            temp = temp.izq;
                        }
                        else
                        {
                            temp = temp.der;
                        }
                    }
                }
                if (encontrado == false)
                {
                    Console.WriteLine("El nodo " + key + " NO esta en el Árbol Binario");
                }
                else
                {
                    Console.WriteLine("El nodo " + key + " SI esta en el Árbol Binario");
                }
            }
            public void Eliminar()
            {
                Arbol p, q, v, s, t;
                bool encontrado = false;
                string x;
                p = raiz;
                q = null;
                if (p != null)
                {
                    Console.Write("Cuál nodo deseas eliminar del Árbol Binario? ");
                    x = Console.ReadLine();

                    while (p != null && encontrado == false)
                    {
                        if (p.info == x)
                        {
                            encontrado = true;
                            Console.WriteLine("El nodo " + p.info + " será ELIMINADO del Árbol");
                        }
                        else
                        {
                            q = p;

                            if (String.Compare(x, p.info) < 0)
                            {
                                p = p.izq; //busca en subárbol izquierdo
                            }
                            else
                            {
                                p = p.der; //busca en subárbol derecho
                            }
                        }
                    }
                    if (encontrado == true)
                    {
                        if (p.izq == null)
                        {
                            v = p.der; //solo tiene hijo derecho
                        }
                        else
                        {
                            if (p.der == null)
                            {
                                v = p.izq; //solo tiene hijo izquierdo
                            }
                            else //tiene sus dos hijos
                            {
                                t = p;
                                v = p.der;
                                s = v.izq;

                                while (s != null)
                                {
                                    t = v;
                                    v = s;
                                    s = v.izq;
                                }
                                if (t != p)
                                {
                                    t.izq = v.der;
                                    v.der = p.der;
                                }
                                v.izq = p.izq;
                            }
                        }
                        if (q == null) //se reasigna la raiz
                        {
                            raiz = v;
                        }
                        else
                        {
                            if (p == q.izq)
                            {
                                q.izq = v;
                            }
                            else
                            {
                                q.der = v;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("El nodo " + x + " NO esta en el Árbol Binario");
                    }
                }
                else
                {
                    Console.WriteLine("El Árbol Binario está Vacío");
                }
            }
            //destructor de la clase
            ~Arbol()
            {
                Console.WriteLine("\nClase Arbol Nombres de Colores Liberada");
            }
        }
        static void Main(string[] args)
        {
            var tiempo = new Stopwatch();
            tiempo.Start();

            long Memoria, Memoriaa, Memoriaaa;
            Memoria = GC.GetTotalMemory(true);

            Arbol a = new Arbol();
            string opcion;

            do
            {
                Console.Clear();
                Console.WriteLine("ARBOL BINARIO DE NOMBRES DE COLORES\n" +
                                "\na)Inserción de Nodos." +
                                "\nb)Recorrido del Arbol en Preorden." +
                                "\nc)Recorrido del Arbol en Inorden." +
                                "\nd)Recorrido del Arbol en Posorden." +
                                "\ne)Busqueda de Elementos Recursivamente." +
                                "\nf)Busqueda de Elementos Iterativamente." +
                                "\ng)Eliminación de Nodos." +
                                "\nh)Salir del Programa.");
                Console.Write("\nOpcion: ");
                opcion = Console.ReadLine();
                switch (opcion)
                {
                    case "a":
                    case "A":
                        Console.Clear();
                        string e;
                        Console.Write("Favor de ingresas un nodo: ");
                        e = Console.ReadLine();
                        a.Insertar(e);
                        Console.Write("Presione ENTER para continuar");
                        Console.ReadKey();
                        break;

                    case "b":
                    case "B":
                        Console.Clear();
                        Console.WriteLine("Recorrido del Arbol en Preorden.");
                        a.Preorden(a.raiz);
                        Console.Write("Presione ENTER para continuar");
                        Console.ReadKey();
                        break;

                    case "c":
                    case "C":
                        Console.Clear();
                        Console.WriteLine("Recorrido del Arbol en Inorden.");
                        a.Inorden(a.raiz);
                        Console.Write("Presione ENTER para continuar");
                        Console.ReadKey();
                        break;

                    case "d":
                    case "D":
                        Console.Clear();
                        Console.WriteLine("Recorrido del Arbol en Posorden.");
                        a.Posorden(a.raiz);
                        Console.Write("Presione ENTER para continuar");
                        Console.ReadKey();
                        break;

                    case "e":
                    case "E":
                        string k;
                        Console.Clear();
                        Console.Write("Ingresa el nodo a buscar: ");
                        k = Console.ReadLine();
                        a.BusquedaRecursiva(a.raiz, k);
                        Console.Write("Presione ENTER para continuar");
                        Console.ReadKey();
                        break;

                    case "f":
                    case "F":
                        Console.Clear();
                        Console.Write("Ingresa el nodo a buscar: ");
                        k = Console.ReadLine();
                        a.BusquedaRecursiva(a.raiz, k);
                        Console.Write("Presione ENTER para continuar");
                        Console.ReadKey();
                        break;

                    case "g":
                    case "G":
                        Console.Clear();
                        a.Eliminar();
                        Console.Write("Presione ENTER para continuar");
                        Console.ReadKey();
                        break;

                    //Salida del programa
                    case "h":
                    case "H":
                        Console.WriteLine("\nSalida del programa.....");
                        Console.ReadKey();
                        break;

                    default:
                        Console.WriteLine("\nIngrese una opcion valida");
                        Console.ReadKey();
                        break;
                }
            } while (opcion != "h" && opcion != "H");

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