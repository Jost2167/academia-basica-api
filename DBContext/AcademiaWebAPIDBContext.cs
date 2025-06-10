using AcademiaWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AcademiaWebAPI.DBContext;

public class AcademiaWebAPIDBContext: DbContext
{
    public AcademiaWebAPIDBContext(DbContextOptions<AcademiaWebAPIDBContext> options): base(options)
    {
        
    }
    
    public DbSet<Persona> Personas { get; set; }
    public DbSet<Profesor> Profesores { get; set; }
    public DbSet<Estudiante> Estudiantes { get; set; }
    public DbSet<Curso> Cursos { get; set; }
    
}