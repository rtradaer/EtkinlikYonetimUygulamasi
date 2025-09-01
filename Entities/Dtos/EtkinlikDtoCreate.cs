namespace Entities.Dtos;

public record EtkinlikDtoCreate : EtkinlikDto
{
    public string CreatedBy { get; set; } = "-";
}