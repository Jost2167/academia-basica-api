namespace AcademiaWebAPI.Models;

public class Estudiante: Persona
{
    public string GradoAcademico { get; set; }
    
    public List<Curso> Cursos { get; set; }
}