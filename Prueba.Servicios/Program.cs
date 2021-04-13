using log4net.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;

namespace Prueba.Servicios
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        private static void Main()
        {
            //lOG 4 NET
            XmlConfigurator.Configure();

            if (Environment.UserInteractive)
            {
                Console.WriteLine("Prueba de servicio");
                Console.WriteLine("seleccione 1 Ejecicio de cadenas");
                Console.WriteLine("seleccione 2 Ejercicio de Registro");

                Console.WriteLine("seleccione 1 o 2");

                var code = Console.ReadLine().Trim();
                switch (code)
                {
                    case "1":
                        Console.WriteLine("digite el valor de la cadena");

                        var value =Console.ReadLine().Trim();
                        var generateValue = GenerarConteo(value);

                        Console.WriteLine($"la cadena generada es {generateValue}");
                        break;
                    case "2":
                        IExecuteJobs executeTask = new ExecuteJobs();
                        executeTask.Start();
                        break;
                    default:
                        Console.WriteLine($"Opcion iválida {code}!!");
                        break;
                }

                Console.ReadLine();
            }
            else
            {
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[]
                {
                new ServicioPrueba()
                };
                ServiceBase.Run(ServicesToRun);
            }
        }

        public static string GenerarConteo(string cadena) 
        {
            string getValue = string.Empty;
            try
            {
                if (cadena.Length > 2) 
                {
                    var arrayValues = cadena.ToCharArray();
                    var values = new Dictionary<char, int>();

                    char caracterInicial = arrayValues[0];
                    int count = 1;
                    foreach (var caracter in arrayValues)
                    {
                        if (caracterInicial == caracter)
                            count++;
                        else
                        {
                            getValue += string.Format("{0}{1}", caracterInicial, count);
                            caracterInicial = caracter;
                            count = 1;
                        }
                    }
                    getValue += string.Format("{0}{1}", caracterInicial, count);

                    if (getValue.Length < cadena.Length)
                        return getValue;

                }
                return cadena;
              
  
            }
            catch (Exception ex)
            {
                Logger.ErrorFatal("Error in GenerarConteo", ex);
            }
            return getValue;
        }
    }
}