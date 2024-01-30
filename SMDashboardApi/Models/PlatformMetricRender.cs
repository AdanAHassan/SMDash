namespace SMDashboardApi.Models;

public class PlatformMetricRender
{
    public int Id { get; set; }
    public int PlatformDatasetId { get; set; }
    public string Metric { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public int Target { get; set; }
    public IEnumerable<int> Progress { get; set; } = new List<int>();
}
