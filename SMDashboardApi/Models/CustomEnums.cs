namespace SMDashboardApi.Models;

public class CustomEnums
{
    public enum Platform
    {
        Twitter,
        Youtube,
        Facebook,
        Instagram
    }

    // Generic metric to keep code dry
    public enum GenericMetric
    {
        Followers,
        Impressions,
        Likes,
        Replies
    }

    public enum TwitterMetric
    {
        Retweets,
        Quotes
    }

    public enum InstagramMetric
    {
    }

    public enum YoutubeMetric
    {
    }

    public enum FacebookMetric
    {
    }
}
