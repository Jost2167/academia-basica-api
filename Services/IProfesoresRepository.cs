using AcademiaWebAPI.Dtos.DtosRequest;
using AcademiaWebAPI.DTOs.DTOsResponse;


namespace AcademiaWebAPI.Services;

public interface IProfesoresRepository
{
    Task<List<ProfesorResponseDto>> ObtenerTodos();
    Task<ProfesorResponseDto?> Obtener(int id);
    Task<ProfesorResponseDto> Crear(ProfesorRequestDto profesorRequestDto);
    Task<ProfesorResponseDto> Actualizar(int id, ProfesorRequestDto profesorRequestDto);

}