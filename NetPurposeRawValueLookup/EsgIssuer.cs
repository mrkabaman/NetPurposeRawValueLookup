namespace NetPurposeRawValueLookup;

public class EsgIssuer
{
    // --- Identifiers ---
    public DateOnly ReportingDate { get; set; }
    public string? EsgIssuerId { get; set; }
    public string? AladdinIssuerId { get; set; }
    public string? MsciIssuerId { get; set; }
    public string? IssuerName { get; set; }
    public string? Lei { get; set; }
    public string? Isin { get; set; }
        
    // --- Net Purpose Metrics ---
    public decimal? NetPurposeEvicCalculatedValue { get; set; }
    public decimal? NetPurposeEvicValue { get; set; }
    public decimal? NetPurposeFemaleEmployeesPercentValue { get; set; }
    public decimal? NetPurposeFemaleManagersPercentValue { get; set; }
    public string? NetPurposeIssuerId { get; set; }
    public decimal? NetPurposeOperationalWasteGeneratedMetricCalculatedValue { get; set; }
    public decimal? NetPurposeOperationalWasteGeneratedValue { get; set; }
    public decimal? NetPurposeWaterConsumedMetricCalculatedValue { get; set; }
    public decimal? NetPurposeWaterConsumedValue { get; set; }

    // --- Additional Net Purpose Metrics ---
    public decimal? NetPurposeOperationalWasteRecycledPercentMetricValue { get; set; }
    public decimal? NetPurposeCeoMedianEmployeeCompensationRatioMetricValue { get; set; }
    public decimal? NetPurposeFemaleboardMembersPercentMetricValue { get; set; }
    public decimal? NetPurposeEnergyConsumedRenewablePercentMetricValue { get; set; }
    public decimal? NetPurposeRandDInvestmentPercentOfRevenueMetricValue { get; set; }
    public decimal? NetPurposeCustomersMetricValue { get; set; }
    public decimal? NetPurposeCustomersPreviouslyExcludedMetricValue { get; set; }
    public decimal? NetPurposeNewCustomersMetricValue { get; set; }
    public decimal? NetPurposeNewCustomersPreviouslyExcludedMetricValue { get; set; }
    public decimal? NetPurposeInsurancePoliciesPreviouslyExcludedMetricValue { get; set; }
    public decimal? NetPurposePatientsTreatedMetricValue { get; set; }
    public decimal? NetPurposeRandDInvestmentMetricValue { get; set; }
    public decimal? NetPurposeGrossInsurancePremiumsPreviouslyExcludedMetricValue { get; set; }
    
    
   
     // --- Net Purpose Metrics Raw Values ---

    public decimal? NetPurposeEvicRawValue { get; set; }
    public decimal? NetPurposeFemaleEmployeesPercentRawValue { get; set; }
    public decimal? NetPurposeFemaleManagersPercentRawValue { get; set; }
    public decimal? NetPurposeOperationalWasteGeneratedRawValue { get; set; }
    public decimal? NetPurposeWaterConsumedRawValue { get; set; }

    // --- Additional Net Purpose Metrics RawValue---
    public decimal? NetPurposeOperationalWasteRecycledPercentMetricRawValue { get; set; }
    public decimal? NetPurposeCeoMedianEmployeeCompensationRatioMetricRawValue { get; set; }
    public decimal? NetPurposeFemaleboardMembersPercentMetricRawValue { get; set; }
    public decimal? NetPurposeEnergyConsumedRenewablePercentMetricRawValue { get; set; }
    public decimal? NetPurposeRandDInvestmentPercentOfRevenueMetricRawValue { get; set; }
    public decimal? NetPurposeCustomersMetricRawValue { get; set; }
    public decimal? NetPurposeCustomersPreviouslyExcludedMetricRawValue { get; set; }
    public decimal? NetPurposeNewCustomersMetricRawValue { get; set; }
    public decimal? NetPurposeNewCustomersPreviouslyExcludedMetricRawValue { get; set; }
    public decimal? NetPurposeInsurancePoliciesPreviouslyExcludedMetricRawValue { get; set; }
    public decimal? NetPurposePatientsTreatedMetricRawValue { get; set; }
    public decimal? NetPurposeRandDInvestmentMetricRawValue { get; set; }
    public decimal? NetPurposeGrossInsurancePremiumsPreviouslyExcludedMetricRawValue { get; set; }
     
  
    
    
}