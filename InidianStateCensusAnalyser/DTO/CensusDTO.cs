using InidianStateCensusAnalyser.POCO;
using System;
using System.Collections.Generic;
using System.Text;

namespace InidianStateCensusAnalyser
{
    public class CensusDTO
    {
        public int serialNumber;
        public string stateName;
        public string state;
        public int tin;
        public string stateCode;
        public long population;
        public long area;
        public long density;
        public long housingUnits;
        public double totalArea;
        public double waterArea;
        public double landArea;
        public double populationDesity;
        public double housingDensity;

        public CensusDTO(StateCodeDAO stateCodeDAO)
        {
            this.serialNumber = stateCodeDAO.serialNumber;
            this.stateName = stateCodeDAO.stateName;
            this.tin = stateCodeDAO.tin;
            this.stateCode = stateCodeDAO.stateCode;
        }
        public CensusDTO(CensusDataDAO censusDataDTO)
        {
            this.state = censusDataDTO.state;
            this.population = censusDataDTO.population;
            this.area = censusDataDTO.area;
            this.density = censusDataDTO.density;
        }
    }
}
