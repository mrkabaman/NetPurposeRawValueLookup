// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");


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

                var lookupTable = configuration["NetPurpose:RawValueLookupTable"];
                var batchSize = configuration.GetValue<int>("NetPurpose:BatchSize");

                Log.Information("Lookup table: {LookupTable}", lookupTable);
                Log.Information("Batch size: {BatchSize}", batchSize);

                foreach (var arg in args)
                    Log.Debug("Argument: {Arg}", arg);

                var csvFilePath = configuration["NetPurpose:CsvFilePath"]
                                  ?? "NetPurposeSnowflakeReportingDateSorted.csv";

                var issuers = EsgIssuerCsvReader.ReadFromFile(csvFilePath);
                Log.Information("Loaded {IssuerCount} issuers from CSV", issuers.Count);

                var rawNetPurpose = NetPurposeMetricCsvReader.ReadFromFile("NetPurposeRawMetrics.csv");
                Log.Information("Loaded {MetricCount} raw metrics from CSV", rawNetPurpose.Count);

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