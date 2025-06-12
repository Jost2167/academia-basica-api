using AcademiaWebAPI.DTOs.DTOsResponse;
using AcademiaWebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace AcademiaWebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProfesoresController : ControllerBase
{

    private readonly IProfesoresRepository _profesoresRepository;
    public ProfesoresController(IProfesoresRepository profesoresRepository)
    {
        _profesoresRepository = profesoresRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProfesorResponseDto>>> ObtenerTodos()
    {
        List<ProfesorResponseDto> profesoresDto = await _profesoresRepository.ObtenerTodos(); 
        
        return Ok(profesoresDto);
    }

    [HttpGet("{profesorId}")]
    public async Task<ActionResult<ProfesorResponseDto>> Obtener(int profesorId)
    {
        ProfesorResponseDto? profesorDto = await _profesoresRepository.Obtener(profesorId);

        if (profesorDto is null)
        {
            return NotFound($"No se encontró el profesor con ID {profesorId}");
        }
        
        return Ok(profesorDto);
    }
    
    
}