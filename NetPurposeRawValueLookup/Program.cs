
using Microsoft.Extensions.Configuration;
using Serilog;
namespace NetPurposeRawValueLookup;

internal class Program
{
    private static void Main(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables()
            .Build();

        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(configuration)
            .CreateLogger();

        try
        {
            Log.Information("Application starting");

            var csvFilePath = configuration["NetPurpose:CsvFilePath"]
                              ?? "NetPurposeSnowflakeReportingDateSorted.csv";

            var rawMetricsFilePath = configuration["NetPurpose:RawMetricsCsvFilePath"]
                                     ?? "NetPurposeRawMetrics.csv";

            var outputFilePath = configuration["NetPurpose:OutputCsvFilePath"]
                                 ?? "EsgIssuerWithRawValues.csv";

            // 1. Read EsgIssuers
            var issuers = EsgIssuerCsvReader.ReadFromFile(csvFilePath);
            Log.Information("Loaded {IssuerCount} issuers from CSV", issuers.Count);

            // 2. Read NetPurposeMetrics
            var metrics = NetPurposeMetricCsvReader.ReadFromFile(rawMetricsFilePath);
            Log.Information("Loaded {MetricCount} raw metrics from CSV", metrics.Count);

            // 3. Apply raw value lookup
            NetPurposeRawValueLookupService.ApplyRawValues(issuers, metrics);
            Log.Information("Raw value lookup applied");

            // 4. Write output CSV with all properties including RawValue fields
            EsgIssuerCsvWriter.WriteToFile(outputFilePath, issuers);
            Log.Information("Output written to {OutputFilePath}", outputFilePath);

            Log.Information("Application finished successfully");
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "Application terminated unexpectedly");
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }
}