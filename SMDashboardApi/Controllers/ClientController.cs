using Microsoft.AspNetCore.Mvc;
using SMDashboardApi.Services.ClientServices;
namespace SMDashboardApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClientController: ControllerBase
{
    private readonly IClientService _clientService;

    public ClientController(IClientService clientService)
    {
        _clientService = clientService;
    }

    [HttpGet("Paginated/{pageIndex:int}/{pageSize:int}")]
    public ActionResult<PaginatedResponse<Client>> GetAllClients(int pageIndex, int pageSize)
    {
        var result = _clientService.GetAllClients(pageIndex, pageSize);
        if(result is null) return NotFound("Error:\tCould not get all clients");
        return Ok(result);
    }

    [HttpGet("{id:int}")]
    [ActionName(nameof(GetClientById))]
    public async Task<ActionResult<Client>> GetClientById(int id)
    {
        var result = await _clientService.GetClientById(id);
        if(result is null) return NotFound("Error:\tCould not get client by id");
        return Ok(result);
    }

    [HttpGet("IdList")]
    public async Task<ActionResult<List<int>>> GetClientIdList()
    {
        var result = await _clientService.GetClientIdList();
        if(result is null) return NotFound("Error:\tCould not get client ids");
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<Client>> AddClient([FromBody] Client client)
    {
        var result = await _clientService.AddClient(client);
        if(result is null) return BadRequest("Error:\tCould not add client");
        Console.WriteLine(result.Id + result.Name);
        return CreatedAtAction(nameof(GetClientById), new { id = result.Id }, result);
    }

    [HttpPut("Update")]
    public async Task<ActionResult<Client>> UpdateClient([FromBody] Client request)
    {
        var result = await _clientService.UpdateClient(request);
        if(result is null) return BadRequest("Error:\tCould not update client");
        return Ok(result);
    }

    [HttpDelete]
    public async Task<ActionResult<List<Client>>> DeleteClient(int id)
    {
        var result = await _clientService.DeleteClient(id);
        if(result is null) return BadRequest("Error:\tCould not delete client");
        return Ok(result);
    }
}
