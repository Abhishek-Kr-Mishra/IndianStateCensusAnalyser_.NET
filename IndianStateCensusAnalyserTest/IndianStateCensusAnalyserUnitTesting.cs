using InidianStateCensusAnalyser;
using InidianStateCensusAnalyser.POCO;
using NUnit.Framework;
using System.Collections.Generic;
using static InidianStateCensusAnalyser.CensusAnalyser;

namespace IndianStateCensusAnalyserTest
{
    public class IndianStateCensusAnalyserUnitTesting
    {
        string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        string indianStateCodeHeaders = "SrNo,State Name,TIN,StateCode";
        string wrongIndianStateCensusHeaders = "State,Populatioon,AreaInSqK,DensityPerSqKm";
        string wrongIndianStateCodeHeaders = "SrNoo,StateName,TIN,State Code";
        string wrongDelimiterIndiaStateCensusDataType = @"E:\Fellowship_Projects\IndianStateCensusAnalyser_.NET\InidianStateCensusAnalyser\Census Files\WrongIndiaStateCensusData.docx";
        string wrongDelimiterIndiaStateCodeType = @"E:\Fellowship_Projects\IndianStateCensusAnalyser_.NET\InidianStateCensusAnalyser\Census Files\WrongIndiaStateCode.docx";
        string indiaStateCensusDataPath = @"E:\Fellowship_Projects\IndianStateCensusAnalyser_.NET\InidianStateCensusAnalyser\Census Files\IndiaStateCensusData.csv";
        string indiaStateCodePath = @"E:\Fellowship_Projects\IndianStateCensusAnalyser_.NET\InidianStateCensusAnalyser\Census Files\IndiaStateCode.csv";
        string wrongIndiaStateCensusDataPath = @"E:\Fellowship_Projects\IndianStateCensusAnalyser_.NET\InidianStateCensusAnalyser\Census Files\IndianData.csv";
        string wrongIndiaStateCodePath = @"E:\Fellowship_Projects\IndianStateCensusAnalyser_.NET\InidianStateCensusAnalyser\Census Files\IndianData.csv";
        string wrongDelimiterIndianCensusFilePath = @"E:\Fellowship_Projects\IndianStateCensusAnalyser_.NET\InidianStateCensusAnalyser\Census Files\DelimiterIndiaStateCensusData.csv";
        string wrongDelimiterIndiaStateCodePath = @"E:\Fellowship_Projects\IndianStateCensusAnalyser_.NET\InidianStateCensusAnalyser\Census Files\DelimiterIndiaStateCode.csv";

        InidianStateCensusAnalyser.CensusAnalyser censusAnalyser;
        CSVStatesCode csvStatesCode;
        Dictionary<string,CensusDTO> totalRecord;
        Dictionary<string,CensusDTO> stateRecord;
        [SetUp]
        public void Setup()
        {
            csvStatesCode = new CSVStatesCode();
            censusAnalyser = new InidianStateCensusAnalyser.CensusAnalyser();
            totalRecord = new Dictionary<string, CensusDTO>();
            stateRecord = new Dictionary<string, CensusDTO>();
        }

        [Test]
        public void GivenIndianCensusDataFile_WhenReaded_ShouldReturnCensusDataCount()
        {
            totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, indiaStateCensusDataPath,indianStateCensusHeaders);
            stateRecord = censusAnalyser.LoadCensusData(Country.INDIA, indiaStateCodePath, indianStateCodeHeaders);
            Assert.AreEqual(29,totalRecord.Count);
            Assert.AreEqual(37, stateRecord.Count);
        }
        [Test]
        public void GivenWrongIndianCensusDataFile_WhenReaded_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongIndiaStateCensusDataPath, indianStateCensusHeaders));
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongIndiaStateCodePath, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, censusException.eType);
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, stateException.eType);
        }
        [Test]
        public void GivenWrongIndianCensusDataType_WhenReaded_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongDelimiterIndiaStateCensusDataType, indianStateCensusHeaders));
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongDelimiterIndiaStateCodeType, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILETYPE, censusException.eType);
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILETYPE, stateException.eType);
        }
        [Test]
        public void GivenCorrectIndianCensusCsvFileAndWrongHeader_WhenReaded_ShouldReturnInvalidHeaderCoustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, indiaStateCensusDataPath, wrongIndianStateCensusHeaders));
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, indiaStateCodePath, wrongIndianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, censusException.eType);
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, stateException.eType);
        }
        [Test]
        public void GivenIndianCensusDataFileWithWrongDelimeter_WhenReaded_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongDelimiterIndianCensusFilePath, indianStateCensusHeaders));
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongDelimiterIndiaStateCodePath, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMETER, censusException.eType);
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMETER, stateException.eType);
        }
        [Test]
        public void GivenIndianCensusDataFile_WhenReaded_ShouldReturnCensusDataCountUsingLoadStateCsvData()
        {
            totalRecord = csvStatesCode.LoadStateData(CSVStatesCode.Country.INDIA, indiaStateCensusDataPath, indianStateCensusHeaders);
            stateRecord = csvStatesCode.LoadStateData(CSVStatesCode.Country.INDIA, indiaStateCodePath, indianStateCodeHeaders);
            Assert.AreEqual(29, totalRecord.Count);
            Assert.AreEqual(37, stateRecord.Count);
        }
        [Test]
        public void GivenWrongIndianCensusDataFile_WhenReaded_ShouldReturnCustomExceptionUsingStateCodeObject()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => csvStatesCode.LoadStateData(CSVStatesCode.Country.INDIA, wrongIndiaStateCensusDataPath, indianStateCensusHeaders));
            var stateException = Assert.Throws<CensusAnalyserException>(() => csvStatesCode.LoadStateData(CSVStatesCode.Country.INDIA, wrongIndiaStateCodePath, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, censusException.eType);
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, stateException.eType);
        }
        [Test]
        public void GivenWrongIndianCensusDataType_WhenReaded_ShouldReturnCustomExceptionUsingStateCodeObject()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => csvStatesCode.LoadStateData(CSVStatesCode.Country.INDIA, wrongDelimiterIndiaStateCensusDataType, indianStateCensusHeaders));
            var stateException = Assert.Throws<CensusAnalyserException>(() => csvStatesCode.LoadStateData(CSVStatesCode.Country.INDIA, wrongDelimiterIndiaStateCodeType, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILETYPE, censusException.eType);
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILETYPE, stateException.eType);
        }
        [Test]
        public void GivenCorrectIndianCensusCsvFileAndWrongHeader_WhenReaded_ShouldReturnInvalidHeaderCoustomExceptionUsingStateCodeObject()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => csvStatesCode.LoadStateData(CSVStatesCode.Country.INDIA, indiaStateCensusDataPath, wrongIndianStateCensusHeaders));
            var stateException = Assert.Throws<CensusAnalyserException>(() => csvStatesCode.LoadStateData(CSVStatesCode.Country.INDIA, indiaStateCodePath, wrongIndianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, censusException.eType);
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, stateException.eType);
        }
        [Test]
        public void GivenIndianCensusDataFileWithWrongDelimeter_WhenReaded_ShouldReturnCustomExceptionUsingStateCodeObject()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => csvStatesCode.LoadStateData(CSVStatesCode.Country.INDIA, wrongDelimiterIndianCensusFilePath, indianStateCensusHeaders));
            var stateException = Assert.Throws<CensusAnalyserException>(() => csvStatesCode.LoadStateData(CSVStatesCode.Country.INDIA, wrongDelimiterIndiaStateCodePath, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMETER, censusException.eType);
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMETER, stateException.eType);
        }
    }
}