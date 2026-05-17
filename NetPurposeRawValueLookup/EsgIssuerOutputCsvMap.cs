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
        Map(m => m.NetPurposeEvicRawValue).Name("NETPURPOSEEVICRAWVALUE");
        Map(m => m.NetPurposeFemaleEmployeesPercentRawValue).Name("NETPURPOSEFEMALEEMPLOYEESPERCENTRAWVALUE");
        Map(m => m.NetPurposeFemaleManagersPercentRawValue).Name("NETPURPOSEFEMALEMANAGERSPERCENTRAWVALUE");
        Map(m => m.NetPurposeOperationalWasteGeneratedRawValue).Name("NETPURPOSEOPERATIONALWASTEGENERATEDRAWVALUE");
        Map(m => m.NetPurposeWaterConsumedRawValue).Name("NETPURPOSEWATERCONSUMEDRAWVALUE");
        Map(m => m.NetPurposeOperationalWasteRecycledPercentMetricRawValue).Name("NETPURPOSEOPERATIONALWASTERECYCLEDPERCENTMETRICRAWVALUE");
        Map(m => m.NetPurposeCeoMedianEmployeeCompensationRatioMetricRawValue).Name("NETPURPOSECEOMEDIANEMPLOYEECOMPENSATIONRATIOMETRICRAWVALUE");
        Map(m => m.NetPurposeFemaleboardMembersPercentMetricRawValue).Name("NETPURPOSEFEMALEBOARDMEMBERSPERCENTMETRICRAWVALUE");
        Map(m => m.NetPurposeEnergyConsumedRenewablePercentMetricRawValue).Name("NETPURPOSEENERGYCONSUMEDRENEWABLEPERCENTMETRICRAWVALUE");
        Map(m => m.NetPurposeRandDInvestmentPercentOfRevenueMetricRawValue).Name("NETPURPOSERANDDINVESTMENTPERCENTOFREVENUEMETRICRAWVALUE");
        Map(m => m.NetPurposeCustomersMetricRawValue).Name("NETPURPOSECUSTOMERSMETRICRAWVALUE");
        Map(m => m.NetPurposeCustomersPreviouslyExcludedMetricRawValue).Name("NETPURPOSECUSTOMERSPREVIOUSLYEXCLUDEDMETRICRAWVALUE");
        Map(m => m.NetPurposeNewCustomersMetricRawValue).Name("NETPURPOSENEWCUSTOMERSMETRICRAWVALUE");
        Map(m => m.NetPurposeNewCustomersPreviouslyExcludedMetricRawValue).Name("NETPURPOSENEWCUSTOMERSPREVIOUSLYEXCLUDEDMETRICRAWVALUE");
        Map(m => m.NetPurposeInsurancePoliciesPreviouslyExcludedMetricRawValue).Name("NETPURPOSEINSURANCEPOLICIESPREVIOUSLYEXCLUDEDMETRICRAWVALUE");
        Map(m => m.NetPurposePatientsTreatedMetricRawValue).Name("NETPURPOSEPATIENTSTREATEDMETRICRAWVALUE");
        Map(m => m.NetPurposeRandDInvestmentMetricRawValue).Name("NETPURPOSERANDDINVESTMENTMETRICRAWVALUE");
        Map(m => m.NetPurposeGrossInsurancePremiumsPreviouslyExcludedMetricRawValue).Name("NETPURPOSEGROSSINSURANCEPREMIUMSPREVIOUSLYEXCLUDEDMETRICRAWVALUE");
    }
}