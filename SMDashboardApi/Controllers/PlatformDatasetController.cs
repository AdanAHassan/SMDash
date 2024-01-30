using Microsoft.AspNetCore.Mvc;
using SMDashboardApi.Services.PlatformDatasetServices;
namespace SMDashboardApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PlatformDatasetController: ControllerBase
{
    private readonly IPlatformDatasetService _platformDatasetService;

    public PlatformDatasetController(IPlatformDatasetService platformDatasetService)
    {
        _platformDatasetService = platformDatasetService;
    }

    [HttpGet]
    public async Task<ActionResult<List<PlatformDataset>>> GetAllPlatformDatasets()
    {
        var result = await _platformDatasetService.GetAllPlatformDatasets();
        if(result is null) return NotFound("Error:\tCould not get all platformDatasets");
        return Ok(result);
    }

    [HttpGet("{id:int}")]
    [ActionName(nameof(GetPlatformDatasetById))]
    public async Task<ActionResult<PlatformDataset>> GetPlatformDatasetById(int id)
    {
        var result = await _platformDatasetService.GetPlatformDatasetById(id);
        if(result is null) return NotFound("Error:\tCould not get platformDataset by id");
        return Ok(result);
    }

    [HttpGet("ByClientId/{id:int}")]
    [ActionName(nameof(GetPlatformDatasetsByClientId))]
    public async Task<ActionResult<List<PlatformDataset>>> GetPlatformDatasetsByClientId(int id)
    {
        var result = await _platformDatasetService.GetPlatformDatasetsByClientId(id);
        if(result is null) return NotFound("Error:\tCould not get platformDataset by client id");
        return Ok(result);
    }

    [HttpGet("ByClientName/{name}")]
    [ActionName(nameof(GetPlatformDatasetsByClientName))]
    public async Task<ActionResult<List<PlatformDataset>>> GetPlatformDatasetsByClientName(string name)
    {
        var result = await _platformDatasetService.GetPlatformDatasetsByClientName(name);
        if(result is null) return NotFound("Error:\tCould not get platformDataset by client name");
        return Ok(result);
    }

    // Rendered data ahead of time

    [HttpGet("RenderedByClientId/{id:int}")]
    [ActionName(nameof(GetRenderedPlatformDatasetsByClientId))]
    public async Task<ActionResult<List<PlatformDatasetRender>>> GetRenderedPlatformDatasetsByClientId(int id)
    {
        var result = await _platformDatasetService.GetRenderedPlatformDatasetsByClientId(id);
        if(result is null) return NotFound("Error:\tCould not get platformDataset by client id");
        return Ok(result);
    }

    [HttpGet("RenderedByClientName/{name}")]
    [ActionName(nameof(GetRenderedPlatformDatasetsByClientName))]
    public async Task<ActionResult<List<PlatformDatasetRender>>> GetRenderedPlatformDatasetsByClientName(string name)
    {
        var result = await _platformDatasetService.GetRenderedPlatformDatasetsByClientName(name);
        if(result is null) return NotFound("Error:\tCould not get platformDataset by client name");
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<PlatformDataset>> AddPlatformDataset([FromBody] PlatformDataset platformDataset)
    {
        var result = await _platformDatasetService.AddPlatformDataset(platformDataset);
        if(result is null) return BadRequest("Error:\tCould not add platformDataset");
        return CreatedAtAction(nameof(GetPlatformDatasetById), new { id = result.Id }, result);
    }

    [HttpDelete]
    public async Task<ActionResult<List<PlatformDataset>>> DeletePlatformDataset(int id)
    {
        var result = await _platformDatasetService.DeletePlatformDataset(id);
        if(result is null) return BadRequest("Error:\tCould not delete platformDataset");
        return Ok(result);
    }
}

