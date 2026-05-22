using Dsw2026Ej11.Collections;
using Dsw2026Ej11.Domain;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Dsw2026Ej11.Tests;


internal class Ejemplos
{
    //Agregar 3 alumnos a la lista
    //Listar por consola los alumnos
    //Buscar por nombre un alumno que exista y mostrar por consola
    //Buscar por nombre un alumno que no exista y mostrar por consola el texto "No existe"
    //Eliminar un alumno y listar por consola los alumnos
    //Eliminar el primer elemento de la lista y listar por consola los alumnos
    public static void EjemploList()
    {
        CasoList casoList = new CasoList();

        Alumno al1 = new Alumno( 1,"Juan", 8.5);
        Alumno al2 = new Alumno( 2,"Pepe", 9);
        Alumno al3 = new Alumno(3, "Roberto", 7.5);

        casoList.AgregarAlumno(al1);
        casoList.AgregarAlumno(al2);
        casoList.AgregarAlumno(al3);

        Console.WriteLine("Listado de alumnos:");
        foreach(Alumno al in casoList.RetornarLista())
        {
            Console.WriteLine(al.ToString());
        }
        Console.WriteLine();

        Console.WriteLine("Buscar alumno por nombre:");
        Alumno alumnoEncontrado = casoList.BuscarAlumno("Pepe");

        if (alumnoEncontrado != null)
        {
            Console.WriteLine($"Alumno encontrado: {alumnoEncontrado}, Id: {alumnoEncontrado.Id}, promedio: {alumnoEncontrado.Promedio}");
        }
        else
        {
            Console.WriteLine("No existe");
        }

        Console.WriteLine();

        Console.WriteLine("Buscar alumno por nombre que no existe:");
        Alumno alumnoNoEncontrado = casoList.BuscarAlumno("Agustina");

        if (alumnoNoEncontrado != null)
        {
            Console.WriteLine($"Encontrado: {alumnoNoEncontrado.Nombre}");
        }
        else { Console.WriteLine("No existe"); }

        Console.WriteLine();

        Console.WriteLine("Eliminar alumno por nombre:");
        casoList.EliminarAlumno(al3);
        Console.WriteLine("Listado de alumnos después de eliminar alumno:");
        casoList.RetornarLista();
        Console.WriteLine(); 


        Console.WriteLine("Eliminar el primer elemento de la lista:");
        casoList.EliminarAlumnoPosicion(0);
        Console.WriteLine("Listado de alumnos después de eliminar el primer alumno:");
        casoList.RetornarLista();
    }

    //Agregar 3 alumnos al diccionario
    //Listar por consola los alumnos
    //Buscar un alumno por clave y mostrar por consola
    //Buscar un alumno por clave, pero que no exista, y mostrar por consola el texto "No existe"
    //Eliminar un alumno por clave y listar por consola los alumnos
    public static void EjemploDictionary()
    {
        CasoDictionary casoDictionary = new CasoDictionary();


        Alumno al1 = new Alumno(  1,  "Juan", 8.5);
        Alumno al2 = new Alumno( 2,  "Pepe", 9);
        Alumno al3 = new Alumno(  3,"Roberto", 7.5);

        casoDictionary.AgregarAlumno(al1.Id, al1);
        casoDictionary.AgregarAlumno(al2.Id, al2);
        casoDictionary.AgregarAlumno(al3.Id, al3);

        Console.WriteLine("Listado de alumnos:");
        Dictionary<int, Alumno> alumnos = casoDictionary.RetornarDiccionario();

        foreach(KeyValuePair<int, Alumno> alumno in alumnos)
        {
            Console.WriteLine($"Legajo: {alumno.Key} -> {alumno.Value.ToString()}");
        }

        Console.WriteLine();

        Console.WriteLine("Buscar alumno por clave:");
        Alumno alumnoEncontrado = casoDictionary.BuscarAlumno(2);

        if(alumnoEncontrado != null)
        {
            Console.WriteLine($"Alumno encontrado: {alumnoEncontrado.Nombre}, Id: {alumnoEncontrado.Id}");
        }
        else
        {
            Console.WriteLine("No existe");
        }

        Console.WriteLine();

        Console.WriteLine("Buscar alumno por clave que no existe:");
        Alumno alumnoNoEncontrado = casoDictionary.BuscarAlumno(4);

        if(alumnoNoEncontrado != null)
        {
            Console.WriteLine($"Alumno encontrado: {alumnoNoEncontrado.Nombre}, Id: {alumnoNoEncontrado.Id}");
        }
        else
        {
            Console.WriteLine("No existe");
        }

        Console.WriteLine();

        Console.WriteLine("Eliminar alumno por clave:");
        casoDictionary.EliminarAlumno(2);

        foreach (KeyValuePair<int, Alumno> alumno in casoDictionary.RetornarDiccionario())
        {
            Console.WriteLine($"Legajo: {alumno.Key}, Nombre: {alumno.Value}");
        }

    }

