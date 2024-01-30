using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMDashboardApi.Models;

public class MetricProgress
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int Day { get; set; }
    [ForeignKey("PlatformMetricId")]
    public int PlatformMetricId { get; set; }
    public int CurrentValue { get; set; }
}

