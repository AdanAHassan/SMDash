using Microsoft.AspNetCore.Mvc;
using SMDashboardApi.Services.PlatformMetricServices;
namespace SMDashboardApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PlatformMetricController: ControllerBase
{
    private readonly IPlatformMetricService _platformMetricService;

    public PlatformMetricController(IPlatformMetricService platformMetricService)
    {
        _platformMetricService = platformMetricService;
    }

    [HttpGet]
    public async Task<ActionResult<List<PlatformMetric>>> GetAllPlatformMetrics()
    {
        var result = await _platformMetricService.GetAllPlatformMetrics();
        if(result is null) return NotFound("Error:\tCould not get all platformMetrics");
        return Ok(result);
    }

    [HttpGet("{id:int}")]
    [ActionName(nameof(GetPlatformMetricById))]
    public async Task<ActionResult<PlatformMetric>> GetPlatformMetricById(int id)
    {
        var result = await _platformMetricService.GetPlatformMetricById(id);
        if(result is null) return NotFound("Error:\tCould not get platformMetric by id");
        return Ok(result);
    }

    [HttpGet("ByDatasetId/{id:int}")]
    [ActionName(nameof(GetPlatformMetricByDatasetId))]
    public async Task<ActionResult<List<PlatformMetric>>> GetPlatformMetricByDatasetId(int id)
    {
        var result = await _platformMetricService.GetPlatformMetricByDatasetId(id);
        if(result is null) return NotFound("Error:\tCould not get platformMetric by dataset id");
        return Ok(result);
    }

    [HttpGet("RenderedByDatasetId/{id:int}")]
    [ActionName(nameof(GetRenderedPlatformMetricByDatasetId))]
    public async Task<ActionResult<List<PlatformMetricRender>>> GetRenderedPlatformMetricByDatasetId(int id)
    {
        var result = await _platformMetricService.GetRenderedPlatformMetricByDatasetId(id);
        if(result is null) return NotFound("Error:\tCould not get platformMetric by dataset id");
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<PlatformMetric>> AddPlatformMetric([FromBody] PlatformMetric platformMetric)
    {
        var result = await _platformMetricService.AddPlatformMetric(platformMetric);
        if(result is null) return BadRequest("Error:\tCould not add platformMetric");
        return CreatedAtAction(nameof(GetPlatformMetricById), new { id = result.Id }, result);
    }

    [HttpDelete]
    public async Task<ActionResult<List<PlatformMetric>>> DeletePlatformMetric(int id)
    {
        var result = await _platformMetricService.DeletePlatformMetric(id);
        if(result is null) return BadRequest("Error:\tCould not delete platformMetric");
        return Ok(result);
    }
}

