using AcademiaWebAPI.DTOs.DTOsResponse;
using AcademiaWebAPI.Models;

namespace AcademiaWebAPI.Services;

public interface IProfesoresRepository
{
    Task<List<ProfesorResponseDTO>> ObtenerTodos();
}