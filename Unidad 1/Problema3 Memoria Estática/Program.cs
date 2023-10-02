using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema3_Memoria_Estatica
{
    public static class ConvertirTemperatura
    {
        public static double CelsiusAFahrenheit(string TemperaturaCelsius)
        {
            double C = Double.Parse(TemperaturaCelsius);

            double F = (C * 9 / 5) + 32;

            return F;
        }
        public static double FahrenheitACelsius(string TemperaturaFahrenheit)
        {
            double F = Double.Parse(TemperaturaFahrenheit);

            double C = (F - 32) * 5 / 9;

            return C;
        }
    }
    class TestTemperatureConverter
    {
        static void Main()
        {
            Console.WriteLine("Convertidor de temperaturas");
            Console.WriteLine("1. De Celsius a Fahrenheit.");
            Console.WriteLine("2. De Fahrenheit a Celsius.");
            Console.Write("Seleccione una opcion:");

            string Seleccion = Console.ReadLine();
            double F, C = 0;

            switch (Seleccion)
            {
                case "1":
                    Console.Write("Ingrese la temperatura en Celsius: ");
                    F = ConvertirTemperatura.CelsiusAFahrenheit(Console.ReadLine());
                    Console.WriteLine("Temperatura en Fahrenheit: {0:F2}", F);
                    break;

                case "2":
                    Console.Write("Ingrese la temperatura en Fahrenheit: ");
                    C = ConvertirTemperatura.FahrenheitACelsius(Console.ReadLine());
                    Console.WriteLine("Temperatura en Celsius: {0:F2}", C);
                    break;

                default:
                    Console.WriteLine("Porfavor seleccione el convertidor");
                    break;
            }
            Console.WriteLine("Presione cualquier tecla para salir.");
            Console.ReadKey();
        }
    }
}
