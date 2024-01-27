using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects;

public record PostDtoForUpdate() : PostDtoForManipulation
{
    [Required]
    public int Id { get; set; }
}