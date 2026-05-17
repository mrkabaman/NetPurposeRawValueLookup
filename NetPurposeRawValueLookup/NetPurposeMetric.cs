namespace NetPurposeRawValueLookup;

public class NetPurposeMetric
{
    // --- Identifiers ---
    public long Id { get; set; }
    public DateOnly ReportingEnd { get; set; }
    public int Year { get; set; }

    // --- Question / Metric Definition ---
    public int QuestionId { get; set; }
    public string? QuestionName { get; set; }
    public string? CanonicalId { get; set; }
    public string? Theme { get; set; }
    public string? StandardizedUnit { get; set; }
    public string? DataType { get; set; }

    // --- Value ---
    public decimal? StandardizedValue { get; set; }

    // --- Issuer Cross-references ---
    public int? NetPurposeIssuerOrEntityId { get; set; }
    public string? MsciIssuerId { get; set; }
    public string? AladdinIssuerId { get; set; }
    public string? AladdinIssuerName { get; set; }  
}