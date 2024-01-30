namespace SMDashboardApi.Services.MetricProgressServices;

public interface IMetricProgressService
{
    Task<List<MetricProgress>> GetMetricProgressList();
    Task<MetricProgress?> GetMetricProgressById(int id);
    Task<List<MetricProgress>> GetMetricProgressByMetricId(int id);
    Task<MetricProgress?> AddMetricProgress(MetricProgress metricProgress);
    Task<List<MetricProgress>?> DeleteMetricProgress(int id);
}
