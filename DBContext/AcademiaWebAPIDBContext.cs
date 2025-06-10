using AcademiaWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AcademiaWebAPI.DBContext;

public class AcademiaWebAPIDBContext: DbContext
{
    public AcademiaWebAPIDBContext(DbContextOptions<AcademiaWebAPIDBContext> options): base(options)
    {
        
    }
    
    // DbSets representan las tablas principales
    public DbSet<Persona> Personas { get; set; }
    public DbSet<Profesor> Profesores { get; set; }
    public DbSet<Estudiante> Estudiantes { get; set; }
    public DbSet<Curso> Cursos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Define la estrategia de herencia como Table-Per-Hierarchy (TPH).
        modelBuilder.Entity<Persona>().UseTphMappingStrategy();

        // Define el discriminador para distinguir subtipos de Persona (Profesor, Estudiante).
        modelBuilder.Entity<Persona>()
            .HasDiscriminator<string>("Tipo") // Nombre de la columna discriminadora
            .HasValue<Persona>("Persona")     // Valor para el tipo base
            .HasValue<Profesor>("Profesor")   // Valor para Profesor
            .HasValue<Estudiante>("Estudiante"); // Valor para Estudiante
    }
}