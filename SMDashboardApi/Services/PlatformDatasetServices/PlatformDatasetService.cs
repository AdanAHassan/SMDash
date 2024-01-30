using SMDashboardApi.Data;

namespace SMDashboardApi.Services.PlatformDatasetServices;

public class PlatformDatasetService: IPlatformDatasetService
{
    public readonly DataContext _context;
    public PlatformDatasetService(DataContext context)
    {
        _context = context;
    }

    public async Task<List<PlatformDataset>> GetAllPlatformDatasets()
    {
        return await _context.PlatformDatasets.OrderBy(c => c.Id).ToListAsync();
    }

    public async Task<PlatformDataset?> GetPlatformDatasetById(int id)
    {
        return await _context.PlatformDatasets.FindAsync(id);
    }
    public async Task<List<PlatformDataset>?> GetPlatformDatasetsByClientId(int id)
    {
        return await _context.PlatformDatasets.Where(x => x.ClientId == id).OrderBy(x => x.Id).ToListAsync();
    }

    public async Task<List<PlatformDataset>?> GetPlatformDatasetsByClientName(string name)
    {
        int clientId = _context.Clients.Where(x => x.Name == name).Select(x => x.Id).ToList().FirstOrDefault(-1);
        if(clientId == -1) return null;
        return await _context.PlatformDatasets.Where(x => x.ClientId == clientId).OrderBy(x => x.Id).ToListAsync();
    }

    public async Task<List<PlatformDatasetRender>?> GetRenderedPlatformDatasetsByClientId(int id)
    {
        return await _context.PlatformDatasets.Where(x => x.ClientId == id).Select(param => new PlatformDatasetRender{
            ClientId = param.ClientId,
            Metrics = param.PlatformMetrics.Select(y => y.Metric),
            Id = param.Id,
            Platform = param.Platform
        }).OrderBy(x => x.Id).ToListAsync();
    }

    public async Task<List<PlatformDatasetRender>?> GetRenderedPlatformDatasetsByClientName(string name)
    {
        int clientId = _context.Clients.Where(x => x.Name == name).Select(x => x.Id).ToList().FirstOrDefault(-1);
        if(clientId == -1) return null;
        return await _context.PlatformDatasets.Where(x => x.ClientId == clientId).Select(param => new PlatformDatasetRender{
            ClientId = param.ClientId,
            Metrics = param.PlatformMetrics.Select(y => y.Metric),
            Id = param.Id,
            Platform = param.Platform
        }).OrderBy(x => x.Id).ToListAsync();
    }

    public async Task<PlatformDataset?> AddPlatformDataset(PlatformDataset platformDataset)
    {
        await _context.PlatformDatasets.AddAsync(platformDataset);
        _context.SaveChanges();
        return await _context.PlatformDatasets.OrderByDescending(x => x.Id).FirstOrDefaultAsync();
    }

    public async Task<List<PlatformDataset>?> DeletePlatformDataset(int id)
    {
        var platformDataset = await _context.PlatformDatasets.FindAsync(id);
        if(platformDataset is null) return null;
        _context.PlatformDatasets.Remove(platformDataset);
        await _context.SaveChangesAsync();
        return await GetAllPlatformDatasets();
    }
}
