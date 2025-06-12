using AcademiaWebAPI.DBContext;
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
    
    public async Task<List<ProfesorResponseDTO>> ObtenerTodos()
    {
        return await _context.Profesores
            .Include(p=>p.Cursos)
            .Select(p => new ProfesorResponseDTO()
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Apellido = p.Apellido,
                Telefono = p.Telefono,
                Titulo = p.Titulo,
                Cursos = p.Cursos.Select(c => new CursoResponseDTO()
                {
                    Id = c.Id,
                    Nombre = c.Nombre,
                    Descripcion = c.Descripcion
                }).ToList()
            }).ToListAsync();
    }
}