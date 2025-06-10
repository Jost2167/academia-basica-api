using AcademiaWebAPI.Models;

namespace AcademiaWebAPI.Services;

public interface IProfesoresRepository
{
    List<Profesor> ObtenerTodos();
}