using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace programa15_Ejemplo_alumnos
{
    class Program
    {
        public int cont(int uno, int dos, int i)
        {
            if (uno <= dos)
            {

                Console.WriteLine(uno);
                i++;
                uno = uno + 1;
                return cont(uno, dos, i);
            }
            else
            {
                return i;
            }
        }
        static void Main(string[] args)
        {
            var tiempo = new Stopwatch();
            tiempo.Start();

            long Memoria, Memoriaa, Memoriaaa;
            Memoria = GC.GetTotalMemory(true);

            int opc;
            int i = 0;
            Console.Title = "Lista de numeros";
            do
            {
                Console.WriteLine("Lista de numeros");
                Console.WriteLine("1. Lista de numeros.");
                Console.WriteLine("2. Salir del programa.");
                Console.Write("\nOpción: ");
                opc = Int16.Parse(Console.ReadLine());
                switch (opc)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Lista de numeros\n");
                        Console.Write("Valor inicial: ");
                        int uno = int.Parse(Console.ReadLine());
                        Console.Write("Valor final: ");
                        int dos = int.Parse(Console.ReadLine());

                        if (uno <= dos)
                        {
                            Console.Clear();
                            Console.WriteLine("Lista de " + uno + " hasta " + dos + ": \n");

                            Program p = new Program();
                            Console.WriteLine("\nTotal es: " + p.cont(uno, dos, i));
                            Console.WriteLine("\nPresione una tecla para continuar . . . ");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        else
                        {
                            Console.WriteLine("\nNo se puede mostrar el conteo ya que el valor inicial es mayor que el valor final");
                            Console.WriteLine("\nPresione una tecla para continuar . . . ");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        break;

                    case 2:
                        break;

                    default:
                        Console.WriteLine("\nIntroduzca una opcion valida");
                        Console.WriteLine("\nPresione una tecla para continuar. . . ");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }
            while (opc != 2);

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