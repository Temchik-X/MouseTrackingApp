using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TrackingController : ControllerBase
{
    private readonly IMousePositionService _service;

    public TrackingController(IMousePositionService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Save([FromBody] List<MousePositionDto> positions)
    {
        try
        {
            await _service.SaveAsync(positions);
            return Ok();
        }
        catch (ArgumentException ex) {
            return BadRequest(new { error = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, "An error occurred while saving the data.");
        }
        
    }
}