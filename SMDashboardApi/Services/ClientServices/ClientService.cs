using SMDashboardApi.Data;
using SMDashboardApi.Helpers;

namespace SMDashboardApi.Services.ClientServices;

public class ClientService: IClientService
{
    public readonly DataContext _context;
    public ClientService(DataContext context)
    {
        _context = context;
    }

    public PaginatedResponse<Client> GetAllClients(int pageIndex, int pageSize)
    {
        return new PaginatedResponse<Client>(_context.Clients.OrderBy(c => c.Id), pageIndex, pageSize, null);
    }

    public async Task<Client?> GetClientById(int id)
    {
        return await _context.Clients.FindAsync(id);
    }

    public async Task<List<int>> GetClientIdList()
    {
        return await _context.Clients.Select(x => x.Id).OrderBy(x => x).ToListAsync();
    }

    public async Task<Client?> AddClient(Client client)
    {
        await _context.Clients.AddAsync(client);
        _context.SaveChanges();
        return await _context.Clients.OrderByDescending(x => x.Id).FirstOrDefaultAsync();
    }

    public async Task<Client?> UpdateClient(Client request)
    {
        var client = await _context.Clients.FindAsync(request.Id);
        if(client is null) return null;
        Helper.ChangeGenericString(request.Name, "name", client);
        await _context.SaveChangesAsync();
        return await GetClientById(request.Id);
    }

    public async Task<Client?> DeleteClient(int id)
    {
        var client = await _context.Clients.FindAsync(id);
        if(client is null) return null;
        _context.Clients.Remove(client);
        await _context.SaveChangesAsync();
        return await _context.Clients.OrderByDescending(x => x.Id).FirstOrDefaultAsync();
    }
}
