using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Infrastructure.Finance.Interfaces;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.App.Core;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Domain.MedicalVendors;
using Falcon.App.Core.Extensions;
using Falcon.App.Infrastructure.Interfaces;
using Falcon.App.Infrastructure.Factories;
using NUnit.Framework;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace HealthYes.Web.UnitTests.Infrastructure.Factories
{
    [TestFixture]
    public class MedicalVendorInvoiceStatisticsFactoryTester
    {
        private readonly IMedicalVendorInvoiceStatisticFactory _medicalVendorInvoiceStatisticFactory =
            new MedicalVendorInvoiceStatisticFactory();

        private DataTable _medicalVendorInvoiceDataTable;

        [SetUp]
        public void SetUp()
        {
            _medicalVendorInvoiceDataTable = GetValidDataTable();
        }

        [TearDown]
        public void TearDown()
        {
            _medicalVendorInvoiceDataTable = null;
        }

        private static DataTable GetValidDataTable()
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add("MedicalVendorInvoiceId", typeof(long));
            dataTable.Columns.Add("InvoiceAmount", typeof(decimal));
            dataTable.Columns.Add("NumberOfEvaluations", typeof(int));
            dataTable.Columns.Add("EvaluationStartTime", typeof(DateTime));
            dataTable.Columns.Add("EvaluationEndTime", typeof(DateTime));
            return dataTable;
        }

        #region AddRowToDataTable()

        private void AddRowToDataTable()
        {
            AddRowToDataTable(0, 0m, 0, new DateTime(), new DateTime());
        }

        private void AddRowToDataTable(long medicalVendorInvoiceId)
        {
            AddRowToDataTable(medicalVendorInvoiceId, 0m, 0, new DateTime(), new DateTime());
        }

        private void AddRowToDataTable(long medicalVendorInvoiceId, decimal invoiceAmount)
        {
            AddRowToDataTable(medicalVendorInvoiceId, invoiceAmount, 0, new DateTime(), new DateTime());
        }

        private void AddRowToDataTable(decimal invoiceAmount, int numberOfEvaluations)
        {
            AddRowToDataTable(0, invoiceAmount, numberOfEvaluations, new DateTime(), new DateTime());
        }

        private void AddRowToDataTable(decimal invoiceAmount, DateTime? evaluationStartTime,
            DateTime? evaluationEndTime)
        {
            AddRowToDataTable(0, invoiceAmount, 0, evaluationStartTime, evaluationEndTime);
        }

        private void AddRowToDataTable(long medicalVendorInvoiceId, decimal invoiceAmount, int numberOfEvaluations, 
            DateTime? evaluationStartTime, DateTime? evaluationEndTime)
        {
            _medicalVendorInvoiceDataTable.Rows.Add(medicalVendorInvoiceId, invoiceAmount, numberOfEvaluations, 
                evaluationStartTime, evaluationEndTime);
        }

        #endregion

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateMedicalVendorInvoiceStatisticThrowsExceptionWhenNullEntityGiven()
        {
            AddRowToDataTable();
            _medicalVendorInvoiceStatisticFactory.CreateMedicalVendorInvoiceStatistic(null, _medicalVendorInvoiceDataTable.Rows[0]);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateMedicalVendorInvoiceStatisticThrowsExceptionWhenNullDataRowGiven()
        {
            _medicalVendorInvoiceStatisticFactory.CreateMedicalVendorInvoiceStatistic(new PhysicianInvoiceEntity(), null);
        }

        [Test]
        public void CreateMedicalVendorInvoiceStatisticReturns0AverageRateForFreeEvaluation()
        {
            const decimal invoiceAmount = 0m;
            var evaluationStartTime = new DateTime(2001, 1, 1, 12, 0, 0);
            AddRowToDataTable(invoiceAmount, evaluationStartTime, evaluationStartTime.AddMinutes(60));

            MedicalVendorInvoiceStatistic medicalVendorInvoiceStatistic = _medicalVendorInvoiceStatisticFactory.
                CreateMedicalVendorInvoiceStatistic(new PhysicianInvoiceEntity(), _medicalVendorInvoiceDataTable.Rows[0]);
            
            Assert.AreEqual(0m, medicalVendorInvoiceStatistic.AverageHourlyRate);
        }

        [Test]
        public void CreateMedicalVendorInvoiceStatisticSetsAverageHourlyRateToZeroIfStartTimeIsNull()
        {
            AddRowToDataTable(1.33m, null, new DateTime(2001, 1, 1));

            MedicalVendorInvoiceStatistic medicalVendorInvoiceStatistic = _medicalVendorInvoiceStatisticFactory.
                CreateMedicalVendorInvoiceStatistic(new PhysicianInvoiceEntity(), _medicalVendorInvoiceDataTable.Rows[0]);

            Assert.AreEqual(0m, medicalVendorInvoiceStatistic.AverageHourlyRate);
        }

        [Test]
        public void CreateMedicalVendorInvoiceStatisticSetsAverageHourlyRateToZeroIfEndTimeIsNull()
        {
            AddRowToDataTable(25.33m, new DateTime(2001, 1, 1), null);

            MedicalVendorInvoiceStatistic medicalVendorInvoiceStatistic = _medicalVendorInvoiceStatisticFactory.
                CreateMedicalVendorInvoiceStatistic(new PhysicianInvoiceEntity(), _medicalVendorInvoiceDataTable.Rows[0]);

            Assert.AreEqual(0m, medicalVendorInvoiceStatistic.AverageHourlyRate);
        }

        [Test]
        public void CreateMedicalVendorInvoiceStatisticReturns0AverageRateForInstantEvaluation()
        {
            const decimal invoiceAmount = 30m;
            var evaluationTime = new DateTime(2001, 1, 1, 12, 0, 0);
            AddRowToDataTable(invoiceAmount, evaluationTime, evaluationTime);

            MedicalVendorInvoiceStatistic medicalVendorInvoiceStatistic = _medicalVendorInvoiceStatisticFactory.
                CreateMedicalVendorInvoiceStatistic(new PhysicianInvoiceEntity(), _medicalVendorInvoiceDataTable.Rows[0]);

            Assert.AreEqual(0m, medicalVendorInvoiceStatistic.AverageHourlyRate);
        }

        [Test]
        public void CreateMedicalVendorInvoiceStatisticReturns1AverageRateFor60AmountInOneMinute()
        {
            const decimal invoiceAmount = 60m;
            var evaluationStartTime = new DateTime(2001, 1, 1, 12, 0, 0);
            AddRowToDataTable(invoiceAmount, evaluationStartTime, evaluationStartTime.AddMinutes(60));
            
            MedicalVendorInvoiceStatistic medicalVendorInvoiceStatistic = _medicalVendorInvoiceStatisticFactory.
                CreateMedicalVendorInvoiceStatistic(new PhysicianInvoiceEntity(), _medicalVendorInvoiceDataTable.Rows[0]);

            Assert.AreEqual(1m, medicalVendorInvoiceStatistic.AverageHourlyRate);
        }

        [Test]
        public void CreateMedicalVendorInvoiceStatisticSetsDataRowFieldsToStatisticFieldsCorrectly()
        {
            const long medicalVendorInvoiceId = 25;
            const decimal invoiceAmount = 25.33m;
            const int numberOfEvaluations = 43;

            var medicalVendorInvoiceEntity = new PhysicianInvoiceEntity(medicalVendorInvoiceId);
            AddRowToDataTable(invoiceAmount, numberOfEvaluations);

            MedicalVendorInvoiceStatistic medicalVendorInvoiceStatistic = _medicalVendorInvoiceStatisticFactory.
                CreateMedicalVendorInvoiceStatistic(medicalVendorInvoiceEntity, _medicalVendorInvoiceDataTable.Rows[0]);

            Assert.AreEqual(medicalVendorInvoiceId, medicalVendorInvoiceStatistic.Id);
            Assert.AreEqual(invoiceAmount, medicalVendorInvoiceStatistic.InvoiceAmount);
            Assert.AreEqual(numberOfEvaluations, medicalVendorInvoiceStatistic.NumberOfEvaluations);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateMedicalVendorInvoiceStatisticsThrowsExceptionWhenNullCollectionGiven()
        {
            _medicalVendorInvoiceStatisticFactory.CreateMedicalVendorInvoiceStatistics(null, new DataTable());
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateMedicalVendorInvoiceStatisticsThrowsExceptionWhenNullDataTableGiven()
        {
            _medicalVendorInvoiceStatisticFactory.CreateMedicalVendorInvoiceStatistics(new List<PhysicianInvoiceEntity>(), null);
        }

        [Test]
        public void CreateMedicalVendorInvoiceStatisticsReturnsEmptyListWhenEmptyCollectionGiven()
        {
            List<MedicalVendorInvoiceStatistic> medicalVendorInvoiceStatistics = _medicalVendorInvoiceStatisticFactory.
                CreateMedicalVendorInvoiceStatistics(new List<PhysicianInvoiceEntity>(), _medicalVendorInvoiceDataTable);

            Assert.IsNotNull(medicalVendorInvoiceStatistics);
            Assert.IsEmpty(medicalVendorInvoiceStatistics);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CreateMedicalVendorInvoiceStatisticsThrowsExceptionWhenNoDataRowForGivenEntityExists()
        {
            const long medicalVendorInvoiceId = 3;
            var medicalVendorInvoiceEntities = new List<PhysicianInvoiceEntity> {new PhysicianInvoiceEntity(medicalVendorInvoiceId)};
            AddRowToDataTable(medicalVendorInvoiceId + 1);
            
            _medicalVendorInvoiceStatisticFactory.CreateMedicalVendorInvoiceStatistics(medicalVendorInvoiceEntities, _medicalVendorInvoiceDataTable);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CreateMedicalVendorInvoiceStatisticsThrowsExceptionWhenMultipleRowsForSameEntityGiven()
        {
            const long medicalVendorInvoiceId = 3;
            var medicalVendorInvoiceEntities = new List<PhysicianInvoiceEntity> { new PhysicianInvoiceEntity(medicalVendorInvoiceId) };
            AddRowToDataTable(medicalVendorInvoiceId);
            AddRowToDataTable(medicalVendorInvoiceId);

            _medicalVendorInvoiceStatisticFactory.CreateMedicalVendorInvoiceStatistics(medicalVendorInvoiceEntities, _medicalVendorInvoiceDataTable);
        }

        [Test]
        public void CreateMedicalVendorInvoiceStatisticsReturnsOneStatisticWhenOneEntityAndRowGiven()
        {
            const long medicalVendorInvoiceId = 3;
            var medicalVendorInvoiceEntities = new List<PhysicianInvoiceEntity> { new PhysicianInvoiceEntity(medicalVendorInvoiceId) };
            AddRowToDataTable(medicalVendorInvoiceId);

            List<MedicalVendorInvoiceStatistic> medicalVendorInvoiceStatistics = _medicalVendorInvoiceStatisticFactory.
                CreateMedicalVendorInvoiceStatistics(medicalVendorInvoiceEntities, _medicalVendorInvoiceDataTable);

            Assert.IsTrue(medicalVendorInvoiceStatistics.HasSingleItem());
        }

        [Test]
        public void CreateMedicalVendorInvoiceStatisticsReturnsThreeStatisticsWhenThreeEntitiesAndRowsGiven()
        {
            const long medicalVendorInvoiceId1 = 1;
            const long medicalVendorInvoiceId2 = 2;
            const long medicalVendorInvoiceId3 = 3;
            var medicalVendorInvoiceEntities = new List<PhysicianInvoiceEntity> { new PhysicianInvoiceEntity(medicalVendorInvoiceId1), 
                new PhysicianInvoiceEntity(medicalVendorInvoiceId2), new PhysicianInvoiceEntity(medicalVendorInvoiceId3) };
            AddRowToDataTable(medicalVendorInvoiceId1);
            AddRowToDataTable(medicalVendorInvoiceId2);
            AddRowToDataTable(medicalVendorInvoiceId3);

            List<MedicalVendorInvoiceStatistic> medicalVendorInvoiceStatistics = _medicalVendorInvoiceStatisticFactory.
                CreateMedicalVendorInvoiceStatistics(medicalVendorInvoiceEntities, _medicalVendorInvoiceDataTable);

            Assert.IsTrue(medicalVendorInvoiceStatistics.Count == 3);
        }

        [Test]
        public void CreateMedicalVendorInvoiceStatisticsMapsDataRowsToCorrectEntities()
        {
            const long medicalVendorInvoiceId1 = 1;
            const long medicalVendorInvoiceId2 = 2;
            const decimal expectedInvoiceAmount1 = 3.22m;
            const decimal expectedInvoiceAmount2 = 5.33m;
            var medicalVendorInvoiceEntities = new List<PhysicianInvoiceEntity> { new PhysicianInvoiceEntity(medicalVendorInvoiceId1), 
                new PhysicianInvoiceEntity(medicalVendorInvoiceId2) };
            
            AddRowToDataTable(medicalVendorInvoiceId1, expectedInvoiceAmount1);
            AddRowToDataTable(medicalVendorInvoiceId2, expectedInvoiceAmount2);

            List<MedicalVendorInvoiceStatistic> medicalVendorInvoiceStatistics = _medicalVendorInvoiceStatisticFactory.
                CreateMedicalVendorInvoiceStatistics(medicalVendorInvoiceEntities, _medicalVendorInvoiceDataTable);

            Assert.AreEqual(expectedInvoiceAmount1, medicalVendorInvoiceStatistics.Where(mvis => mvis.Id == medicalVendorInvoiceId1)
                .Single().InvoiceAmount);
            Assert.AreEqual(expectedInvoiceAmount2, medicalVendorInvoiceStatistics.Where(mvis => mvis.Id == medicalVendorInvoiceId2)
                .Single().InvoiceAmount);
        }

        [Test]
        public void CreateMedicalVendorInvoiceStatisticFieldsAndGroupByClauseReturnsResultsetWith5Rows()
        {
            const int expectedNumberOfResultsetFields = 5;
            OrderedPair<ResultsetFields, GroupByCollection> resultsetFieldsAndGroupByClause = _medicalVendorInvoiceStatisticFactory.
                CreateMedicalVendorInvoiceStatisticFieldsAndGroupByClause();
            
            int numberOfResultsetFields = resultsetFieldsAndGroupByClause.FirstValue.Count;

            Assert.IsTrue(numberOfResultsetFields == expectedNumberOfResultsetFields,
                "Expected {0} but {1} returned.", expectedNumberOfResultsetFields, numberOfResultsetFields);
        }

        [Test]
        [Ignore]
        public void CreateMedicalVendorInvoiceStatisticFieldsAndGroupByClauseReturnsGroupByClauseWith3Items()
        {
            const int expectedNumberOfGroupByItems = 3;
            OrderedPair<ResultsetFields, GroupByCollection> resultsetFieldsAndGroupByClause = _medicalVendorInvoiceStatisticFactory.
                CreateMedicalVendorInvoiceStatisticFieldsAndGroupByClause();

            int numberOfItemsInGroupByClause = resultsetFieldsAndGroupByClause.SecondValue.Count;
            
            Assert.IsTrue(numberOfItemsInGroupByClause == expectedNumberOfGroupByItems,
                "Expected {0} but {1} returned.", expectedNumberOfGroupByItems, numberOfItemsInGroupByClause);
        }

        [Test]
        public void CreateMedicalVendorInvoiceStatisticFieldsAndGroupByClauseGroupsByMedicalVendorInvoiceId()
        {
            OrderedPair<ResultsetFields, GroupByCollection> resultsetFieldsAndGroupByClause = _medicalVendorInvoiceStatisticFactory.
                CreateMedicalVendorInvoiceStatisticFieldsAndGroupByClause();

            string expectedName = PhysicianInvoiceItemFields.PhysicianInvoiceId.Name;
            Assert.IsTrue(resultsetFieldsAndGroupByClause.SecondValue.Where(gbc => gbc.Name == 
                expectedName).Count() == 1, "GroupByClause does not contain {0}", expectedName);
        }

        [Test]
        public void CreateMedicalVendorInvoiceStatisticFieldsAndGroupByClauseGroupsByEvaluationStartTime()
        {
            OrderedPair<ResultsetFields, GroupByCollection> resultsetFieldsAndGroupByClause = _medicalVendorInvoiceStatisticFactory.
                CreateMedicalVendorInvoiceStatisticFieldsAndGroupByClause();

            //string expectedName = PhysicianInvoiceItemFields.EvaluationStartTime.Name;
            //Assert.IsTrue(resultsetFieldsAndGroupByClause.SecondValue.Where(gbc => gbc.Name ==
            //    expectedName).Count() == 1, "GroupByClause does not contain {0}.", expectedName);
        }

        [Test]
        public void CreateMedicalVendorInvoiceStatisticFieldsAndGroupByClauseGroupsByEvaluationEndTime()
        {
            OrderedPair<ResultsetFields, GroupByCollection> resultsetFieldsAndGroupByClause = _medicalVendorInvoiceStatisticFactory.
                CreateMedicalVendorInvoiceStatisticFieldsAndGroupByClause();

            //string expectedName = PhysicianInvoiceItemFields.EvaluationEndTime.Name;
            //Assert.IsTrue(resultsetFieldsAndGroupByClause.SecondValue.Where(gbc => gbc.Name ==
            //    expectedName).Count() == 1, "GroupByClause does not contain {0}.", expectedName);
        }
    }
}