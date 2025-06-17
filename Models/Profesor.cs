namespace AcademiaWebAPI.Models;

public class Profesor: Persona
{
    public string Titulo { get; set; }

    public List<Curso> Cursos { get; set; } = new List<Curso>();
}