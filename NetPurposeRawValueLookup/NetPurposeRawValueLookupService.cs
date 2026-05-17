namespace NetPurposeRawValueLookup;

public static class NetPurposeRawValueLookupService
{
    /// <summary>
    /// For each EsgIssuer, finds the closest NetPurposeMetric ReportingEnd that is &lt;= ReportingDate,
    /// matching the AladdinIssuerId, satisfying the question/value conditions, and copies
    /// StandardizedValues into the corresponding RawValue fields.
    /// </summary>
    public static void ApplyRawValuesUsingEvic(
        IReadOnlyList<EsgIssuer> vEsgIssuers,
        IReadOnlyList<NetPurposeMetric> netPurposeRawMetrics)
    {
        var netPurposeMetricsByIssuer = netPurposeRawMetrics
            .Where(m => m.AladdinIssuerId != null)
            .GroupBy(m => m.AladdinIssuerId!)
            .ToDictionary(g => g.Key, g => g.ToList());

        foreach (var vesgIssuerData in vEsgIssuers)
        {
            if (vesgIssuerData.AladdinIssuerId == null)
                continue;

            if (!netPurposeMetricsByIssuer.TryGetValue(vesgIssuerData.AladdinIssuerId, out var netPurposeRawIssuerMetricsLookup))
                continue;

            var candidateDates = netPurposeRawIssuerMetricsLookup
                .Select(m => m.ReportingEnd)
                .Where(d => d <= vesgIssuerData.ReportingDate)
                .Distinct()
                .OrderByDescending(d => d)
                .ToList();

            foreach (var reportingEnd in candidateDates)
            {
                var metricsAtDate = netPurposeRawIssuerMetricsLookup
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

                vesgIssuerData.NetPurposeEvicRawValue = evic.StandardizedValue;
                vesgIssuerData.NetPurposeWaterConsumedRawValue = water?.StandardizedValue;
                vesgIssuerData.NetPurposeOperationalWasteGeneratedRawValue = waste?.StandardizedValue;
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
            IReadOnlyList<EsgIssuer> vEsgIssuers,
            IReadOnlyList<NetPurposeMetric> netPurposeRawMetrics)
        {
            // Group only by AladdinIssuerId for fast lookup
            var netPurposeRawMetricsByIssuer = netPurposeRawMetrics
                .Where(m => m.AladdinIssuerId != null)
                .GroupBy(m => m.AladdinIssuerId!)
                .ToDictionary(g => g.Key, g => g.ToList());

            foreach (var vesgIssuerData in vEsgIssuers)
            {
                if (vesgIssuerData.AladdinIssuerId == null)
                    continue;

                if (!netPurposeRawMetricsByIssuer.TryGetValue(vesgIssuerData.AladdinIssuerId, out var issuerMetrics))
                    continue;

                vesgIssuerData.NetPurposeFemaleManagersPercentRawValue          = FindNearest(issuerMetrics, 209,  vesgIssuerData.ReportingDate);
                vesgIssuerData.NetPurposePatientsTreatedMetricRawValue          = FindNearest(issuerMetrics, 132,  vesgIssuerData.ReportingDate);
                vesgIssuerData.NetPurposeNewCustomersMetricRawValue             = FindNearest(issuerMetrics, 236,  vesgIssuerData.ReportingDate);
                vesgIssuerData.NetPurposeFemaleEmployeesPercentRawValue         = FindNearest(issuerMetrics, 210,  vesgIssuerData.ReportingDate);
                vesgIssuerData.NetPurposeCustomersMetricRawValue                = FindNearest(issuerMetrics, 219,  vesgIssuerData.ReportingDate);
                vesgIssuerData.NetPurposeCustomersPreviouslyExcludedMetricRawValue = FindNearest(issuerMetrics, 228, vesgIssuerData.ReportingDate);
                vesgIssuerData.NetPurposeOperationalWasteRecycledPercentMetricRawValue = FindNearest(issuerMetrics, 76, vesgIssuerData.ReportingDate);
                vesgIssuerData.NetPurposeGrossInsurancePremiumsPreviouslyExcludedMetricRawValue = FindNearest(issuerMetrics, 225, vesgIssuerData.ReportingDate);
                
                vesgIssuerData.NetPurposeFemaleboardMembersPercentMetricRawValue = FindNearest(issuerMetrics, 208, vesgIssuerData.ReportingDate);
                
                vesgIssuerData.NetPurposeCeoMedianEmployeeCompensationRatioMetricRawValue = FindNearest(issuerMetrics, 7906, vesgIssuerData.ReportingDate);
                vesgIssuerData.NetPurposeNewCustomersPreviouslyExcludedMetricRawValue = FindNearest(issuerMetrics, 237, vesgIssuerData.ReportingDate);
                vesgIssuerData.NetPurposeInsurancePoliciesPreviouslyExcludedMetricRawValue = FindNearest(issuerMetrics, 220, vesgIssuerData.ReportingDate);
                vesgIssuerData.NetPurposeEnergyConsumedRenewablePercentMetricRawValue = FindNearest(issuerMetrics, 157, vesgIssuerData.ReportingDate);

                vesgIssuerData.NetPurposeRandDInvestmentPercentOfRevenueMetricRawValue = FindNearest(issuerMetrics, 143, vesgIssuerData.ReportingDate);
                vesgIssuerData.NetPurposeRandDInvestmentMetricRawValue = FindNearest(issuerMetrics, 268, vesgIssuerData.ReportingDate);
            }
        }

    private static decimal? FindNearest(
        List<NetPurposeMetric> netPurposeRawIssuerMetrics,
        int questionId,
        DateOnly reportingDate)
    {
        return netPurposeRawIssuerMetrics
            .Where(m => m.QuestionId == questionId && m.ReportingEnd <= reportingDate)
            .OrderByDescending(m => m.ReportingEnd)
            .FirstOrDefault()
            ?.StandardizedValue;
    }
}
