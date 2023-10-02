using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace programa12_Torres_de_Hanoi
{
    class Program
    {
        class TorresdeHanoi
        {
            int m_numdiscs;
            public int mov = 0;
            public TorresdeHanoi()
            {
                numdiscs = 0;
            }
            public TorresdeHanoi(int newval)
            {
                numdiscs = newval;
            }
            public int numdiscs
            {
                get
                {
                    return m_numdiscs;
                }
                set
                {
                    if (value > 0)
                        m_numdiscs = value;
                }
            }
            public void movtower(int n, string origen, string auxiliar, string destino)
            {
                if (n == 1)
                {                                      
                    Console.WriteLine("Movimiento de de la torre " + origen + " a la torre " + destino );                    
                    mov++;
                }
                else
                {
                    movtower(n - 1, origen, destino, auxiliar);
                    Console.WriteLine("Movimiento de de la torre " + origen + " a la torre " + destino);
                    mov++;
                    movtower(n - 1, auxiliar, origen, destino);
                }
            }
        }
        static void Main(string[] args)
        {
            var tiempo = new Stopwatch();
            tiempo.Start();

            long Memoria, Memoriaa, Memoriaaa;
            Memoria = GC.GetTotalMemory(true);

            int opc;
            do
            {
                Console.WriteLine("TORRES DE HANOI");
                Console.WriteLine("(1) Calcular Movimientos");
                Console.WriteLine("(2) Salir del programa");
                Console.Write("Opción: ");
                opc = Int32.Parse(Console.ReadLine());
                switch (opc)
                {
                    case 1:
                        Console.Clear();
                        TorresdeHanoi h1 = new TorresdeHanoi();
                        string cnumdiscs;
                        Console.Write("Introduzca el numero de discos: ");
                        cnumdiscs = Console.ReadLine();
                        h1.numdiscs = Convert.ToInt32(cnumdiscs);
                        h1.movtower(h1.numdiscs, "Origen", "Destino", "Auxiliar");
                        Console.Write("Numero de movimientos: " + h1.mov);
                        Console.WriteLine("\n\nPresione una tecla para continuar . . . ");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case 2:
                        break;

                    default:
                        Console.WriteLine("Introduzca una opcion valida");
                        Console.WriteLine("Presione una tecla para continuar . . . ");
                        Console.ReadLine();
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