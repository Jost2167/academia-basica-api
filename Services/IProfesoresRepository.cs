using AcademiaWebAPI.DTOs.DTOsResponse;


namespace AcademiaWebAPI.Services;

public interface IProfesoresRepository
{
    Task<List<ProfesorResponseDto>> ObtenerTodos();
    Task<ProfesorResponseDto?> Obtener(int id);
}