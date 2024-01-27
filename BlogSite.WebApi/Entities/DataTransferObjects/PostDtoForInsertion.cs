namespace Entities.DataTransferObjects;

public record PostDtoForInsertion() : PostDtoForManipulation
{
    public int Id { get; set; }
}