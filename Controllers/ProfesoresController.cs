using AcademiaWebAPI.DTOs.DTOsResponse;
using AcademiaWebAPI.Models;
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
    public async Task<ActionResult<IEnumerable<Profesor>>> ObtenerTodos()
    {
        List<ProfesorResponseDTO> profesoresDTO = new List<ProfesorResponseDTO>();
        profesoresDTO = await _profesoresRepository.ObtenerTodos();
        
        return Ok(profesoresDTO);
    }
    
    
}