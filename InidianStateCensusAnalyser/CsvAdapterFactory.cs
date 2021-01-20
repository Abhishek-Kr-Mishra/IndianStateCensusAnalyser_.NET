using System;
using System.Collections.Generic;
using System.Text;

namespace InidianStateCensusAnalyser
{
    public class CsvAdapterFactory
    {
        public Dictionary<string,CensusDTO> LoadCsvData(CensusAnalyser.Country country, string csvFilePath, string dataHeaders)
        {
            switch (country)
            {
                case (CensusAnalyser.Country.INDIA):
                    return new IndianCensusAdapter().LoadCensusData(csvFilePath, dataHeaders);
                //case (CensusAnalyser.Country.US):
                //    return new USCensusAdapter().LoadUSCensusDta(csvFilePath, dataHeaders);
                default:
                    throw new CensusAnalyserException("No such Country", CensusAnalyserException.ExceptionType.NO_SUCH_COUNTRY);
            }
        }
        internal Dictionary<string, CensusDTO> LoadStateCsvData(CSVStatesCode.Country country, string csvFilePath, string dataHeaders)
        {
            switch (country)
            {
                case (CSVStatesCode.Country.INDIA):
                    return new IndianCensusAdapter().LoadCensusData(csvFilePath, dataHeaders);
                default:
                    throw new CensusAnalyserException("No such Country", CensusAnalyserException.ExceptionType.NO_SUCH_COUNTRY);
            }
        }
    }
}
