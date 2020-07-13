using System;
using System.Collections.Generic;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Infrastructure.Factories;
using Falcon.App.Infrastructure.Finance.Interfaces;
using Falcon.App.Infrastructure.Interfaces;
using Falcon.App.Core.Extensions;
using Falcon.Data.HelperClasses;
using Falcon.Data.TypedViewClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Repositories
{
    public class MedicalVendorInvoiceItemRepository : PersistenceRepository, IMedicalVendorInvoiceItemRepository
    {
        private readonly IMedicalVendorInvoiceItemFactory _medicalVendorInvoiceItemFactory;

        public MedicalVendorInvoiceItemRepository()
        {
            _medicalVendorInvoiceItemFactory = new MedicalVendorInvoiceItemFactory();
        }

        public MedicalVendorInvoiceItemRepository(IPersistenceLayer persistenceLayer, 
            IMedicalVendorInvoiceItemFactory medicalVendorInvoiceItemFactory)
            : base(persistenceLayer)
        {
            _medicalVendorInvoiceItemFactory = medicalVendorInvoiceItemFactory;
        }

        // TODO: TEST Pass in start and end dates.
        public List<MedicalVendorInvoiceItem> GetMedicalVendorInvoiceItems(long medicalVendorMedicalVendorUserId, 
            DateTime startDate, DateTime endDate)
        {
            var medicalVendorInvoiceItemRows = new MedicalVendorInvoiceItemTypedView();
            var bucket = new RelationPredicateBucket
                (MedicalVendorInvoiceItemFields.OrganizationRoleUserId == medicalVendorMedicalVendorUserId);
            bucket.PredicateExpression.Add(MedicalVendorInvoiceItemFields.ReviewDate >= startDate);
            bucket.PredicateExpression.Add(MedicalVendorInvoiceItemFields.ReviewDate <= endDate.GetEndOfDay());
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                myAdapter.FetchTypedView(medicalVendorInvoiceItemRows, bucket, false);
            }
            return _medicalVendorInvoiceItemFactory.CreateMedicalVendorInvoiceItems(medicalVendorInvoiceItemRows);
        }
    }
}