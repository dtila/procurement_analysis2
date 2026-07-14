namespace Procurement.Analysis.Config;

public sealed class ApiOptions
{
    public const string SectionName = "Api";

    public string BaseUrl { get; set; } = "https://TODO-fill-in-real-host";

    public int TimeoutSeconds { get; set; } = 100;
}
