# NetPurpose RawValue Lookup



This is an ad hoc project to align Snowflake values with the corresponding raw NetPurpose values.  It is a C# console application.  It takes as input `RDP.V_ESG_ISSUER_METRIC`, and the raw NetPurpose metrics from `Esg.NetPurpose.IssuerLevelMetrics` and `EsgIssuerMapping`.  It produces a new CSV file (`V_ESG_ISSUER_METRIC_RAW`) which will have the raw/unprocessed metrics values for the NetPurpose Metrics.  Please note, this programs touches on **ONLY** NetPurpose metrics, i.e. columns with the word NetPurpose in it. 
