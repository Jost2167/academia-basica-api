namespace AcademiaWebAPI.Models;

public class Curso
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public int ProfesorId { get; set; }

    public ICollection<Estudiante> Estudiantes { get; set; } = new HashSet<Estudiante>();
    public Profesor Profesor { get; set; }
}