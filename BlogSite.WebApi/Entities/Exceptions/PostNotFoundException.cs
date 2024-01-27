namespace Entities.Exceptions;

public class PostNotFoundException : NotFoundException
{
    public PostNotFoundException(int id) : base($"The post with id : {id} could not found")
    {

    }
}