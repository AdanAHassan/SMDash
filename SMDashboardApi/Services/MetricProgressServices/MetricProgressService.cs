using SMDashboardApi.Data;

namespace SMDashboardApi.Services.MetricProgressServices;

public class MetricProgressService: IMetricProgressService
{
    public readonly DataContext _context;
    public MetricProgressService(DataContext context)
    {
        _context = context;
    }

    public async Task<List<MetricProgress>> GetMetricProgressList()
    {
        return await _context.MetricProgressList.OrderBy(c => c.Id).ToListAsync();
    }

    public async Task<MetricProgress?> GetMetricProgressById(int id)
    {
        return await _context.MetricProgressList.FindAsync(id);
    }

    public async Task<List<MetricProgress>> GetMetricProgressByMetricId(int id)
    {
        return await _context.MetricProgressList.Where(x => x.PlatformMetricId == id).OrderBy(c => c.Id).ToListAsync();
    }

    public async Task<MetricProgress?> AddMetricProgress(MetricProgress metricProgress)
    {
        await _context.MetricProgressList.AddAsync(metricProgress);
        _context.SaveChanges();
        return await _context.MetricProgressList.OrderByDescending(x => x.Id).FirstOrDefaultAsync();
    }

    public async Task<List<MetricProgress>?> DeleteMetricProgress(int id)
    {
        var metricProgress = await _context.MetricProgressList.FindAsync(id);
        if(metricProgress is null) return null;
        _context.MetricProgressList.Remove(metricProgress);
        await _context.SaveChangesAsync();
        return await GetMetricProgressList();
    }
}
