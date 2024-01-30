using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMDashboardApi.Models;

public class PlatformMetric
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [ForeignKey("PlatformDatasetId")]
    public int PlatformDatasetId { get; set; }
    public string Metric { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public int Target { get; set; }
    public ICollection<MetricProgress> ProgressList { get; } = new List<MetricProgress>();
}
