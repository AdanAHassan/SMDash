using SMDashboardApi.Helpers;

namespace SMDashboardApi.Data;

public class DataSeed
{
    private static readonly Random random = new();
    private readonly DataContext _context;

    private readonly List<string> UniqueClientNameList = new();

    public DataSeed(DataContext context)
    {
        _context = context;
    }

    public void SeedData(int nClients, double percentageOfPlatforms, int days)
    {
        List<int> clientIds = _context.Clients.AsQueryable().Select(c => c.Id).ToList();
        List<int> platformDatasetIds = _context.PlatformDatasets.AsQueryable().Select(p => p.Id).ToList();
        if(clientIds.Count == 0)
        {
            SeedClientTable(nClients);
            clientIds = _context.Clients.AsQueryable().Select(c => c.Id).ToList();
        }
        if(_context.PlatformDatasets.AsQueryable().Select(x => x.Id).ToList().Count == 0)
        {
            SeedPlatformDatasetTable(clientIds, percentageOfPlatforms);
        }
        if(_context.PlatformMetrics.AsQueryable().Select(x => x.Id).ToList().Count == 0)
        {
            platformDatasetIds = _context.PlatformDatasets.AsQueryable().Select(p => p.Id).ToList();
            SeedPlatformMetricTable(platformDatasetIds, days);
        }
        if(_context.MetricProgressList.AsQueryable().Select(x => x.Id).ToList().Count == 0)
        {
            SeedMetricProgressList();
        }
    }

    private void SeedClientTable(int n)
    {
        for(int i = 0; i < n; i++)
        {
            _context.Clients.Add(BuildClient());
            if(i % 1000 == 0) _context.SaveChanges();
        }
        _context.SaveChanges();
    }

    private void SeedPlatformDatasetTable(List<int> clientIds, double percentageOfPlatforms)
    {
        foreach(int clientId in clientIds)
        {
            foreach (CustomEnums.Platform platform in Enum.GetValues(typeof(CustomEnums.Platform)))
            {
                if(random.NextDouble() <= percentageOfPlatforms)
                {
                    _context.PlatformDatasets.Add(Helper.BuildPlatformDataset(clientId, platform));
                }
            }
            if(clientIds.IndexOf(clientId) % 100 == 0) _context.SaveChanges();
        }
        _context.SaveChanges();
    }

    private void SeedPlatformMetricTable(List<int> platformDatasetIds, int days)
    {
        foreach(int platformDatasetId in platformDatasetIds)
        {
            List<CustomEnums.Platform> listOfPlatformsForId = _context.PlatformDatasets.Where(x => x.Id == platformDatasetId).Select(y => y.Platform).ToList();
            foreach (CustomEnums.Platform platform in listOfPlatformsForId)
            {
                List<PlatformMetric> intMetrics = Helper.BuildPlatformMetric(
                    platform,
                    platformDatasetId,
                    (int)Helper.RandomNumber(4),
                    new TimeSpan(
                      (int)Math.Round(random.NextDouble()*days*24),
                      (int)Math.Round(random.NextDouble()*60),
                      (int)Math.Round(random.NextDouble()*60)
                      ));

                foreach(PlatformMetric cMetric in intMetrics)
                {
                    _context.PlatformMetrics.Add(cMetric);
                }
            }
            _context.SaveChanges();
        }
    }

    private void SeedMetricProgressList()
    {
        List<PlatformMetric> metricList = _context.PlatformMetrics.ToList();
        foreach(PlatformMetric cMetric in metricList)
        {
            List<MetricProgress> metricProgresses = Helper.BuildProgressList(cMetric.Target, cMetric.StartDate, cMetric.Id);
            foreach (MetricProgress xProgress in metricProgresses)
            {
                _context.MetricProgressList.Add(xProgress);
            }
            _context.SaveChanges();
        }

    }

    private Client BuildClient()
    {
        string name = Helper.IsStringUnique(MakeClientName(), UniqueClientNameList);
        return new Client()
        {
            Name = name
        };
    }

    // Random names 
    private static readonly List<string> namePrefix = new()
    {
        "Aeron", "Aero", "Arianne", "Arya", "Arys", "Asha", "Barristan", "Bran", "Brienne", "Catelyn", "Cersei", "Daenerys", "Davos", "Jon", "Jaime", "Melisandre", "Quentyn", "Samwell", "Sansa", "Theon", "Tyrion", "Victarion"
    };

    private static readonly List<string> nameSuffix = new()
    {
        "Greyjoy", "Hotah", "Martell", "Stark", "Oakheart", "Selmy", "Tarth", "Tully", "Lannister", "Targaryen", "Seaworth", "Connington", "Snow", "Tarly"
    };

    internal static T GetRandom<T>(List<T> items)
    {
        return items[random.Next(items.Count)];
    }

    internal static string MakeClientName()
    {
        return GetRandom(namePrefix) + GetRandom(nameSuffix);
    }
}
