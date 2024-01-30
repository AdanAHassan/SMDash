using SMDashboardApi.Data;

namespace SMDashboardApi.Services.PlatformMetricServices;

public class PlatformMetricService: IPlatformMetricService
{
    public readonly DataContext _context;
    public PlatformMetricService(DataContext context)
    {
        _context = context;
    }

    public async Task<List<PlatformMetric>> GetAllPlatformMetrics()
    {
        return await _context.PlatformMetrics.OrderBy(c => c.Id).ToListAsync();
    }

    public async Task<PlatformMetric?> GetPlatformMetricById(int id)
    {
        return await _context.PlatformMetrics.FindAsync(id);
    }

    public async Task<List<PlatformMetric>> GetPlatformMetricByDatasetId(int id)
    {
        return await _context.PlatformMetrics.Where(x => x.PlatformDatasetId == id).OrderBy(c => c.Id).ToListAsync();
    }

    public async Task<List<PlatformMetricRender>> GetRenderedPlatformMetricByDatasetId(int id)
    {
        return await _context.PlatformMetrics.Where(x => x.PlatformDatasetId == id).Select(
            item => new PlatformMetricRender{
            Id = item.Id,
            PlatformDatasetId = item.PlatformDatasetId,
            Metric = item.Metric,
            Target = item.Target,
            StartDate = item.StartDate,
            Progress = item.ProgressList.Select(y => y.CurrentValue)
            }
        ).OrderBy(c => c.Id).ToListAsync();
    }

    public async Task<PlatformMetric?> AddPlatformMetric(PlatformMetric platformMetric)
    {
        await _context.PlatformMetrics.AddAsync(platformMetric);
        _context.SaveChanges();
        return await _context.PlatformMetrics.OrderByDescending(x => x.Id).FirstOrDefaultAsync();
    }

    public async Task<List<PlatformMetric>?> DeletePlatformMetric(int id)
    {
        var platformMetric = await _context.PlatformMetrics.FindAsync(id);
        if(platformMetric is null) return null;
        _context.PlatformMetrics.Remove(platformMetric);
        await _context.SaveChangesAsync();
        return await GetAllPlatformMetrics();
    }
}
