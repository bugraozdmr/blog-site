using Entities.DataTransferObjects;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Presentation.ActionFilters;
using Services.Concrats;
using JsonSerializer = System.Text.Json.JsonSerializer;



namespace Presentation.Controllers;

[ServiceFilter(typeof(LogFilterAttribute),Order = 2)]
[ApiController]
[Route("/api/post")]
public class PostController : ControllerBase
{
    private readonly IServiceManager _manager;

    public PostController(IServiceManager manager)
    {
        _manager = manager;
    }

    [HttpHead]
    [HttpGet("getAllPosts")]
    public async Task<IActionResult> GetAllPostsAsync(
        [FromQuery] PostParameters postParameters)
    {
        if (postParameters.PageNumber == 0 && postParameters.PageSize == 0)
        {
            postParameters.PageSize = 5;
            postParameters.PageNumber = 1;
        }

        var pagedResult = await _manager
            .PostService
            .GetAllPostsAsync(postParameters, false);
        
        Response.Headers.Add("X-Pagination",
            JsonSerializer.Serialize(pagedResult.metadata));
        
        return Ok(new { data = pagedResult.posts });
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOnePostAsync([FromRoute(Name = "id")] int id)
    {
        var post = await _manager.PostService.GetOnePostByIdAsync(id, false);

        return Ok(new { data = post });
    }
    
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [HttpPost]
    public async Task<IActionResult> CreateOneBookAsync([FromBody] PostDtoForInsertion postDto)
    {
        var post = await _manager.PostService.CreateOnePostAsync(postDto);

        return StatusCode(201, new { success = true, data = post });
    }
    
    [ServiceFilter(typeof(ValidationFilterAttribute),Order = 1)]
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateOnePostAsync([FromRoute(Name = "id")] int id, [FromBody] PostDtoForUpdate postDto)
    {
        await _manager.PostService.UpdateOnePostAsync(id, postDto, false);
        
        return Ok(new { data = postDto });
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteOnePost([FromRoute(Name = "id")] int id)
    {
        await _manager.PostService.DeleteOnePostAsync(id, false);

        return NoContent();
    }

    [HttpOptions]
    public IActionResult GetBooksOptions()
    {
        Response.Headers.Add("Allow","Get, PUT, POST, PATCH, DELETE, HEAD, OPTIONS");

        return Ok();
    }
}