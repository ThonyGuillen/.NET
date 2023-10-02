using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa7_Complejidad_en_el_espacio
{
    class Operarios
    {
        private int[] sueldos;
        public Operarios()
        {
            sueldos = new int[5];
            for (int f = 0; f < sueldos.Length; f++)
            {
                Console.Write("Ingrese el sueldo " + (f + 1) + ": ");
                string linea = Console.ReadLine();
                sueldos[f] = int.Parse(linea);
            }
        }
        public void Imprimir()
        {
            Console.WriteLine("\n\n-------------------------------------");
            Console.WriteLine("Los Sueldos Ingresados.");
            for (int f = 0; f < sueldos.Length; f++)
            {
                Console.WriteLine(sueldos[f]);
            }
        }
        static void Main(string[] args)
        {
            long Memoria, Memoriaa, Memoriaaa;
            Memoria = GC.GetTotalMemory(true);
            
            Console.WriteLine("----------INGRESA 5 SUELDOS----------");
            Operarios op = new Operarios();
            Console.WriteLine("-------------------------------------");

            op.Imprimir();
            Console.WriteLine("-------------------------------------");

            Memoriaa = GC.GetTotalMemory(true);
            Memoriaaa = Memoriaa - Memoria;

            Console.WriteLine("\n\n---------------MEMORIA---------------");
            Console.WriteLine("Memoria Inicial: " + Memoria + "bytes");
            Console.WriteLine("Memoria Final: " + Memoriaa + "bytes");
            Console.WriteLine("Memoria Total: " + Memoriaaa + "bytes");
            Console.WriteLine("-------------------------------------");

            Console.ReadKey();
        }
    }
}