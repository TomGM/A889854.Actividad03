using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A889854.Actividad03
{
    static class Validaciones
    {
        // Valida enteros.
        public static int IngresarOpcion()
        {
            int opcion;
            while ((!int.TryParse(Console.ReadLine(), out opcion)) && (opcion < 1 || opcion > 3))
                Console.Write("Ingrese una opción válida.\n");
            return opcion;
        }

        public static int IngresarNumeroCuenta()
        {
            int opcion;
            while ((!int.TryParse(Console.ReadLine(), out opcion)) && (opcion < 11 || opcion > 34))
                Console.Write("Ingrese un número de cuenta válido.\n");
            return opcion;
        }

    }
}
