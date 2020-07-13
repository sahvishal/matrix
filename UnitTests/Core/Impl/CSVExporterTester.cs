using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application.Impl;
using NUnit.Framework;

namespace Falcon.Web.UnitTests.Core.Impl
{
    class TestType
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    [TestFixture]
    public class CSVExporterTester
    {
        private CSVExporter<TestType> _csvExporter;

        [SetUp]
        public void Setup()
        {
            _csvExporter = new CSVExporter<TestType>(                
                new CSVColumn<TestType>("Name", t => t.Name),
                new CSVColumn<TestType>("Age",  t => t.Age.ToString())
            );
        }

        [Test]
        public void CSVExporterJoinsHeaders()
        {
            const string expectedHeader = "\"Name\",\"Age\"";

            string header = _csvExporter.Header;            

            Assert.AreEqual(expectedHeader, header);
        }

        [Test]
        public void CSVExporterExportsSingleObject()
        {
            TestType myObj = new TestType { Name = "Billy Jean", Age = 22 };
            
            const string expectedCsv = @"""Billy Jean"",""22""";

            string csv = _csvExporter.ExportObject(myObj);

            Assert.AreEqual(expectedCsv, csv);
        }

        [Test]
        public void CSVExporterExportsSingleObjectWithEmbeddedQuotes()
        {
            TestType myObj = new TestType { Name = @"""Ted""", Age = 22 };

            const string expectedCsv = @"""""""Ted"""""",""22""";

            string csv = _csvExporter.ExportObject(myObj);

            Assert.AreEqual(expectedCsv, csv);
        }

        [Test]
        public void CSVExporterDoesNotOutputNulls()
        {
            TestType myObj = new TestType { Name = null, Age = 22 };

            const string expectedCsv = @",""22""";

            string csv = _csvExporter.ExportObject(myObj);

            Assert.AreEqual(expectedCsv, csv);
        }

        [Test]
        public void CSVExporterReturnsExpectedNumberOfLines()
        {
            var myObjs = new List<TestType> {
                new TestType { Name = "Alice", Age = 22 },
                new TestType { Name = "Bob", Age = 35 },
            };

            int count = _csvExporter.ExportObjects(myObjs).Count();

            Assert.AreEqual(myObjs.Count, count);
        }
    }
}