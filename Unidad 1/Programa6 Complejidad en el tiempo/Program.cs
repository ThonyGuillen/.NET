using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa6_Complejidad_en_el_tiempo
{
    class Class
    {
        static void Main()
        {
            var tiempo = new Stopwatch();
            tiempo.Start();
            int n;
            Console.WriteLine("Metodo Quick Sort\n");
            Console.Write("Cantidad de numeros: ");
            n = Int32.Parse(Console.ReadLine());    
            numeros b = new numeros(n);
            tiempo.Stop();
            Console.WriteLine("\nEl tiempo fue de " + tiempo.Elapsed.TotalSeconds + " segundos");
            Console.WriteLine("\n\nPresione una tecla para continuar . . .");
            Console.ReadKey();
        }
    }

    class numeros
    {
        int h;
        int[] num;
        public numeros(int n)
        {
            h = n;
            num = new int[h];
            for (int i = 0; i < h; i++)
            {
                Console.Write("Numero {0}: ", i + 1);
                num[i] = Int32.Parse(Console.ReadLine());
            }
            quicksort(num, 0, h - 1);
            mostrar();
        }
        private void quicksort(int[] num, int primero, int ultimo)
        {
            int i, j, central;
            double pivote;
            central = (primero + ultimo) / 2;
            pivote = num[central];
            i = primero;
            j = ultimo;
            do
            {
                while (num[i] < pivote) i++;
                while (num[j] > pivote) j--;
                if (i <= j)
                {
                    int temp;
                    temp = num[i];
                    num[i] = num[j];
                    num[j] = temp;
                    i++;
                    j--;
                }
            } while (i <= j);
            if (primero < j)
            {
                quicksort(num, primero, j);
            }
            if (i < ultimo)
            {
                quicksort(num, i, ultimo);
            }
        }
        private void mostrar()
        {
            Console.WriteLine("\nNumeros ordenados en forma ascendente");
            for (int i = 0; i < h; i++)
            {
                Console.Write("{0} ", num[i]);
            }
            Console.ReadLine();
        }
    }
}
