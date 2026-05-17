namespace NetPurposeRawValueLookup;

public static class NetPurposeRawValueLookupService
{
    /// <summary>
    /// For each EsgIssuer, finds the closest NetPurposeMetric ReportingEnd that is &lt;= ReportingDate,
    /// matching the AladdinIssuerId, satisfying the question/value conditions, and copies
    /// StandardizedValues into the corresponding RawValue fields.
    /// </summary>
    public static void ApplyRawValuesUsingEvic(
        IReadOnlyList<EsgIssuer> issuers,
        IReadOnlyList<NetPurposeMetric> metrics)
    {
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

            var candidateDates = issuerMetrics
                .Select(m => m.ReportingEnd)
                .Where(d => d <= issuer.ReportingDate)
                .Distinct()
                .OrderByDescending(d => d)
                .ToList();

            foreach (var reportingEnd in candidateDates)
            {
                var metricsAtDate = issuerMetrics
                    .Where(m => m.ReportingEnd == reportingEnd)
                    .ToList();

                var evic = metricsAtDate
                    .FirstOrDefault(m => m.QuestionId == 72378 && m.StandardizedValue.HasValue);

                if (evic == null)
                    continue;

                var water = metricsAtDate
                    .FirstOrDefault(m => m.QuestionId == 103 && m.StandardizedValue.HasValue);

                var waste = metricsAtDate
                    .FirstOrDefault(m => m.QuestionId == 55 && m.StandardizedValue.HasValue);

                if (water == null && waste == null)
                    continue;

                issuer.NetPurposeEvicRawValue = evic.StandardizedValue;
                issuer.NetPurposeWaterConsumedRawValue = water?.StandardizedValue;
                issuer.NetPurposeOperationalWasteGeneratedRawValue = waste?.StandardizedValue;
                break;
            }
        }
    }

    /// <summary>
    /// For each EsgIssuer, independently looks up the nearest ReportingEnd &lt;= ReportingDate
    /// for each question and copies the StandardizedValue into the corresponding metric field.
    /// Each question is resolved independently (no cross-question conditions).
    /// </summary>
    public static void ApplyMetricValues(
        IReadOnlyList<EsgIssuer> issuers,
        IReadOnlyList<NetPurposeMetric> metrics)
    {
        // Group by AladdinIssuerId then by QuestionId for fast lookup
        var metricsByIssuerAndQuestion = metrics
            .Where(m => m.AladdinIssuerId != null)
            .GroupBy(m => m.AladdinIssuerId!)
            .ToDictionary(
                g => g.Key,
                g => g.GroupBy(m => m.QuestionId)
                       .ToDictionary(q => q.Key, q => q.ToList()));

        foreach (var issuer in issuers)
        {
            if (issuer.AladdinIssuerId == null)
                continue;

            if (!metricsByIssuerAndQuestion.TryGetValue(issuer.AladdinIssuerId, out var byQuestion))
                continue;

            issuer.NetPurposeFemaleManagersPercentValue          = FindNearest(byQuestion, 209,  issuer.ReportingDate);
            issuer.NetPurposePatientsTreatedMetricValue          = FindNearest(byQuestion, 132,  issuer.ReportingDate);
            issuer.NetPurposeNewCustomersMetricValue             = FindNearest(byQuestion, 236,  issuer.ReportingDate);
            issuer.NetPurposeFemaleEmployeesPercentValue         = FindNearest(byQuestion, 210,  issuer.ReportingDate);
            issuer.NetPurposeCustomersMetricValue                = FindNearest(byQuestion, 219,  issuer.ReportingDate);
            issuer.NetPurposeCustomersPreviouslyExcludedMetricValue = FindNearest(byQuestion, 228, issuer.ReportingDate);
            issuer.NetPurposeOperationalWasteRecycledPercentMetricValue = FindNearest(byQuestion, 76, issuer.ReportingDate);
            issuer.NetPurposeGrossInsurancePremiumsPreviouslyExcludedMetricValue = FindNearest(byQuestion, 225, issuer.ReportingDate);
            issuer.NetPurposeFemaleboardMembersPercentMetricValue = FindNearest(byQuestion, 208, issuer.ReportingDate);
            issuer.NetPurposeCeoMedianEmployeeCompensationRatioMetricValue = FindNearest(byQuestion, 7906, issuer.ReportingDate);
            issuer.NetPurposeNewCustomersPreviouslyExcludedMetricValue = FindNearest(byQuestion, 237, issuer.ReportingDate);
            issuer.NetPurposeInsurancePoliciesPreviouslyExcludedMetricValue = FindNearest(byQuestion, 220, issuer.ReportingDate);
            issuer.NetPurposeEnergyConsumedRenewablePercentMetricValue = FindNearest(byQuestion, 157, issuer.ReportingDate);
            
            issuer.NetPurposeRandDInvestmentPercentOfRevenueMetricValue = FindNearest(byQuestion, 143, issuer.ReportingDate);
            issuer.NetPurposeRandDInvestmentMetricRawValue = FindNearest(byQuestion, 268, issuer.ReportingDate);
        }
    }

    private static decimal? FindNearest(
        Dictionary<int, List<NetPurposeMetric>> byQuestion,
        int questionId,
        DateOnly reportingDate)
    {
        if (!byQuestion.TryGetValue(questionId, out var candidates))
            return null;

        return candidates
            .Where(m => m.ReportingEnd <= reportingDate && m.StandardizedValue.HasValue)
            .OrderByDescending(m => m.ReportingEnd)
            .FirstOrDefault()
            ?.StandardizedValue;
    }
}