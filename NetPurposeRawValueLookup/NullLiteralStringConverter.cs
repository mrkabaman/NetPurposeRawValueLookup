using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
namespace NetPurposeRawValueLookup;

public class NullLiteralStringConverter: DefaultTypeConverter
{
    public override object? ConvertFromString(string? text, IReaderRow row, MemberMapData memberMapData)
    {
        if (string.IsNullOrWhiteSpace(text) || text.Equals("NULL", StringComparison.OrdinalIgnoreCase))
            return null;

        return text;
    }
}