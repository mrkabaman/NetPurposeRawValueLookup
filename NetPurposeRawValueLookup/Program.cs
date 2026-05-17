
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

            var snowflakeCsvFilePath = configuration["NetPurpose:SnowflakeCsvFilePath"]
                              ?? "NetPurposeSnowflakeReportingDateSorted.csv";

            var rawMetricsFilePath = configuration["NetPurpose:RawMetricsCsvFilePath"]
                                     ?? "NetPurposeRawMetrics.csv";

            var outputFilePath = configuration["NetPurpose:OutputCsvFilePath"]
                                 ?? "EsgIssuerWithRawValues.csv";

            // 1. Read EsgIssuers
            var snowflakeIssuers = EsgIssuerCsvReader.ReadFromFile(snowflakeCsvFilePath);
            Log.Information("Loaded {IssuerCount} issuers from Snowflake CSV", snowflakeIssuers.Count);

            // 2. Read NetPurposeMetrics
            var rawNetPurposeMetrics = NetPurposeMetricCsvReader.ReadFromFile(rawMetricsFilePath);
            Log.Information("Loaded {MetricCount} raw NetPurpose metrics from CSV", rawNetPurposeMetrics.Count);

            // 3. Apply raw value lookup
            NetPurposeRawValueLookupService.ApplyRawValues(snowflakeIssuers, rawNetPurposeMetrics);
            Log.Information("Raw value lookup applied");

            // 4. Write output CSV with all properties including RawValue fields
            EsgIssuerCsvWriter.WriteToFile(outputFilePath, snowflakeIssuers);
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