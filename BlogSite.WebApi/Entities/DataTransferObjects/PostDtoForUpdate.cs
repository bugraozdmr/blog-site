using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects;

public record PostDtoForUpdate()
{
    [Required]
    public int Id { get; set; }
}