using AcademiaWebAPI.DBContext;
using AcademiaWebAPI.Dtos.DtosRequest;
using AcademiaWebAPI.DTOs.DTOsResponse;
using AcademiaWebAPI.Models;
using AcademiaWebAPI.Services;
using Microsoft.EntityFrameworkCore;

namespace AcademiaWebAPI.Repositories;

public class ProfesoresRepository: IProfesoresRepository
{

    private readonly AcademiaWebAPIDBContext _context;
    public ProfesoresRepository(AcademiaWebAPIDBContext context)
    {
        _context = context;
    }
    
    public async Task<List<ProfesorResponseDto>> ObtenerTodos()
    {
        return await _context.Profesores
            .Select(p => new ProfesorResponseDto()
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Apellido = p.Apellido,
                Telefono = p.Telefono,
                Titulo = p.Titulo,
                // No se requiere .Include() ya que el acceso a p.Cursos dentro del .Select()
                // le indica a EF Core que debe generar un JOIN implícito y cargar los datos relacionados.
                Cursos = p.Cursos.Select(c => new CursoResponseDto()
                {
                    Id = c.Id,
                    Nombre = c.Nombre,
                    Descripcion = c.Descripcion
                }).ToList()
            }).ToListAsync();
    }

    public async Task<ProfesorResponseDto?> Obtener(int id)
    {
        return await _context.Profesores
            .Where(p=>p.Id == id)
            .Select(p=> new ProfesorResponseDto()
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Apellido = p.Apellido,
                Telefono = p.Telefono,
                Titulo = p.Titulo,
                Cursos = p.Cursos.Select(c=> new CursoResponseDto()
                {
                    Id = c.Id,
                    Nombre = c.Nombre,
                    Descripcion = c.Descripcion
                }).ToList()
            }).FirstOrDefaultAsync();
    }

    public async Task<ProfesorResponseDto> Crear(ProfesorRequestDto profesorRequestDto)
    {
        var profesor = new Profesor()
        {
            Nombre = profesorRequestDto.Nombre,
            Apellido = profesorRequestDto.Apellido,
            Telefono = profesorRequestDto.Telefono,
            Titulo = profesorRequestDto.Titulo
        };
        
        _context.Profesores.Add(profesor);
        // Devuelve el id al guardar profesor
        await _context.SaveChangesAsync();

        return new ProfesorResponseDto()
        {
            Id = profesor.Id,
            Nombre = profesor.Nombre,
            Apellido = profesor.Apellido,
            Telefono = profesor.Telefono,
            Titulo = profesor.Titulo
        };
    }
}