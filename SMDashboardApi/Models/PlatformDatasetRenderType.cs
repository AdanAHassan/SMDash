namespace SMDashboardApi.Models;

public class PlatformDatasetRender
{
    public int Id { get; set; }
    public int ClientId { get; set; }
    public CustomEnums.Platform Platform { get; set; }
    public IEnumerable<string> Metrics { get; set; } = new List<string>();
}
