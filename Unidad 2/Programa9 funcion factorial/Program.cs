using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace programa9_funcion_factorial
{
    class Program
    {
        public class Factorial
        {
            public int factorial;
            //metodo de factorizacion por recursividad
            public int fact(int n)
            {
                //validacion negativa
                if (n < 0)
                {
                    Console.WriteLine("No se puede ingresar un numero negativo");
                    return 0;
                }
                else
                {
                    if (n == 0)
                    {
                        return 1;
                    }
                    else
                    {
                        return factorial = n * fact(n - 1);
                    }
                }
            }
            public void Desplegar(int num)
            {
                Console.WriteLine("El numero es " + num + ", su factorial es " + factorial);
            }
        }
        static void Main(string[] args)
        {
            var tiempo = new Stopwatch();
            tiempo.Start();

            long Memoria, Memoriaa, Memoriaaa;
            Memoria = GC.GetTotalMemory(true);

            //variables
            int opc, numero;

            //menu
            do
            {
                Console.WriteLine("MENU FACTORIAL");
                Console.WriteLine("1.- Calcular Función.");
                Console.WriteLine("2.- Salir del Programa.");
                Console.Write("\nOpción: ");
                opc = Int32.Parse(Console.ReadLine());
                switch (opc)
                {
                    case 1:
                        Console.Clear();
                        Console.Write("Ingrese un numero: ");
                        numero = Int32.Parse(Console.ReadLine());

                        //creación del objeto
                        Factorial Fac = new Factorial();
                        Console.Clear();

                        //ejecución de sus métodos
                        Fac.fact(numero);
                        Fac.Desplegar(numero);
                        Console.Write("\nPresione una tecla para continuar . . . ");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    //Salída del Programa
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