    //Realizar una llamada a cada método definido en CasoLinq y mostar por consola según corresponda
    public static void EjemploLinq()
    {
        Console.WriteLine("Ejemplo LINQ:");

        CasoLinq casoLinq = new CasoLinq(Libro.CrearLista());

        

        Libro primero = casoLinq.GetPrimero();
        Console.WriteLine($"Primer libro: {primero?.Titulo}, Precio: {primero?.Precio:C}");

        Libro ultimo = casoLinq.GetUltimo();
        Console.WriteLine($"Último libro: {ultimo?.Titulo}, Precio: {ultimo?.Precio:C}");

        decimal totalPrecios = casoLinq.GetTotalPrecios();
        Console.WriteLine($"Total de precios de los libros: {totalPrecios:C}");

        decimal promedioPrecios = casoLinq.GetPromedioPrecios();
        Console.WriteLine($"Promedio de precios de los libros: {promedioPrecios:C}");
        Console.WriteLine();

        Console.WriteLine("Libros con Id mayor a 15");
        List<Libro> librosById = casoLinq.GetListById();
        foreach (Libro libro in librosById)
        {
            Console.WriteLine($"Id: {libro.Id}, Título: {libro.Titulo}, Precio: {libro.Precio:C}");
        }
        Console.WriteLine();

        Console.WriteLine("Lista de libros con precio en formato moneda:");
        List<string> librosFormateados = casoLinq.GetLibros();
        foreach (string libro in librosFormateados)
        {
            Console.WriteLine(libro);
        }
        Console.WriteLine();

        Console.WriteLine("Libro con mayor precio:");
        Libro libroMasCaro = casoLinq.GetMayorPrecio();
        Console.WriteLine($"Título: {libroMasCaro?.Titulo}, Precio: {libroMasCaro?.Precio:C}");

        Console.WriteLine();

        Console.WriteLine("Libro con menor precio:");
        Libro libroMasBarato = casoLinq.GetMenorPrecio();
        Console.WriteLine($"Título: {libroMasBarato?.Titulo}, Precio: {libroMasBarato?.Precio:C}");

        Console.WriteLine();

        Console.WriteLine("Libros con precio mayor al promedio");
        List<Libro> librosMayorPromedio = casoLinq.GetMayorPromedio();
        foreach (Libro libro in librosMayorPromedio)
        {
            Console.WriteLine($"Título: {libro.Titulo}, Precio: {libro.Precio:C}");
        }

        Console.WriteLine();

        Console.WriteLine("Libros ordenados por precio de mayor a menor:");
        List<Libro> librosOrdenados = casoLinq.GetLibrosOrdenados();
        foreach (Libro libro in librosOrdenados)
        {
            Console.WriteLine($"Título: {libro.Titulo}, Precio: {libro.Precio:C}");
        }





    }
}
