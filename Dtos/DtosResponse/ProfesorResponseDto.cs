namespace AcademiaWebAPI.DTOs.DTOsResponse;

public class ProfesorResponseDto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Telefono { get; set; }
    public string Titulo { get; set; }
    public List<CursoResponseDto> Cursos { get; set; }
}