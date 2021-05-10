using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace A889854.Actividad03
{
    class Funciones
    {
        // Actualiza diario mayor
        public static void ActualizarMayor(List<AsientoDiario> libroDiario, List<AsientoMayor> libroMayor, string pathSalida) //Actualiza diario mayor.
        {
            //validar cuenta a actualizar
            Console.WriteLine("Ingrese el nro de cuenta a actualizar:");
            int nroCuenta = Validaciones.IngresarNumeroCuenta();
            bool mayorContieneCuenta = libroMayor.Any(item => item.CodigoCuenta == nroCuenta);
            bool diarioContieneCuenta = libroDiario.Any(item => item.CodigoCuenta == nroCuenta);
            double debeAgregado = 0;
            double haberAgregado = 0;
            int contregistros = 0;
            DateTime? ultimaFecha = null;

            // si la cuenta no existe en libro diario, no hace nada

            if (!diarioContieneCuenta)
            {
                Console.WriteLine("No hay asientos nuevos correspondientes a esa cuenta.");
            }

            // si la cuenta existe en libro mayor, la actualiza
            else
            {
                if (mayorContieneCuenta)
                {
                    AsientoMayor registroAActualizar = libroMayor.Where(x => x.CodigoCuenta == nroCuenta).OrderByDescending(o => o.Fecha).FirstOrDefault();
                    List<AsientoDiario> asiDiariosOrdenados = libroDiario.OrderBy(o => o.Fecha).ToList();
                    List<AsientoMayor> asientosAgregar = new List<AsientoMayor>();
                    debeAgregado += registroAActualizar.Debe;
                    haberAgregado += registroAActualizar.Haber;

                    foreach (var item in asiDiariosOrdenados)
                    {

                        if (item.CodigoCuenta == registroAActualizar.CodigoCuenta && item.Fecha > registroAActualizar.Fecha)
                        {
                            debeAgregado += item.Debe;
                            haberAgregado += item.Haber;
                            contregistros++;
                            ultimaFecha = item.Fecha;                            
                        }
                        asientosAgregar.Clear();
                        asientosAgregar.Add(new AsientoMayor(nroCuenta, item.Fecha, debeAgregado, haberAgregado));

                    }

                    // muestra los datos usados para la actualizacion
                    if (contregistros > 0)
                    {
                        Console.WriteLine("Se actualizó el libro mayor con la información de " + contregistros + " asientos del libro diario, este es el nuevo estado de la cuenta:");

                        foreach (var obj in asientosAgregar)
                        {

                            Console.WriteLine(obj);

                            using (StreamWriter sw = File.AppendText(pathSalida))
                            {
                                sw.WriteLine(obj.ToString());
                                sw.Close();
                            }

                        }

                    }
                    else
                    {
                        Console.WriteLine("No había asientos nuevos.");
                    }


                }


                // Si la cuenta no existe, agrega el asiento al libro mayor.
                else
                {
                    Console.WriteLine("La cuenta no existe en el libro mayor. Agregando asientos de la cuenta.");
                    List<AsientoDiario> asiDiariosOrdenados = libroDiario.OrderBy(o => o.Fecha).ToList();
                    List<AsientoMayor> asientosAgregar = new List<AsientoMayor>();

                    foreach (var item in asiDiariosOrdenados)
                    {
                        if (item.CodigoCuenta == nroCuenta)
                        {
                            debeAgregado += item.Debe;
                            haberAgregado += item.Haber;
                            contregistros++;
                            ultimaFecha = item.Fecha;
                        }
                        asientosAgregar.Clear();
                        asientosAgregar.Add(new AsientoMayor(nroCuenta, item.Fecha, debeAgregado, haberAgregado));
                    }

                    // Muestra los datos usados para la actualizacion.
                    if (contregistros > 0)
                    {
                        Console.WriteLine("Se añadieron los siguientes " + contregistros.ToString() + " registros al libro mayor: ");

                        foreach (var obj in asientosAgregar)
                        {
                            Console.WriteLine(obj);
                            using (StreamWriter sw = File.AppendText(pathSalida))
                            {
                                sw.WriteLine(obj);
                                sw.Close();
                            }

                        }

                    }
                }
            }

            Console.WriteLine("Presione cualquier tecla para continuar.");
            Console.ReadKey();
        }

        // Lee diario mayor y muestra cada línea en la pantalla.
        public static void ConsultarMayor(string libromayor) //Lee diario mayor y muestra cada línea en la pantalla.
        {

            string line;

            // Lee el archivo línea por línea y lo muestra en consola.
            System.IO.StreamReader file = new System.IO.StreamReader(libromayor);
            while ((line = file.ReadLine()) != null)
            {
                System.Console.WriteLine(line);
            }
            file.Close();

            Console.WriteLine("Presione cualquier tecla para continuar.");
            Console.ReadKey();
        }
    }
}
