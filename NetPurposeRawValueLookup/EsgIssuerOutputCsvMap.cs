using CsvHelper.Configuration;

namespace NetPurposeRawValueLookup;

public class EsgIssuerOutputCsvMap : ClassMap<EsgIssuer>
{
    public EsgIssuerOutputCsvMap()
    {
        Map(m => m.ReportingDate).Name("REPORTING_DATE").TypeConverterOption.Format("yyyy-MM-dd");
        Map(m => m.EsgIssuerId).Name("ESG_ISSUER_ID");
        Map(m => m.AladdinIssuerId).Name("ALADDIN_ISSUER_ID");
        Map(m => m.MsciIssuerId).Name("MSCI_ISSUERID");
        Map(m => m.IssuerName).Name("ISSUER_NAME");
        Map(m => m.Lei).Name("LEI");
        Map(m => m.Isin).Name("ISIN");

        // --- Net Purpose Metrics ---
        Map(m => m.NetPurposeEvicCalculatedValue).Name("NETPURPOSEEVICCALCULATEDVALUE");
        Map(m => m.NetPurposeEvicValue).Name("NETPURPOSEEVICVALUE");
        Map(m => m.NetPurposeFemaleEmployeesPercentValue).Name("NETPURPOSEFEMALEEMPLOYEESPERCENTVALUE");
        Map(m => m.NetPurposeFemaleManagersPercentValue).Name("NETPURPOSEFEMALEMANAGERSPERCENTVALUE");
        Map(m => m.NetPurposeIssuerId).Name("NETPURPOSEISSUERID");
        Map(m => m.NetPurposeOperationalWasteGeneratedMetricCalculatedValue).Name("NETPURPOSEOPERATIONALWASTEGENERATEDMETRICCALCULATEDVALUE");
        Map(m => m.NetPurposeOperationalWasteGeneratedValue).Name("NETPURPOSEOPERATIONALWASTEGENERATEDVALUE");
        Map(m => m.NetPurposeWaterConsumedMetricCalculatedValue).Name("NETPURPOSEWATERCONSUMEDMETRICCALCULATEDVALUE");
        Map(m => m.NetPurposeWaterConsumedValue).Name("NETPURPOSEWATERCONSUMEDVALUE");

        // --- Additional Net Purpose Metrics ---
        Map(m => m.NetPurposeOperationalWasteRecycledPercentMetricValue).Name("NETPURPOSEOPERATIONALWASTERECYCLEDPERCENTMETRICVALUE");
        Map(m => m.NetPurposeCeoMedianEmployeeCompensationRatioMetricValue).Name("NETPURPOSECEOMEDIANEMPLOYEECOMPENSATIONRATIOMETRICVALUE");
        Map(m => m.NetPurposeFemaleboardMembersPercentMetricValue).Name("NETPURPOSEFEMALEBOARDMEMBERSPERCENTMETRICVALUE");
        Map(m => m.NetPurposeEnergyConsumedRenewablePercentMetricValue).Name("NETPURPOSEENERGYCONSUMEDRENEWABLEPERCENTMETRICVALUE");
        Map(m => m.NetPurposeRandDInvestmentPercentOfRevenueMetricValue).Name("NETPURPOSERANDDINVESTMENTPERCENTOFREVENUEMETRICVALUE");
        Map(m => m.NetPurposeCustomersMetricValue).Name("NETPURPOSECUSTOMERSMETRICVALUE");
        Map(m => m.NetPurposeCustomersPreviouslyExcludedMetricValue).Name("NETPURPOSECUSTOMERSPREVIOUSLYEXCLUDEDMETRICVALUE");
        Map(m => m.NetPurposeNewCustomersMetricValue).Name("NETPURPOSENEWCUSTOMERSMETRICVALUE");
        Map(m => m.NetPurposeNewCustomersPreviouslyExcludedMetricValue).Name("NETPURPOSENEWCUSTOMERSPREVIOUSLYEXCLUDEDMETRICVALUE");
        Map(m => m.NetPurposeInsurancePoliciesPreviouslyExcludedMetricValue).Name("NETPURPOSEINSURANCEPOLICIESPREVIOUSLYEXCLUDEDMETRICVALUE");
        Map(m => m.NetPurposePatientsTreatedMetricValue).Name("NETPURPOSEPATIENTSTREATEDMETRICVALUE");
        Map(m => m.NetPurposeRandDInvestmentMetricValue).Name("NETPURPOSERANDDINVESTMENTMETRICVALUE");
        Map(m => m.NetPurposeGrossInsurancePremiumsPreviouslyExcludedMetricValue).Name("NETPURPOSEGROSSINSURANCEPREMIUMSPREVIOUSLYEXCLUDEDMETRICVALUE");

        // --- Raw Values ---
        Map(m => m.NetPurposeEvicRawValue).Name("NETPURPOSEEVIC_RAWVALUE");
        Map(m => m.NetPurposeFemaleEmployeesPercentRawValue).Name("NETPURPOSEFEMALEEMPLOYEESPERCENT_RAWVALUE");
        Map(m => m.NetPurposeFemaleManagersPercentRawValue).Name("NETPURPOSEFEMALEMANAGERSPERCENT_RAWVALUE");
        Map(m => m.NetPurposeOperationalWasteGeneratedRawValue).Name("NETPURPOSEOPERATIONALWASTEGENERATED_RAWVALUE");
        Map(m => m.NetPurposeWaterConsumedRawValue).Name("NETPURPOSEWATERCONSUMED_RAWVALUE");
        Map(m => m.NetPurposeOperationalWasteRecycledPercentMetricRawValue).Name("NETPURPOSEOPERATIONALWASTERECYCLEDPERCENTMETRIC_RAWVALUE");
        Map(m => m.NetPurposeCeoMedianEmployeeCompensationRatioMetricRawValue).Name("NETPURPOSECEOMEDIANEMPLOYEECOMPENSATIONRATIOMETRIC_RAWVALUE");
        Map(m => m.NetPurposeFemaleboardMembersPercentMetricRawValue).Name("NETPURPOSEFEMALEBOARDMEMBERSPERCENTMETRIC_RAWVALUE");
        Map(m => m.NetPurposeEnergyConsumedRenewablePercentMetricRawValue).Name("NETPURPOSEENERGYCONSUMEDRENEWABLEPERCENTMETRIC_RAWVALUE");
        Map(m => m.NetPurposeRandDInvestmentPercentOfRevenueMetricRawValue).Name("NETPURPOSERANDDINVESTMENTPERCENTOFREVENUEMETRIC_RAWVALUE");
        Map(m => m.NetPurposeCustomersMetricRawValue).Name("NETPURPOSECUSTOMERSMETRIC_RAWVALUE");
        Map(m => m.NetPurposeCustomersPreviouslyExcludedMetricRawValue).Name("NETPURPOSECUSTOMERSPREVIOUSLYEXCLUDEDMETRIC_RAWVALUE");
        Map(m => m.NetPurposeNewCustomersMetricRawValue).Name("NETPURPOSENEWCUSTOMERSMETRIC_RAWVALUE");
        Map(m => m.NetPurposeNewCustomersPreviouslyExcludedMetricRawValue).Name("NETPURPOSENEWCUSTOMERSPREVIOUSLYEXCLUDEDMETRIC_RAWVALUE");
        Map(m => m.NetPurposeInsurancePoliciesPreviouslyExcludedMetricRawValue).Name("NETPURPOSEINSURANCEPOLICIESPREVIOUSLYEXCLUDEDMETRIC_RAWVALUE");
        Map(m => m.NetPurposePatientsTreatedMetricRawValue).Name("NETPURPOSEPATIENTSTREATEDMETRIC_RAWVALUE");
        Map(m => m.NetPurposeRandDInvestmentMetricRawValue).Name("NETPURPOSERANDDINVESTMENTMETRIC_RAWVALUE");
        Map(m => m.NetPurposeGrossInsurancePremiumsPreviouslyExcludedMetricRawValue).Name("NETPURPOSEGROSSINSURANCEPREMIUMSPREVIOUSLYEXCLUDEDMETRIC_RAWVALUE");
    }
}
