using AcademiaWebAPI.DBContext;
using AcademiaWebAPI.DTOs.DTOsResponse;
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
}