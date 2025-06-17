using AcademiaWebAPI.Dtos.DtosRequest;
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

    [HttpGet("{Id}")]
    public async Task<ActionResult<ProfesorResponseDto>> Obtener(int Id)
    {
        ProfesorResponseDto? profesorDto = await _profesoresRepository.Obtener(Id);

        if (profesorDto is null)
        {
            // Devuelve un resultado 404 (No encontrado) si no existe un profesor con el ID proporcionado.
            return NotFound($"No se encontró el profesor con ID {Id}");
        }
        
        // Devuelve una respuesta HTTP 200 (OK) con los datos del profesor en formato DTO.
        return Ok(profesorDto);
    }

    [HttpPost]
    public async Task<ActionResult<ProfesorResponseDto>> Crear([FromBody] ProfesorRequestDto profesorRequestDto)
    {
        var profesorDto =  await _profesoresRepository.Crear(profesorRequestDto);
        
        return CreatedAtAction(nameof(Obtener), new {Id = profesorDto.Id}, profesorDto);
    } 
    
    
    
}