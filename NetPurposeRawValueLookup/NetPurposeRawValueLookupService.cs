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
            // Group only by AladdinIssuerId for fast lookup
            var metricsByIssuerAndQuestion = metrics
                .Where(m => m.AladdinIssuerId != null)
                .GroupBy(m => m.AladdinIssuerId!)
                .ToDictionary(g => g.Key, g => g.ToList());

            foreach (var issuer in issuers)
            {
                if (issuer.AladdinIssuerId == null)
                    continue;

                if (!metricsByIssuerAndQuestion.TryGetValue(issuer.AladdinIssuerId, out var issuerMetrics))
                    continue;

                issuer.NetPurposeFemaleManagersPercentValue          = FindNearest(issuerMetrics, 209,  issuer.ReportingDate);
                issuer.NetPurposePatientsTreatedMetricValue          = FindNearest(issuerMetrics, 132,  issuer.ReportingDate);
                issuer.NetPurposeNewCustomersMetricValue             = FindNearest(issuerMetrics, 236,  issuer.ReportingDate);
                issuer.NetPurposeFemaleEmployeesPercentValue         = FindNearest(issuerMetrics, 210,  issuer.ReportingDate);
                issuer.NetPurposeCustomersMetricValue                = FindNearest(issuerMetrics, 219,  issuer.ReportingDate);
                issuer.NetPurposeCustomersPreviouslyExcludedMetricValue = FindNearest(issuerMetrics, 228, issuer.ReportingDate);
                issuer.NetPurposeOperationalWasteRecycledPercentMetricValue = FindNearest(issuerMetrics, 76, issuer.ReportingDate);
                issuer.NetPurposeGrossInsurancePremiumsPreviouslyExcludedMetricValue = FindNearest(issuerMetrics, 225, issuer.ReportingDate);
                issuer.NetPurposeFemaleboardMembersPercentMetricValue = FindNearest(issuerMetrics, 208, issuer.ReportingDate);
                issuer.NetPurposeCeoMedianEmployeeCompensationRatioMetricValue = FindNearest(issuerMetrics, 7906, issuer.ReportingDate);
                issuer.NetPurposeNewCustomersPreviouslyExcludedMetricValue = FindNearest(issuerMetrics, 237, issuer.ReportingDate);
                issuer.NetPurposeInsurancePoliciesPreviouslyExcludedMetricValue = FindNearest(issuerMetrics, 220, issuer.ReportingDate);
                issuer.NetPurposeEnergyConsumedRenewablePercentMetricValue = FindNearest(issuerMetrics, 157, issuer.ReportingDate);

                issuer.NetPurposeRandDInvestmentPercentOfRevenueMetricValue = FindNearest(issuerMetrics, 143, issuer.ReportingDate);
                issuer.NetPurposeRandDInvestmentMetricRawValue = FindNearest(issuerMetrics, 268, issuer.ReportingDate);
            }
        }

    private static decimal? FindNearest(
        List<NetPurposeMetric> issuerMetrics,
        int questionId,
        DateOnly reportingDate)
    {
        return issuerMetrics
            .Where(m => m.QuestionId == questionId && m.ReportingEnd <= reportingDate && m.StandardizedValue.HasValue)
            .OrderByDescending(m => m.ReportingEnd)
            .FirstOrDefault()
            ?.StandardizedValue;
    }
}