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
        
        // Devuelve una respuesta HTTP 200 (OK) con todos los datos de los profesores en formato DTO.
        return Ok(profesoresDto);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProfesorResponseDto>> Obtener(int id)
    {
        ProfesorResponseDto? profesorDto = await _profesoresRepository.Obtener(id);

        if (profesorDto is null)
        {
            // Devuelve un resultado 404 (No encontrado) si no existe un profesor con el ID proporcionado.
            return NotFound($"No se encontró el profesor con ID {id}");
        }
        
        // Devuelve una respuesta HTTP 200 (OK) con los datos del profesor en formato DTO.
        return Ok(profesorDto);
    }

    [HttpPost]
    public async Task<ActionResult<ProfesorResponseDto>> Crear([FromBody] ProfesorRequestDto profesorRequestDto)
    {
        var profesorDto =  await _profesoresRepository.Crear(profesorRequestDto);

        // Devuelve una respuesta HTTP 201 (Created) indicando que el recurso fue creado correctamente 
        // y la URL para acceder al recurso recién creado (GET /api/profesores/{Id}
        return CreatedAtAction(nameof(Obtener), new {id = profesorDto.Id}, profesorDto);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ProfesorResponseDto>> Actualizar(int id, [FromBody] ProfesorRequestDto profesorRequestDto)
    {
        var profesorResponseDto = await _profesoresRepository.Actualizar(id, profesorRequestDto);

        if (profesorResponseDto is null)
        {
            // Devuelve un resultado 404 (No encontrado) si no existe un profesor con el ID proporcionado.
            return NotFound($"No se encontró el profesor con ID {id}");
        }
        
        return Ok(profesorResponseDto);
    } 
    
}