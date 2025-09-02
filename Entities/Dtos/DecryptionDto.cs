using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos;

public record DecryptionDto
{
    public String? Email { get; set; }
    
    public String? EncryptedPassword { get; set; }

    public String? DecryptedPassword { get; set; }

}