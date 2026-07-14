using Microsoft.Extensions.Configuration;
using Procurement.Analysis.Cli;
using Procurement.Analysis.Config;

var configuration = new ConfigurationBuilder()
    .SetBasePath(AppContext.BaseDirectory)
    .AddJsonFile("appsettings.json", optional: false)
    .AddEnvironmentVariables(prefix: "ProcurementAnalysis__")
    .AddUserSecrets(typeof(Program).Assembly, optional: true)
    .Build();

var apiOptions = configuration.GetSection(ApiOptions.SectionName).Get<ApiOptions>() ?? new ApiOptions();
var azureAdOptions = configuration.GetSection(AzureAdOptions.SectionName).Get<AzureAdOptions>() ?? new AzureAdOptions();
var pipelineOptions = configuration.GetSection(PipelineOptions.SectionName).Get<PipelineOptions>() ?? new PipelineOptions();

var cliArgs = new CommandLineArgs(args);

Console.WriteLine("Procurement.Analysis sync tool");
Console.WriteLine($"  API base URL: {apiOptions.BaseUrl}");
Console.WriteLine($"  Azure AD configured: {azureAdOptions.IsConfigured}");
Console.WriteLine($"  Output root: {pipelineOptions.OutputRoot}");

// TODO: wire up the Refit client, auth handler, discovery/download/convert services, and run the sync pipeline here.
return 0;
