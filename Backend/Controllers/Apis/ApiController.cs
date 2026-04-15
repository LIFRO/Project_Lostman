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

    [HttpPost("create")]
    public async Task<IActionResult> CreateApi(Api request)
    {
        var api = await _service.CreateApi(request);

        if(api == null) return StatusCode(500, "save failed");

        return Ok(api);
    }
}
