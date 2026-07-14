namespace Procurement.Analysis.Config;

public sealed class PipelineOptions
{
    public const string SectionName = "Pipeline";

    public string[] DefaultCvPs { get; set; } = [];

    public string? DefaultKeyword { get; set; }

    public int PageSize { get; set; } = 50;

    public string OutputRoot { get; set; } = "output";

    public string CacheRoot { get; set; } = ".cache/downloads";

    public string? AsposeLicensePath { get; set; }
}
