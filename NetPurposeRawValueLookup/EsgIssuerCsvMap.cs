using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using CsvHelper;

namespace NetPurposeRawValueLookup;

public class EsgIssuerCsvMap: ClassMap<EsgIssuer>
{
    public EsgIssuerCsvMap()
    {
        Map(m => m.ReportingDate).Name("REPORTING_DATE").TypeConverterOption.Format("yyyy-MM-dd");
        Map(m => m.EsgIssuerId).Name("ESG_ISSUER_ID");
        Map(m => m.AladdinIssuerId).Name("ALADDIN_ISSUER_ID");
        Map(m => m.MsciIssuerId).Name("MSCI_ISSUERID");
        Map(m => m.IssuerName).Ignore();
        Map(m => m.Lei).Name("LEI");
        Map(m => m.Isin).Name("ISIN");

        Map(m => m.NetPurposeEvicCalculatedValue).Name("NETPURPOSEEVICCALCULATEDVALUE").TypeConverter<NullableDecimalConverter>();
        Map(m => m.NetPurposeEvicValue).Name("NETPURPOSEEVICVALUE").TypeConverter<NullableDecimalConverter>();
        Map(m => m.NetPurposeFemaleEmployeesPercentValue).Name("NETPURPOSEFEMALEEMPLOYEESPERCENTVALUE").TypeConverter<NullableDecimalConverter>();
        Map(m => m.NetPurposeFemaleManagersPercentValue).Name("NETPURPOSEFEMALEMANAGERSPERCENTVALUE").TypeConverter<NullableDecimalConverter>();
        Map(m => m.NetPurposeIssuerId).Name("NETPURPOSEISSUERID");
        Map(m => m.NetPurposeOperationalWasteGeneratedMetricCalculatedValue).Name("NETPURPOSEOPERATIONALWASTEGENERATEDMETRICCALCULATEDVALUE").TypeConverter<NullableDecimalConverter>();
        Map(m => m.NetPurposeOperationalWasteGeneratedValue).Name("NETPURPOSEOPERATIONALWASTEGENERATEDVALUE").TypeConverter<NullableDecimalConverter>();
        Map(m => m.NetPurposeWaterConsumedMetricCalculatedValue).Name("NETPURPOSEWATERCONSUMEDMETRICCALCULATEDVALUE").TypeConverter<NullableDecimalConverter>();
        Map(m => m.NetPurposeWaterConsumedValue).Name("NETPURPOSEWATERCONSUMEDVALUE").TypeConverter<NullableDecimalConverter>();

        Map(m => m.NetPurposeOperationalWasteRecycledPercentMetricValue).Name("NETPURPOSEOPERATIONALWASTERECYCLEDPERCENTMETRICVALUE").TypeConverter<NullableDecimalConverter>();
        Map(m => m.NetPurposeCeoMedianEmployeeCompensationRatioMetricValue).Name("NETPURPOSECEOMEDIANEMPLOYEECOMPENSATIONRATIOMETRICVALUE").TypeConverter<NullableDecimalConverter>();
        Map(m => m.NetPurposeFemaleboardMembersPercentMetricValue).Name("NETPURPOSEFEMALEBOARDMEMBERSPERCENTMETRICVALUE").TypeConverter<NullableDecimalConverter>();
        Map(m => m.NetPurposeEnergyConsumedRenewablePercentMetricValue).Name("NETPURPOSEENERGYCONSUMEDRENEWABLEPERCENTMETRICVALUE").TypeConverter<NullableDecimalConverter>();
        Map(m => m.NetPurposeRandDInvestmentPercentOfRevenueMetricValue).Name("NETPURPOSERANDDINVESTMENTPERCENTOFREVENUEMETRICVALUE").TypeConverter<NullableDecimalConverter>();
        Map(m => m.NetPurposeCustomersMetricValue).Name("NETPURPOSECUSTOMERSMETRICVALUE").TypeConverter<NullableDecimalConverter>();
        Map(m => m.NetPurposeCustomersPreviouslyExcludedMetricValue).Name("NETPURPOSECUSTOMERSPREVIOUSLYEXCLUDEDMETRICVALUE").TypeConverter<NullableDecimalConverter>();
        Map(m => m.NetPurposeNewCustomersMetricValue).Name("NETPURPOSENEWCUSTOMERSMETRICVALUE").TypeConverter<NullableDecimalConverter>();
        Map(m => m.NetPurposeNewCustomersPreviouslyExcludedMetricValue).Name("NETPURPOSENEWCUSTOMERSPREVIOUSLYEXCLUDEDMETRICVALUE").TypeConverter<NullableDecimalConverter>();
        Map(m => m.NetPurposeInsurancePoliciesPreviouslyExcludedMetricValue).Name("NETPURPOSEINSURANCEPOLICIESPREVIOUSLYEXCLUDEDMETRICVALUE").TypeConverter<NullableDecimalConverter>();
        Map(m => m.NetPurposePatientsTreatedMetricValue).Name("NETPURPOSEPATIENTSTREATEDMETRICVALUE").TypeConverter<NullableDecimalConverter>();
        Map(m => m.NetPurposeRandDInvestmentMetricValue).Name("NETPURPOSERANDDINVESTMENTMETRICVALUE").TypeConverter<NullableDecimalConverter>();
        Map(m => m.NetPurposeGrossInsurancePremiumsPreviouslyExcludedMetricValue).Name("NETPURPOSEGROSSINSURANCEPREMIUMSPREVIOUSLYEXCLUDEDMETRICVALUE").TypeConverter<NullableDecimalConverter>();
    }
}