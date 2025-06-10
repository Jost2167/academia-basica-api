using AcademiaWebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AcademiaWebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class Profesores : ControllerBase
{

    [HttpGet]
    public ActionResult<List<Profesor>> ObtenerTodos()
    {
        
    }
    
    
}