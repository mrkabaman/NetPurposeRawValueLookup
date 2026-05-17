using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
namespace NetPurposeRawValueLookup;

public static class NetPurposeMetricCsvReader
{
    public static List<NetPurposeMetric> ReadFromFile(string filePath)
    {
        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = true,
            MissingFieldFound = null,
            HeaderValidated = null,
        };

        using var reader = new StreamReader(filePath);
        using var csv = new CsvReader(reader, config);

        csv.Context.RegisterClassMap<NetPurposeMetricCsvMap>();

        return csv.GetRecords<NetPurposeMetric>().ToList();
    }
}