namespace AcademiaWebAPI.Models;

public class Estudiante: Persona
{
    public string GradoAcademico { get; set; }
    
    public ICollection<Curso> Cursos { get; set; } = new List<Curso>();
}