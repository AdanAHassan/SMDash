using Microsoft.AspNetCore.Mvc;
using SMDashboardApi.Services.MetricProgressServices;
namespace SMDashboardApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MetricProgressController: ControllerBase
{
    private readonly IMetricProgressService _metricProgressService;

    public MetricProgressController(IMetricProgressService metricProgressService)
    {
        _metricProgressService = metricProgressService;
    }

    [HttpGet]
    public async Task<ActionResult<List<MetricProgress>>> GetMetricProgressList()
    {
        var result = await _metricProgressService.GetMetricProgressList();
        if(result is null) return NotFound("Error:\tCould not get all metricProgresss");
        return Ok(result);
    }

    [HttpGet("{id:int}")]
    [ActionName(nameof(GetMetricProgressById))]
    public async Task<ActionResult<MetricProgress>> GetMetricProgressById(int id)
    {
        var result = await _metricProgressService.GetMetricProgressById(id);
        if(result is null) return NotFound("Error:\tCould not get metricProgress by id");
        return Ok(result);
    }

    [HttpGet("ByMetricId/{id:int}")]
    [ActionName(nameof(GetMetricProgressByMetricId))]
    public async Task<ActionResult<List<MetricProgress>>> GetMetricProgressByMetricId(int id)
    {
        var result = await _metricProgressService.GetMetricProgressByMetricId(id);
        if(result is null) return NotFound("Error:\tCould not get metricProgress by metric id");
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<MetricProgress>> AddMetricProgress([FromBody] MetricProgress metricProgress)
    {
        var result = await _metricProgressService.AddMetricProgress(metricProgress);
        if(result is null) return BadRequest("Error:\tCould not add metricProgress");
        return CreatedAtAction(nameof(GetMetricProgressById), new { id = result.Id }, result);
    }

    [HttpDelete]
    public async Task<ActionResult<List<MetricProgress>>> DeleteMetricProgress(int id)
    {
        var result = await _metricProgressService.DeleteMetricProgress(id);
        if(result is null) return BadRequest("Error:\tCould not delete metricProgress");
        return Ok(result);
    }
}

