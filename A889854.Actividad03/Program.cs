using System;
using System.Collections.Generic;
using System.IO;

namespace A889854.Actividad03
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //Path al archivo del libro mayor.
            String pathLibroMayor = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "mayor.txt");
            
            //Crear lista de asientos diarios.
            string[] csvAsientosDiarios = File.ReadAllLines(Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "diario.txt"));
            var asientosDiarios = new List<AsientoDiario>();

            using (StreamWriter salida = File.AppendText(pathLibroMayor))

                for (int i = 1; i < csvAsientosDiarios.Length; i++)
            {
                AsientoDiario asiento = new AsientoDiario(csvAsientosDiarios[i]);
                asientosDiarios.Add(asiento);
            }

           
            // Ejecutar funciones solicitadas hasta salir.
            while (true)
            {
                //Crear lista de asientos del libro mayor.
                string[] csvAsientosMayor = File.ReadAllLines(Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "mayor.txt"));
                var asientosMayor = new List<AsientoMayor>();
                for (int i = 1; i < csvAsientosMayor.Length; i++)
                {
                    AsientoMayor asientoMayor = new AsientoMayor(csvAsientosMayor[i]);
                    asientosMayor.Add(asientoMayor);
                }

                Console.Clear();
                Console.WriteLine("Seleccione la opción deseada:");
                Console.WriteLine("1 - Actualizar diario mayor.");
                Console.WriteLine("2 - Consultar diario mayor.");
                Console.WriteLine("3 - Salir.");

                int seleccion = Validaciones.IngresarOpcion();

                switch (seleccion)
                {
                    case 1:
                        Funciones.ActualizarMayor(asientosDiarios, asientosMayor, pathLibroMayor);
                        Console.Clear();
                        break;
                    case 2:
                        Console.Clear();
                        Funciones.ConsultarMayor(pathLibroMayor);
                        break;
                    case 3:
                        System.Environment.Exit(1);
                        break;
                }
            }
            

        }
    }
}
