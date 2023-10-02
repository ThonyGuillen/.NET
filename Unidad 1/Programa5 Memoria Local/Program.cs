using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema5_Memoria_Local
{
    class Program
    {
        public class Funcion
        {
            //CAMPO
            public double coseno;

            //METODO
            public double Coseno(float num)
            {
                return coseno = Math.Cos(num);
            }

            public void Res(float num)
            {
                Console.WriteLine("\n\nResultados \n");
                Console.WriteLine("Numero: " + num);
                Console.WriteLine("Coseno: " + coseno);
            }
        }
        static void Main(string[] args)
        {
            //SE CREA EL OBJETO
            Funcion Num1 = new Funcion();

            //SE UTILIZA LA MEMORIA LOCAL EN LA VARIABLE
            float Num2;

            //SE CAPTURA EL NUMERO
            Console.WriteLine("Captura de datos");
            Console.Write("\nNumero: ");
            Num2 = float.Parse(Console.ReadLine());

            //SE EJECUTAMN LOS METODOS DE LAS FUNCIONES ENVIANDON EL PARAMETRO
            Num1.Coseno(Num2);

            //SE EJECUTA EL METODO DE RES ENVIANDO EL NUMERO COMO PARAMETRO
            Num1.Res(Num2);
            Console.ReadKey();
        }
    }
}
