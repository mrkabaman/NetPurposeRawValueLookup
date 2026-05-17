using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;

namespace NetPurposeRawValueLookup;

public static class EsgIssuerCsvReader
{
    public static List<EsgIssuer> ReadFromFile(string filePath)
    {
        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = true,
            MissingFieldFound = null,       // ignore columns in CSV not in the map
            HeaderValidated = null,         // ignore mapped properties absent from CSV (e.g. IssuerName)
        };

        using var reader = new StreamReader(filePath);
        using var csv = new CsvReader(reader, config);

        csv.Context.RegisterClassMap<EsgIssuerCsvMap>();

        return csv.GetRecords<EsgIssuer>().ToList();
    }
}