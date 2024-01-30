namespace SMDashboardApi.Services.PlatformMetricServices;

public interface IPlatformMetricService
{
    Task<List<PlatformMetric>> GetAllPlatformMetrics();
    Task<PlatformMetric?> GetPlatformMetricById(int id);
    Task<List<PlatformMetric>> GetPlatformMetricByDatasetId(int id);
    Task<List<PlatformMetricRender>> GetRenderedPlatformMetricByDatasetId(int id);
    Task<PlatformMetric?> AddPlatformMetric(PlatformMetric platformMetric);
    Task<List<PlatformMetric>?> DeletePlatformMetric(int id);
}
