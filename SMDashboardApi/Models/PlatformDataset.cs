using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMDashboardApi.Models;

public class PlatformDataset
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [ForeignKey("ClientId")]
    public int ClientId { get; set; }
    public CustomEnums.Platform Platform { get; set; }
    public ICollection<PlatformMetric> PlatformMetrics { get; } = new List<PlatformMetric>();
}
