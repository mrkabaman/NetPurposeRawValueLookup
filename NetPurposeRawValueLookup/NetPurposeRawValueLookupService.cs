namespace NetPurposeRawValueLookup;

public static class NetPurposeRawValueLookupService
{
    /// <summary>
    /// For each EsgIssuer, finds the closest NetPurposeMetric ReportingEnd that is <= ReportingDate,
    /// matching the AladdinIssuerId, satisfying the question/value conditions, and copies
    /// StandardizedValues into the corresponding RawValue fields.
    /// </summary>
    public static void ApplyRawValues(
        IReadOnlyList<EsgIssuer> issuers,
        IReadOnlyList<NetPurposeMetric> metrics)
    {
        // Group metrics by AladdinIssuerId for faster lookup
        var metricsByIssuer = metrics
            .Where(m => m.AladdinIssuerId != null)
            .GroupBy(m => m.AladdinIssuerId!)
            .ToDictionary(g => g.Key, g => g.ToList());

        foreach (var issuer in issuers)
        {
            if (issuer.AladdinIssuerId == null)
                continue;

            if (!metricsByIssuer.TryGetValue(issuer.AladdinIssuerId, out var issuerMetrics))
                continue;

            // Collect all distinct ReportingEnd dates that are <= ReportingDate, sorted descending
            var candidateDates = issuerMetrics
                .Select(m => m.ReportingEnd)
                .Where(d => d <= issuer.ReportingDate)
                .Distinct()
                .OrderByDescending(d => d)
                .ToList();

            // Walk from the nearest date backwards until we find one satisfying all conditions
            foreach (var reportingEnd in candidateDates)
            {
                var metricsAtDate = issuerMetrics
                    .Where(m => m.ReportingEnd == reportingEnd)
                    .ToList();

                // Condition: QuestionId 72378 must exist with a non-null StandardizedValue
                var evic = metricsAtDate
                    .FirstOrDefault(m => m.QuestionId == 72378 && m.StandardizedValue.HasValue);

                if (evic == null)
                    continue;

                // Condition: QuestionId 103 OR QuestionId 55 must exist with a non-null StandardizedValue
                var water = metricsAtDate
                    .FirstOrDefault(m => m.QuestionId == 103 && m.StandardizedValue.HasValue);

                var waste = metricsAtDate
                    .FirstOrDefault(m => m.QuestionId == 55 && m.StandardizedValue.HasValue);

                if (water == null && waste == null)
                    continue;

                // All conditions met — copy values and stop searching
                issuer.NetPurposeEvicRawValue = evic.StandardizedValue;
                issuer.NetPurposeWaterConsumedRawValue = water?.StandardizedValue;
                issuer.NetPurposeOperationalWasteGeneratedRawValue = waste?.StandardizedValue;
                break;
            }
        }
    }
}