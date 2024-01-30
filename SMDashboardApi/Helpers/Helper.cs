namespace SMDashboardApi.Helpers;

public class Helper
{
    private static readonly Random random = new();

    internal static List<MetricProgress> BuildProgressList(int target, DateTime startDate, int platformMetricId)
    {
        int DaysGap = (int)(DateTime.Now - startDate).TotalDays;
        List<MetricProgress> list = new();
        while (list.Count < DaysGap)
        {
            list.Add(new MetricProgress()
            {
                Day = list.Count + 1,
                PlatformMetricId = platformMetricId,
                CurrentValue = (int)Math.Ceiling(target - (decimal)(target*random.NextDouble()))/DaysGap
            });
        }
        return list;
    }

    internal static PlatformMetric BuildMetric<T>(T metric, int platformDatasetId, int target, TimeSpan timeSpan, double multiplier) where T : Enum
    {
        DateTime startDate = DateTime.Now - timeSpan;
        return new PlatformMetric()
        {
            Metric = metric.ToString(),
            StartDate = startDate,
            PlatformDatasetId = platformDatasetId,
            Target = (int)Math.Floor(target * multiplier)
        };
    }

    internal static List<PlatformMetric> MetricGeneratorWrapper<T>(List<PlatformMetric> list, int platformDatasetId, int target, TimeSpan timeSpan) where T : Enum
    {
        double multiplier = 1;

        // Adds all default metrics
        foreach (CustomEnums.GenericMetric i in Enum.GetValues(typeof(CustomEnums.GenericMetric)))
        {
            multiplier = SwitchTargetMultipler(i);
            list.Add(BuildMetric<CustomEnums.GenericMetric>(i, platformDatasetId, target, timeSpan, multiplier));
        }

        // Metric unique to platform
        foreach (T i in Enum.GetValues(typeof(T)))
        {
            multiplier = SwitchTargetMultipler(i);
            list.Add(BuildMetric<T>(i, platformDatasetId, target, timeSpan, multiplier));
        }
        return list;
    }

    internal static List<PlatformMetric> BuildPlatformMetric(CustomEnums.Platform platform, int platformDatasetId, int target, TimeSpan timeSpan)
    {
        List<PlatformMetric> platformMetrics = new();

        switch(platform)
        {
            case CustomEnums.Platform.Instagram:
                MetricGeneratorWrapper<CustomEnums.InstagramMetric>(platformMetrics, platformDatasetId, target, timeSpan);
                break;
            case CustomEnums.Platform.Youtube:
                MetricGeneratorWrapper<CustomEnums.YoutubeMetric>(platformMetrics, platformDatasetId, target, timeSpan);
                break;
            case CustomEnums.Platform.Twitter:
                MetricGeneratorWrapper<CustomEnums.TwitterMetric>(platformMetrics, platformDatasetId, target, timeSpan);
                break;
            case CustomEnums.Platform.Facebook:
                MetricGeneratorWrapper<CustomEnums.FacebookMetric>(platformMetrics, platformDatasetId, target, timeSpan);
                break;
            default:
                Console.WriteLine($"Illegal Enum: {platform}");
                break;
        }
        return platformMetrics;
    }

    internal static double SwitchTargetMultipler<T>(T enumerator) where T : Enum
    {
        switch (enumerator)
        {
            // Generic
            case CustomEnums.GenericMetric.Likes:
                return 5;
            case CustomEnums.GenericMetric.Replies:
                return 2;
            case CustomEnums.GenericMetric.Followers:
                return 10;
            case CustomEnums.GenericMetric.Impressions:
                return 20;
            // Twitter
            case CustomEnums.TwitterMetric.Quotes:
                return 1.5;
            case CustomEnums.TwitterMetric.Retweets:
                return 2.5;
            default:
                break;
        }
        return 1;
    }

    internal static PlatformDataset BuildPlatformDataset(int clientId, CustomEnums.Platform platform)
    {
        return new PlatformDataset()
        {
            ClientId = clientId,
            Platform = platform
            // Metrics = BuildPlatformMetric(platform, target, timeSpan)
        };
    }

    public static string IsStringUnique(string item, List<string> items, int count = 1, int itemLength = 0)
    {
        if (!items.Contains(item))
        {
            items.Add(item);
            return item;
        }
        else
        {
            if(itemLength == 0) itemLength = item.Length;
            if(itemLength > 0) item = item.Remove(itemLength);
            return IsStringUnique($"{item}{count}", items, count + 1, itemLength);
        }
    }


    public static decimal RandomNumber(int digits)
    {
        return random.Next(Math.Max(1, (int)Math.Floor(Math.Pow(10, digits-2))), (int)Math.Floor(Math.Pow(10, digits)));
    }

    internal static bool CheckString(string str)
    {
        if(str == "string" || str.Length == 0) return false;
        return true;
    }

    internal static void ChangeGenericString<T>(string inputString, string propName, T obj)
    {
        if(CheckString(inputString))
        {
            foreach(var prop in typeof(T).GetProperties())
            {
              if(prop.Name.ToLower() == propName.ToLower()) prop.SetValue(obj, inputString);
            }
        }
    }

}

// platforms is really a secondary id pointing to a table which has all the platformMetrics
