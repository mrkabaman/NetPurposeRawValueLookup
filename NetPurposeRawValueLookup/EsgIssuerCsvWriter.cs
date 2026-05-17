using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;

namespace NetPurposeRawValueLookup;

public static class EsgIssuerCsvWriter
{
    public static void WriteToFile(string filePath, IEnumerable<EsgIssuer> issuers)
    {
        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = true,
        };

        using var writer = new StreamWriter(filePath);
        using var csv = new CsvWriter(writer, config);

        csv.Context.RegisterClassMap<EsgIssuerOutputCsvMap>();
        csv.WriteRecords(issuers);
    }
}