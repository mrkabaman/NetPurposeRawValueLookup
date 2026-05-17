using CsvHelper.Configuration;

namespace NetPurposeRawValueLookup;

public class NetPurposeMetricCsvMap: ClassMap<NetPurposeMetric>
{
    public NetPurposeMetricCsvMap()
    {
        Map(m => m.Id).Name("Id");
        Map(m => m.ReportingEnd).Name("ReportingEnd").TypeConverterOption.Format("yyyy-MM-dd");
        Map(m => m.Year).Name("Year");
        Map(m => m.QuestionId).Name("QuestionId");
        Map(m => m.QuestionName).Name("QuestionName");
        Map(m => m.CanonicalId).Name("CanonicalId");
        Map(m => m.Theme).Name("Theme").TypeConverter<NullLiteralStringConverter>();
        Map(m => m.StandardizedUnit).Name("StandardizedUnit");
        Map(m => m.StandardizedValue).Name("StandardizedValue").TypeConverter<NullableDecimalConverter>();
        Map(m => m.DataType).Name("DataType");
        Map(m => m.NetPurposeIssuerOrEntityId).Name("NetPurposeIssuerOrEntityId");
        Map(m => m.MsciIssuerId).Name("MsciIssuerId");
        Map(m => m.AladdinIssuerId).Name("AladdinIssuerID");
        Map(m => m.AladdinIssuerName).Name("AladdinIssuerName");
    }
}