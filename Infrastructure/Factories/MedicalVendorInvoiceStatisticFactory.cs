using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Infrastructure.Finance.Interfaces;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Factories
{
    public class MedicalVendorInvoiceStatisticFactory : IMedicalVendorInvoiceStatisticFactory
    {
        private readonly IMedicalVendorInvoiceBaseFactory _medicalVendorInvoiceBaseFactory;

        public MedicalVendorInvoiceStatisticFactory()
        {
            _medicalVendorInvoiceBaseFactory = new MedicalVendorInvoiceBaseFactory();
        }

        public MedicalVendorInvoiceStatisticFactory(IMedicalVendorInvoiceBaseFactory medicalVendorInvoiceBaseFactory)
        {
            _medicalVendorInvoiceBaseFactory = medicalVendorInvoiceBaseFactory;
        }

        public List<MedicalVendorInvoiceStatistic> CreateMedicalVendorInvoiceStatistics(IEnumerable<PhysicianInvoiceEntity> 
            medicalVendorInvoiceEntities, DataTable medicalVendorInvoiceItemStatistics)
        {
            if (medicalVendorInvoiceEntities == null)
            {
                throw new ArgumentNullException("medicalVendorInvoiceEntities");
            }
            if (medicalVendorInvoiceItemStatistics == null)
            {
                throw new ArgumentNullException("medicalVendorInvoiceItemStatistics");
            }

            var medicalVendorInvoices = new List<MedicalVendorInvoiceStatistic>();
            foreach (var medicalVendorInvoiceEntity in medicalVendorInvoiceEntities)
            {
                DataRow invoiceItemStatisticsForInvoice = medicalVendorInvoiceItemStatistics.
                    Select("MedicalVendorInvoiceId = " + medicalVendorInvoiceEntity.PhysicianInvoiceId).Single();
                MedicalVendorInvoiceStatistic medicalVendorInvoiceStatistic = CreateMedicalVendorInvoiceStatistic
                    (medicalVendorInvoiceEntity, invoiceItemStatisticsForInvoice);
                medicalVendorInvoices.Add(medicalVendorInvoiceStatistic);
            }
            return medicalVendorInvoices;
        }

        public MedicalVendorInvoiceStatistic CreateMedicalVendorInvoiceStatistic(PhysicianInvoiceEntity medicalVendorInvoiceEntity,
            DataRow invoiceItemStatisticsForInvoice)
        {
            if (medicalVendorInvoiceEntity == null)
            {
                throw new ArgumentNullException("medicalVendorInvoiceEntity");
            }
            var invoiceAmount = invoiceItemStatisticsForInvoice.Field<decimal>("InvoiceAmount");
            var numberOfEvaluations = invoiceItemStatisticsForInvoice.Field<int>("NumberOfEvaluations");
            var evaluationStartTime = invoiceItemStatisticsForInvoice.Field<DateTime?>("EvaluationStartTime");
            var evaluationEndTime = invoiceItemStatisticsForInvoice.Field<DateTime?>("EvaluationEndTime");
            var evaluationTimeInMinutes = (evaluationStartTime.HasValue && evaluationEndTime.HasValue) ?
                (decimal)(evaluationEndTime.Value - evaluationStartTime.Value).TotalMinutes : 0; 
            var averageHourlyRate = evaluationTimeInMinutes != 0 ? invoiceAmount / evaluationTimeInMinutes : 0;
            var medicalVendorInvoiceStatistic = new MedicalVendorInvoiceStatistic(medicalVendorInvoiceEntity.PhysicianInvoiceId, invoiceAmount, 
                numberOfEvaluations, averageHourlyRate);
            _medicalVendorInvoiceBaseFactory.SetMedicalVendorInvoiceBaseFields(medicalVendorInvoiceStatistic, medicalVendorInvoiceEntity);
            return medicalVendorInvoiceStatistic;
                
        }

        public OrderedPair<ResultsetFields, GroupByCollection> CreateMedicalVendorInvoiceStatisticFieldsAndGroupByClause()
        {
            var resultsetFields = new ResultsetFields(5);
            resultsetFields.DefineField(PhysicianInvoiceItemFields.PhysicianInvoiceId, 0, "MedicalVendorInvoiceId");
            resultsetFields.DefineField(PhysicianInvoiceItemFields.PhysicianInvoiceId, 1, "NumberOfEvaluations", AggregateFunction.Count);
            resultsetFields.DefineField(PhysicianInvoiceItemFields.AmountEarned, 2, "InvoiceAmount", AggregateFunction.Sum);
            //Need to map from Physican Evaluation
            //resultsetFields.DefineField(PhysicianInvoiceItemFields.EvaluationStartTime, 3, "EvaluationStartTime");
            //resultsetFields.DefineField(PhysicianInvoiceItemFields.EvaluationEndTime, 4, "EvaluationEndTime");

            var groupByCollection = new GroupByCollection(resultsetFields[0]) {resultsetFields[3], resultsetFields[4]};

            return new OrderedPair<ResultsetFields, GroupByCollection>(resultsetFields, groupByCollection);
        }
    }
}