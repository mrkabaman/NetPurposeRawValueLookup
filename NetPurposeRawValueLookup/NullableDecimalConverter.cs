using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;

namespace NetPurposeRawValueLookup;

public class NullableDecimalConverter: DefaultTypeConverter
{
    public override object? ConvertFromString(string? text, IReaderRow row, MemberMapData memberMapData)
    {
        if (string.IsNullOrWhiteSpace(text))
            return null;

        if (decimal.TryParse(text, out var result))
            return result;

        return null;
    }
}