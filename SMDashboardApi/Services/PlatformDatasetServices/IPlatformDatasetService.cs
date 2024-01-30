namespace SMDashboardApi.Services.PlatformDatasetServices;

public interface IPlatformDatasetService
{
    Task<List<PlatformDataset>> GetAllPlatformDatasets();
    Task<PlatformDataset?> GetPlatformDatasetById(int id);
    Task<List<PlatformDataset>?> GetPlatformDatasetsByClientId(int id);
    Task<List<PlatformDataset>?> GetPlatformDatasetsByClientName(string name);
    Task<List<PlatformDatasetRender>?> GetRenderedPlatformDatasetsByClientId(int id);
    Task<List<PlatformDatasetRender>?> GetRenderedPlatformDatasetsByClientName(string name);
    Task<PlatformDataset?> AddPlatformDataset(PlatformDataset platformDataset);
    Task<List<PlatformDataset>?> DeletePlatformDataset(int id);
}
