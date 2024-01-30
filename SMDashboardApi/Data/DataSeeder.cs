namespace SMDashboardApi.Data;

public class DataSeeder
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var apiContext = new DataContext(
          serviceProvider.GetRequiredService<DbContextOptions<DataContext>>()))
        {
            DataSeed seed = new(apiContext);
            seed.SeedData(10, 0.7, 50);
        }
    }
}
