using Dsw2026Ej11.Domain;

namespace Dsw2026Ej11.Collections;

//Crear un diccionario donde la clave sea el legajo y el valor el alumno
//Incluir un método para agregar un alumno al diccionario
//Incluir un método para buscar un alumno utilizando la clave
//Incluir un método para retornar el diccionario
//Incluir un método para eliminar un alumno utilizando la clave
public class CasoDictionary
{
    private Dictionary <int, Alumno > alumnos = new Dictionary<int, Alumno>();
    

    public void AgregarAlumno(int legajo, Alumno alumno)
    { //aqui debemos agregar el metodo para verificar si ya existe la clave?
        if (!alumnos.ContainsKey(legajo))
        {
            alumnos.Add(legajo, alumno);

        }
        else
        {
            Console.WriteLine($"El legajo ya existe");
           
        }
      
    }

    public Alumno BuscarAlumno(int legajo)
    {
        if (alumnos.TryGetValue(legajo, out Alumno alumnoEncontrado))
        {
            return alumnoEncontrado;
        }
        return null; 
    }

    public Dictionary<int, Alumno> RetornarDiccionario()
    {
        return alumnos;
    }

    public bool EliminarAlumno(int legajo)
    {
        return alumnos.Remove(legajo);
    }
}
