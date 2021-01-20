using System;
using System.Collections.Generic;
using System.Text;

namespace InidianStateCensusAnalyser
{
    public class CSVStatesCode
    {
        public enum Country
        {
            INDIA, US, BRAZIL
        }
        public Dictionary<string, CensusDTO> stateMap;
        public Dictionary<string, CensusDTO> LoadStateData(Country country, string csvFilePath, string dataHeaders)
        {
            stateMap = new CsvAdapterFactory().LoadStateCsvData(country, csvFilePath, dataHeaders);
            return stateMap;
        }
    }
}
