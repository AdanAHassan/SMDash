using SMDashboardApi.Models;

public class PaginatedResponse<T>
{
    public PaginatedResponse(IEnumerable<T> data, int i, int length, int? count)
    {
        Data = data.Skip((i - 1) * length).Take(length).ToList();
        Total = count ?? data.Count();
    }

    public int Total { get; set; }
    public IEnumerable<T> Data { get; set; }
}
