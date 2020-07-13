using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Geo.Impl;
using NUnit.Framework;

namespace HealthYes.Web.UnitTests.Core.Impl
{
    [TestFixture]
    public class ZipCodeParserTester
    {
        private readonly IZipCodeParser _zipCodeParser = new ZipCodeParser();

        [Test]
        public void ParseStringIntoZipCodesReturnsEmptyListWhenEmptyStringGiven()
        {
            List<string> zipCodes = _zipCodeParser.ParseStringIntoZipCodes(string.Empty);

            Assert.IsNotNull(zipCodes);
            Assert.IsEmpty(zipCodes, "Non-empty list of zip codes were returned.");
        }

        [Test]
        public void ParseStringIntoZipCodesReturnsListWithOneZipCodeWhenStringContains5Digits() 
        {
            const int expectedNumberOfZipCodes = 1;
            const string zipCodeString = "12345";

            List<string> zipCodes = _zipCodeParser.ParseStringIntoZipCodes(zipCodeString);

            Assert.AreEqual(expectedNumberOfZipCodes, zipCodes.Count, "Incorrect number of zip codes returned.");
        }

        [Test]
        public void ParseStringIntoZipCodesReturnsSingleZipCodeGivenInZipCodeString()
        {
            const string expectedZipCode = "23846";

            List<string> zipCodes = _zipCodeParser.ParseStringIntoZipCodes(expectedZipCode);

            Assert.AreEqual(expectedZipCode, zipCodes.Single(), "Returned zip code was not parsed correctly.");
        }

        [Test]
        public void ParseStringIntoZipCodesReturnsSingleZipWhenGivenStringContainsZipCodeAndOtherCharacters()
        {
            const string expectedZipCode = "83382";
            const string zipCodeString = "asdfjk" + expectedZipCode + "djicne";

            List<string> zipCodes = _zipCodeParser.ParseStringIntoZipCodes(zipCodeString);

            Assert.AreEqual(expectedZipCode, zipCodes.Single(), "Returned zip code was not parsed correctly.");
        }

        [Test]
        public void ParseStringIntoZipCodesReturnsTwoZipCodesWhenStringContainsTwoZipsSeparatedBySpaces()
        {
            const int expectedNumberOfZipCodes = 2;
            const string zipCodeString = "23848   28282";

            List<string> zipCodes = _zipCodeParser.ParseStringIntoZipCodes(zipCodeString);

            Assert.AreEqual(expectedNumberOfZipCodes, zipCodes.Count, "Incorrect number of zip codes returned.");
        }

        [Test]
        public void ParseStringIntoZipCodesReturnsTwoZipsWhenGivenStringContainsTwoZipsOnMultipleLines()
        {
            const int expectedNumberOfZipCodes = 2;
            string zipCodeString = "84828" + Environment.NewLine + "32828";

            List<string> zipCodes = _zipCodeParser.ParseStringIntoZipCodes(zipCodeString);

            Assert.AreEqual(expectedNumberOfZipCodes, zipCodes.Count, "Incorrect number of zip codes returned.");
        }

        [Test]
        public void ParseStringIntoZipCodesReturns3ZipsWhenGivenStringContains3CommaSeparatedZips()
        {
            const int expectedNumberOfZipCodes = 3;
            const string zipCodeString = "84828,32828,57238";

            List<string> zipCodes = _zipCodeParser.ParseStringIntoZipCodes(zipCodeString);

            Assert.AreEqual(expectedNumberOfZipCodes, zipCodes.Count, "Incorrect number of zip codes returned.");
        }

        [Test]
        public void ParseStringIntoZipCodesReturnsOneZipWhenSecondZipInStringIsNot5Digits()
        {
            const int expectedNumberOfZipCodes = 1;
            const string expectedZipCode = "12345";
            const string zipCodeString = expectedZipCode + ",3282,5723338";

            List<string> zipCodes = _zipCodeParser.ParseStringIntoZipCodes(zipCodeString);

            Assert.AreEqual(expectedNumberOfZipCodes, zipCodes.Count, "Incorrect number of zip codes returned.");
            Assert.AreEqual(expectedZipCode, zipCodes.Single(), "Incorrect zip code returned.");
        }

        [Test]
        public void ParseZipCodesIntoStringReturnsEmptyStringWhenEmptyListOfZipCodesGiven()
        {
            var zipCodes = new List<ZipCode>();

            string zipCodeString = _zipCodeParser.ParseZipCodesIntoString(zipCodes);

            Assert.IsNotNull(zipCodeString, "Null Zip Code String returned.");
            Assert.IsEmpty(zipCodeString, "Non-empty Zip Code String returned.");
        }

        [Test]
        public void ParseZipCodesIntoStringReturnsStringWith1ZipCodeWhenListWith1ZipCodeGiven()
        {
            const string expectedZipCodeString = "12345";
            var zipCodes = new List<ZipCode> {new ZipCode {Zip = expectedZipCodeString}};

            string zipCodeString = _zipCodeParser.ParseZipCodesIntoString(zipCodes);

            Assert.AreEqual(expectedZipCodeString, zipCodeString, "Incorrect Zip Code String returned.");
        }

        [Test]
        public void ParseZipCodesIntoStringReturns2ZipsSeparatedByCommaWhenGivenListOf2ZipCodes()
        {
            const string zipCode1 = "33333";
            const string zipCode2 = "44444";
            const string expectedString = zipCode1 + ", " + zipCode2;
            var zipCodes = new List<ZipCode> {new ZipCode {Zip = zipCode1}, new ZipCode {Zip = zipCode2}};

            string zipCodeString = _zipCodeParser.ParseZipCodesIntoString(zipCodes);
            Assert.AreEqual(expectedString, zipCodeString, "Incorrect Zip Code String returned.");
        }

        [Test]
        public void ParseZipCodesIntoStringReturnsStringWith4CommasWhen5ZipCodesGiven()
        {
            var zipCodes = new List<ZipCode> {new ZipCode(), new ZipCode(), new ZipCode(), new ZipCode(), new ZipCode()};

            string zipCodeString = _zipCodeParser.ParseZipCodesIntoString(zipCodes);

            const int expectedNumberOfCommas = 4;
            Assert.AreEqual(expectedNumberOfCommas, new Regex(",").Matches(zipCodeString).Count);
        }
    }
}