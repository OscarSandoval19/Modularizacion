using System;
using System.Collections.Generic;

class Program
{
    static List<string> estudiantes = new List<string>();
    static List<double> calificaciones = new List<double>();

    static void Main()
    {
        Console.WriteLine("Bienvenido al sistema de gestión de estudiantes.");

        while (true)
        {
            MostrarMenu();
            int opcion = ObtenerOpcion();

            switch (opcion)
            {
                case 1:
                    AgregarEstudiante();
                    break;
                case 2:
                    MostrarEstudiantes();
                    break;
                case 3:
                    Promedio();
                    break;
                case 4:
                    EstudianteConMasCalificacion();
                    break;
                case 5:
                    Console.WriteLine("Saliendo del sistema...");
                    return;
                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    break;
            }
        }
    }

    static void MostrarMenu()
    {
        Console.WriteLine("\n1. Agregar estudiante");
        Console.WriteLine("2. Mostrar lista de estudiantes");
        Console.WriteLine("3. Promedio de calificaciones");
        Console.WriteLine("4. Mostrar estudiante con la calificación más alta");
        Console.WriteLine("5. Salir");
        Console.Write("Seleccione una opción: ");
    }

    static int ObtenerOpcion()
    {
        int opcion;
        while (!int.TryParse(Console.ReadLine(), out opcion))
        {
            Console.Write("Entrada inválida. Ingrese un número válido: ");
        }
        return opcion;
    }

    static void AgregarEstudiante()
    {
        Console.Write("Ingrese el nombre del estudiante: ");
        string nombre = Console.ReadLine();
        Console.Write("Ingrese la calificación del estudiante: ");
        double calificacion;
        while (!double.TryParse(Console.ReadLine(), out calificacion))
        {
            Console.Write("Entrada inválida. Ingrese una calificación numérica válida: ");
        }
        estudiantes.Add(nombre);
        calificaciones.Add(calificacion);
        Console.WriteLine("Estudiante agregado correctamente.");
    }

    static void MostrarEstudiantes()
    {
        if (estudiantes.Count == 0)
        {
            Console.WriteLine("No hay estudiantes registrados.");
        }
        else
        {
            Console.WriteLine("\nLista de estudiantes:");
            for (int i = 0; i < estudiantes.Count; i++)
            {
                Console.WriteLine($"{estudiantes[i]} - Calificación: {calificaciones[i]}");
            }
        }
    }

    static void Promedio()
    {
        if (calificaciones.Count == 0)
        {
            Console.WriteLine("No hay calificaciones registradas.");
        }
        else
        {
            double suma = 0;
            foreach (double calificacion in calificaciones)
            {
                suma += calificacion;
            }
            double promedio = suma / calificaciones.Count;
            Console.WriteLine($"El promedio de calificaciones es: {promedio:F2}");
        }
    }

    static void EstudianteConMasCalificacion()
    {
        if (calificaciones.Count == 0)
        {
            Console.WriteLine("No hay calificaciones registradas.");
        }
        else
        {
            double maxCalificacion = calificaciones[0];
            string estudianteMax = estudiantes[0];
            for (int i = 1; i < calificaciones.Count; i++)
            {
                if (calificaciones[i] > maxCalificacion)
                {
                    maxCalificacion = calificaciones[i];
                    estudianteMax = estudiantes[i];
                }
            }
            Console.WriteLine($"El estudiante con la calificación más alta es: {estudianteMax} con {maxCalificacion}");
        }
    }
}
