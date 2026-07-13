using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Mvc;
using Backend.Service;
using Backend.Models;

namespace Backend.Controllers.Apis;

[ApiController]
[Route("/api/")]
public class ApiController : ControllerBase
{
    private readonly ApiService _service;

    public ApiController(ApiService service) => _service = service;

    [HttpPost("createCatalog")]
    public async Task<IActionResult> CreateFolder(ApiCatalog request)
    {
        var catalog = await _service.CreateCatalog(request);

        Console.WriteLine("sucess");
        return Ok(catalog);
    }

    [HttpPost("createApi")]
    public async Task<IActionResult> CreateApi(Api request)
    {
        var api = await _service.CreateApi(request);

        Console.WriteLine("sucess2");
        return Ok(api);
    }

    [HttpGet("GetItemsUnderParent")]
    public async Task<IActionResult> GetItemsUnderParent ([FromQuery] long? id)
    {
        var (catalogs, apis) = await _service.GetItemsUnderParent(id);
        return Ok(new { catalogs, apis });
    }

    [HttpGet("FetchItems")]
    public async Task<IActionResult> FetchItems()
    {
        Console.WriteLine("helol");
        var (catalogs, apis) = await _service.FetchItems();
        Console.WriteLine("done");

        return Ok(new { catalogs, apis });
    }

    [HttpPatch("AddItemUnderFolder")]
    public async Task<IActionResult> AddItemUnderFolder(ExplorerItemRequest request)
    {
        ExplorerItemRequest item = await_service.AddItemUnderFolder(request);

        return Ok(request);
    }
}
